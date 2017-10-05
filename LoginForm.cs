using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography;
using System.Configuration;

namespace WindowsRestAPI
{
    public partial class LoginForm : MetroFramework.Forms.MetroForm
    {
        private WinFormRestAPI mainForm;

        public LoginForm()
        {
            InitializeComponent();
        }
        public LoginForm(WinFormRestAPI form)
        {
            InitializeComponent();
            this.mainForm = form;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = this.textUserName.Text;  
            string password = this.textPassword.Text; 

            string tenantUrl = ConfigurationManager.AppSettings["tenantUrl"];
            string apiToken = ConfigurationManager.AppSettings["apiToken"];

            Okta.Core.OktaSettings oktaSettings = new Okta.Core.OktaSettings
            {
                ApiToken = apiToken,
                BaseUri = new Uri(tenantUrl)
            };

            var authClient = new Okta.Core.Clients.AuthClient(oktaSettings);
            var oktaClient = new Okta.Core.Clients.OktaClient(apiToken, new Uri(tenantUrl));

            var authResponse = authClient.Authenticate(username, password);
            var sessionToken = authResponse.SessionToken;

            var sessionsClient = new Okta.Core.Clients.SessionsClient(oktaSettings);
            var session = sessionsClient.CreateSession(sessionToken);
            var cookieToken = session.CookieToken;

            MessageBox.Show("Session Token: " + sessionToken, "Login .Net SDK"); return;
        }

        private void btnLoginAPI_Click(object sender, EventArgs e)
        {
            string username = this.textUserName.Text;  
            string password = this.textPassword.Text; 

            string params_endpoint;

            string clientid = ConfigurationManager.AppSettings["clientid"];
            string tenantUrl = ConfigurationManager.AppSettings["tenantUrl"];
            string redirecUri = ConfigurationManager.AppSettings["redirectUri"];   //redirect_uri need to match the one in Okta (app registration)

            string state = randomDataBase64url(32);
            string nonce = randomDataBase64url(32);

            string postdata = "{\"username\":\"" + username + "\",\"password\":\"" + password + "\",\"relayState\":\"/myapp/some/deep/link/i/want/to/return/to\",\"options\":{\"multiOptionalFactorEnroll\":false,\"warnBeforePasswordExpired\":false}}";
            string endpoints = tenantUrl + "/api/v1/authn";

            //***  Authn Endpoint: Getting user Session Tokenn ***// 

            string result = mainForm.GetSessionToken(endpoints, "POST", postdata);

            if (result.Contains("SUCCESS"))
            {
                LoginSuccess loginSuccess = new LoginSuccess();
                loginSuccess = JsonConvert.DeserializeObject<LoginSuccess>(result);
             
                params_endpoint = "?client_id=" + clientid +
                        "&scope=openid email phone address groups profile" +
                        "&response_type=id_token token" +
                        "&response_mode=fragment" +
                        "&nonce=" + nonce +
                        "&redirect_uri=" + redirecUri +
                        "&state=" + state + 
                        "&sessionToken=" + loginSuccess.SessionToken;

                string endpoint = tenantUrl + "/oauth2/v1/authorize" + params_endpoint;

                //*** Authorize Endpoint: Geting Access Token  ***//

                result = mainForm.GetAccessToken(endpoint, "GET");

                string[] tokens = result.Split('&');

                int index = tokens[1].IndexOf("=") + 1;
                string iniit = tokens[1].Substring(0, index);
                int len = tokens[1].Length- iniit.Length;
                string Access_Token = tokens[1].Substring(index, len);

                MessageBox.Show("Access Token: " + result, "Getting Access Token");

                //***  UserInfo Endpoint: Getting user info using Access Token ***//

                endpoints = tenantUrl + "/oauth2/v1/userinfo";
                result = mainForm.GetUserInfo(endpoints, "GET", Access_Token);

                MessageBox.Show("User Info: " + result, "User Info"); return;
            }
            else
            {
                MessageBox.Show("Unsucess login: " + result, "User Authentication"); return;
            }
        }
        private static string randomDataBase64url(uint length)
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] bytes = new byte[length];
            rng.GetBytes(bytes);
            return base64urlencodeNoPadding(bytes);
        }
        private static string base64urlencodeNoPadding(byte[] buffer)
        {
            return Convert.ToBase64String(buffer)
                    .Replace("+", "-")
                    .Replace("/", "_")
                    .Replace("=", "");
        }
    }
}
