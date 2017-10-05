using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsRestAPI
{
    public partial class BrowserLoginForm : MetroFramework.Forms.MetroForm
    {
        private WinFormRestAPI mainForm;

        private string clientID;
        private string clientSecret;
        private string redirectURI;
        private string tenantUrl;

        public BrowserLoginForm()
        {
            InitializeComponent();
        }
        public BrowserLoginForm(WinFormRestAPI form)
        {
            InitializeComponent();
            this.mainForm = form;

            tenantUrl = ConfigurationManager.AppSettings["tenantUrl"];
            clientID = ConfigurationManager.AppSettings["clientId"];
            clientSecret = ConfigurationManager.AppSettings["clientSecret"];
            redirectURI = ConfigurationManager.AppSettings["redirectURI"];
        }

        private async void BrowserLoginForm_Load(object sender, EventArgs e)
        {
            //webBrowser1.Navigate(new Uri(tenantUrl));

            // Generates state and PKCE values.
            string state = randomDataBase64url(32);
            string code_verifier = randomDataBase64url(32);
            string code_challenge = base64urlencodeNoPadding(sha256(code_verifier));

            // Creates an HttpListener to listen for requests on that redirect URI.
            var http = new HttpListener();
            http.Prefixes.Add(redirectURI);

            http.Start();

            // Creates the OAuth 2.0 authorization request.
            string params_endpoint = "?client_id=" + clientID +
                "&scope=openid email phone address groups profile" +
                "&response_type=code" +
                "&response_mode=query" +
                "&nonce=" + "nonceStatic" +
                "&redirect_uri=" + redirectURI +
                "&state=" + state +
                "&sessionToken=" + "session_no_needed";
            string authorizationRequest = tenantUrl + "/oauth2/v1/authorize" + params_endpoint;


            // Sending request to the browser.
            //System.Diagnostics.Process.Start(authorizationRequest);
            webBrowser1.ScriptErrorsSuppressed = true;
            webBrowser1.Navigate(new Uri(authorizationRequest));

            // Waits for the OAuth authorization response.
            var context = await http.GetContextAsync();

            // Bring focus back to the app.
            this.Activate();


            // Sends an HTTP response to the browser.
            var response = context.Response;
            string responseString = string.Format("<html><head><meta http-equiv='refresh' content='10;url=https://okta.com'></head><body>Please return to the okta app.</body></html>");
            var buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
            response.ContentLength64 = buffer.Length;
            var responseOutput = response.OutputStream;
            System.Threading.Tasks.Task responseTask = responseOutput.WriteAsync(buffer, 0, buffer.Length).ContinueWith((task) =>
            {
                responseOutput.Close();
                http.Stop();
                Console.WriteLine("HTTP server stopped.");
            });

            // Checks for errors.
            if (context.Request.QueryString.Get("error") != null)
            {
                //output(String.Format("OAuth authorization error: {0}.", context.Request.QueryString.Get("error")));
                return;
            }
            if (context.Request.QueryString.Get("code") == null
                || context.Request.QueryString.Get("state") == null)
            {
                //output("Malformed authorization response. " + context.Request.QueryString);
                return;
            }

            // extracts the code
            var code = context.Request.QueryString.Get("code");
            var incoming_state = context.Request.QueryString.Get("state");

            // Compares the receieved state to the expected value, to ensure that
            // this app made the request which resulted in authorization.
            if (incoming_state != state)
            {
                //output(String.Format("Received request with invalid state ({0})", incoming_state));
                return;
            }
            //output("Authorization code: " + code);

            // Starts the code exchange at the Token Endpoint.
            getAccessToken(code, code_verifier, redirectURI);

        }
        async void getAccessToken(string code, string code_verifier, string redirectURI)
        {
            //output("Getting access token...");

            // builds the /oauth2/v1/token request
            string tokenRequestURI = tenantUrl + "/oauth2/v1/token";
            string tokenRequestBody = string.Format("code={0}&redirect_uri={1}&client_id={2}&code_verifier={3}&client_secret={4}&scope=&grant_type=authorization_code",
                code,
                System.Uri.EscapeDataString(redirectURI),
                clientID,
                code_verifier,
                clientSecret
                );

            //Sends the request
            HttpWebRequest tokenRequest = (HttpWebRequest)WebRequest.Create(tokenRequestURI);
            tokenRequest.Method = "POST";
            tokenRequest.ContentType = "application/x-www-form-urlencoded";

            byte[] _byteVersion = Encoding.ASCII.GetBytes(tokenRequestBody);
            Stream stream = tokenRequest.GetRequestStream();
            await stream.WriteAsync(_byteVersion, 0, _byteVersion.Length);
            stream.Close();

            try
            {
                // gets the response
                WebResponse tokenResponse = await tokenRequest.GetResponseAsync();
                using (StreamReader reader = new StreamReader(tokenResponse.GetResponseStream()))
                {
                    // reads response body
                    string responseText = await reader.ReadToEndAsync();
                    //output(responseText);

                    // converts to dictionary
                    Dictionary<string, string> tokenEndpointDecoded = JsonConvert.DeserializeObject<Dictionary<string, string>>(responseText);

                    string access_token = tokenEndpointDecoded["access_token"];

                    getUserInfo(access_token);
                }
            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    var response = ex.Response as HttpWebResponse;
                    if (response != null)
                    {
                        //output("HTTP: " + response.StatusCode);
                        using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                        {
                            // reads response body
                            string responseText = await reader.ReadToEndAsync();
                            //output(responseText);
                        }
                    }

                }
            }
        }


        async void getUserInfo(string access_token)
        {
            //output("Getting Userinfo usign access token...");

            // builds the  request
            string userinfoRequestURI = tenantUrl + "/oauth2/v1/userinfo";

            // sends the request
            HttpWebRequest userinfoRequest = (HttpWebRequest)WebRequest.Create(userinfoRequestURI);
            userinfoRequest.Method = "GET";
            userinfoRequest.Headers.Add(string.Format("Authorization: Bearer {0}", access_token));
            userinfoRequest.ContentType = "application/x-www-form-urlencoded";

            // gets the response
            WebResponse userinfoResponse = await userinfoRequest.GetResponseAsync();
            string userinfoResponseText;
            using (StreamReader userinfoResponseReader = new StreamReader(userinfoResponse.GetResponseStream()))
            {
                // reads response body
                userinfoResponseText = await userinfoResponseReader.ReadToEndAsync();
                //output(userinfoResponseText);
            }

            mainForm.writeOutput("Access Token: " + access_token);
            mainForm.writeOutput("User Info: " + userinfoResponseText);

            MessageBox.Show("Access Token: " + access_token, "Access Token");
            MessageBox.Show("User Info: " + userinfoResponseText, "User Info"); return;
        }
        public static string randomDataBase64url(uint length)
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] bytes = new byte[length];
            rng.GetBytes(bytes);
            return base64urlencodeNoPadding(bytes);
        }

        /// <summary>
        /// Returns the SHA256 hash of the input string.
        /// </summary>
        /// <param name="inputStirng"></param>
        /// <returns></returns>
        public static byte[] sha256(string inputStirng)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(inputStirng);
            SHA256Managed sha256 = new SHA256Managed();
            return sha256.ComputeHash(bytes);
        }

        /// <summary>
        /// Base64url no-padding encodes the given input buffer.
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public static string base64urlencodeNoPadding(byte[] buffer)
        {
            string base64 = Convert.ToBase64String(buffer);

            // Converts base64 to base64url.
            base64 = base64.Replace("+", "-");
            base64 = base64.Replace("/", "_");
            // Strips padding.
            base64 = base64.Replace("=", "");

            return base64;
        }

    }
}
