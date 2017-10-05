using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Net;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Configuration;
using System.Security.Cryptography;

namespace WindowsRestAPI
{
    public partial class WinFormRestAPI : MetroFramework.Forms.MetroForm
    {
        private List<User> oktaUserList;
        private List<Group> oktaGroupList;
        private static string  apiToken;
        private static string oktaEnv;

        string clientID;
        string clientSecret;
        string redirectURI;
        string tenantUrl;

        public WinFormRestAPI()
        {
            InitializeComponent();


            dgwOktaUserList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgwOktaUserList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dgwOktaGroupList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgwOktaGroupList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dgwOktaUserList.DataSource = oktaUserList;
            dgwOktaGroupList.DataSource = oktaGroupList;

            apiToken = ConfigurationManager.AppSettings["apiToken"];
            this.textApiToken.Text = apiToken;
            oktaEnv = ConfigurationManager.AppSettings["tenantUrl"];
            clientID = ConfigurationManager.AppSettings["clientId"];
            clientSecret = ConfigurationManager.AppSettings["clientSecret"];

            redirectURI = ConfigurationManager.AppSettings["redirectURI"];

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.txtResult.Text = "";
        }
        public void writeOutput(string value)
        {
            this.txtResult.AppendText(Environment.NewLine);
            this.txtResult.AppendText(Environment.NewLine);
            this.txtResult.AppendText(value + Environment.NewLine);
            this.txtResult.AppendText(Environment.NewLine);
            this.txtResult.AppendText(Environment.NewLine);
        }
  /*      private void btnUsersGet_Click(object sender, EventArgs e)
        {
            string endpoint = oktaEnv + "/api/v1/users?limit=10";
            string json = GetAll(endpoint, "GET");

            writeOutput(endpoint);

            try
            {

                User userItem;
                oktaUserList = new List<User>();
                oktaUserList.Clear();

                System.Text.StringBuilder d3js = new System.Text.StringBuilder();
                System.Text.StringBuilder groups_d3js = new System.Text.StringBuilder();
                System.Text.StringBuilder apps_d3js = new System.Text.StringBuilder();

                dynamic users = JsonConvert.DeserializeObject(json);

                d3js.AppendFormat("{{\"name\": \"{0}\", \"children\":" + "[", oktaEnv);

                int numUsers = 0;
                int numGroups = 0;
                int numApps = 0;
                foreach (var user in users)
                {

                    // Groups from each user

                    try
                    {
                        string endpoint_groups = oktaEnv + "/api/v1/users/" + user.id.Value + "/groups";
                        string json_groups = GetAll(endpoint_groups, "GET");

                        dynamic groups = JsonConvert.DeserializeObject(json_groups);
                        foreach (var group in groups)
                        {
                            groups_d3js.AppendFormat("{{\"name\": \"{0}\", \"children\":", group.profile.name.Value == null ? "" : group.profile.name.Value.ToString());
                            groups_d3js.AppendFormat("[");
                            groups_d3js.AppendFormat("{{\"name\": \"Name: {0}\", \"size\": 3938}},", group.profile.name.Value == null ? "" : group.profile.name.Value.ToString());
                            groups_d3js.AppendFormat("{{\"name\": \"Desc: {0}\", \"size\": 3938}}", group.profile.description.Value == null ? "" : group.profile.description.Value.ToString());
                            groups_d3js.AppendFormat("]");
                            groups_d3js.AppendFormat("}}");
                            if (numGroups < groups.Count - 1)
                            {
                                groups_d3js.AppendFormat(",");  // to every item except the last one.
                            }
                            numGroups++;
                        }

                        string endpoint_apps = oktaEnv + "/api/v1/users/" + user.id.Value + "/appLinks";
                        string json_apps = GetAll(endpoint_apps, "GET");

                        dynamic apps = JsonConvert.DeserializeObject(json_apps);
                        foreach (var app in apps)
                        {
                            apps_d3js.AppendFormat("{{\"name\": \"{0}\", \"children\":", app.label.Value == null ? "" : app.label.Value.ToString());
                            apps_d3js.AppendFormat("[");
                            apps_d3js.AppendFormat("{{\"name\": \"App Name: {0}\", \"size\": 3938}},", app.appName.Value == null ? "" : app.appName.Value.ToString());
                            apps_d3js.AppendFormat("{{\"name\": \"Link: {0}\", \"size\": 3938}}", app.linkUrl.Value == null ? "" : app.linkUrl.Value.ToString());
                            apps_d3js.AppendFormat("]");
                            apps_d3js.AppendFormat("}}");
                            if (numApps < apps.Count - 1)
                            {
                                apps_d3js.AppendFormat(",");  // to every item except the last one.
                            }
                            numApps++;
                        }

                    }
                    catch (Exception ex)
                    {
                    }


                    d3js.AppendFormat("{{\"name\": \"{0}\", \"children\":", user.profile.login.Value == null ? "" : user.profile.login.Value.ToString());
                    d3js.AppendFormat("[");
                    //d3js.AppendFormat("{{\"name\": \"parent: 00u2ojcqxtloZ9YL61t7\", \"size\": 3938}},");
                    d3js.AppendFormat("{{\"name\": \"First Name: {0}\", \"size\": 3938}},", user.profile.firstName.Value == null ? "" : user.profile.firstName.Value.ToString());
                    d3js.AppendFormat("{{\"name\": \"Last Name: {0}\", \"size\": 3938}},", user.profile.lastName.Value == null ? "" : user.profile.lastName.Value.ToString());
                    d3js.AppendFormat("{{\"name\": \"Email: {0}\", \"size\": 3938}},", user.profile.email.Value == null ? "" : user.profile.email.Value.ToString());
                    d3js.AppendFormat("{{\"name\": \"Second Email: {0} \", \"size\": 3938}},", user.profile.secondEmail.Value == null ? "" : user.profile.secondEmail.Value.ToString());
                    d3js.AppendFormat("{{\"name\": \"Mobile Phone: {0}\", \"size\": 3938}},", user.profile.mobilePhone.Value == null ? "" : user.profile.mobilePhone.Value.ToString());
                    //d3js.AppendFormat("{{\"name\": \"Login: {0}\", \"size\": 3938}},", user.profile.login.Value == null ? "" : user.profile.login.Value.ToString());
                    d3js.AppendFormat("{{\"name\": \"Status: {0}\", \"size\": 3938}},", user.status.Value == null ? "" : user.status.Value.ToString());
                    d3js.AppendFormat("{{\"name\": \"Type: {0}\", \"size\": 3938}},", user.credentials.provider.type.Value == null ? "" : user.credentials.provider.type.Value.ToString());
                    d3js.AppendFormat("{{\"name\": \"Created: {0}\", \"size\": 3938}},", user.created.Value == null ? "" : user.created.Value.ToString());
                    d3js.AppendFormat("{{\"name\": \"Activated: {0} \", \"size\": 3938}},", user.activated.Value == null ? "" : user.activated.Value.ToString());
                    //d3js.AppendFormat("{{\"name\": \"Status Changed: {0} \", \"size\": 3938}},", user.statusChanged.Value == null ? "" : user.statusChanged.Value.ToString());
                    //d3js.AppendFormat("{{\"name\": \"Last Login: {0} \", \"size\": 3938}},", user.lastLogin.Value == null ? "" : user.lastLogin.Value.ToString());
                    //d3js.AppendFormat("{{\"name\": \"Last Updated: {0} \", \"size\": 3938}},", user.lastUpdated.Value == null ? "" : user.lastUpdated.Value.ToString());
                    d3js.AppendFormat("{{\"name\": \"Password Changed: {0}\", \"size\": 3938}}", user.passwordChanged.Value == null ? "" : user.passwordChanged.Value.ToString());
                    if (numGroups > 0)
                    {
                        d3js.AppendFormat(",{{\"name\": \"Groups\", \"children\":");
                        d3js.AppendFormat("[");
                        d3js.Append(groups_d3js.ToString());
                        d3js.AppendFormat("]");
                        d3js.AppendFormat("}}");
                    }
                    if (numApps > 0)
                    {
                        d3js.AppendFormat(",{{\"name\": \"Apps\", \"children\":");
                        d3js.AppendFormat("[");
                        d3js.Append(apps_d3js.ToString());
                        d3js.AppendFormat("]");
                        d3js.AppendFormat("}}");
                    }
                    //d3js.AppendFormat("{{\"name\": \"credentials\", \"children\":");
                    //d3js.Append("[");
                    //d3js.AppendFormat("{{\"name\": \"provider\", \"children\":");
                    //d3js.Append("[");
                    //d3js.AppendFormat("{{\"name\": \"type: ACTIVE_DIRECTORY\", \"size\": 3938}},");
                    //d3js.AppendFormat("{{\"name\": \"awsdcirecondo.co.uk\", \"size\": 3938}}");
                    //d3js.AppendFormat("]");
                    //d3js.AppendFormat("}},");
                    //d3js.AppendFormat("{{\"name\": \"_links\", \"children\":");
                    //d3js.AppendFormat("[");
                    //d3js.AppendFormat("{{\"name\":\"self\", \"children\":");
                    //d3js.AppendFormat("[");
                    //d3js.AppendFormat("{{\"name\": \"href: https://dcirecondo.okta.com/api/v1/users/00u2ojcqxtloZ9YL61t7\", \"size\": 3938}}");
                    //d3js.AppendFormat("]");
                    //d3js.AppendFormat("}}");
                    //d3js.AppendFormat("]");
                    //d3js.AppendFormat("}}");
                    //d3js.AppendFormat("]");
                    //d3js.AppendFormat("}}");
                    d3js.AppendFormat("]");
                    d3js.AppendFormat("}}");

                    if (numUsers < users.Count - 1)
                    {
                        d3js.AppendFormat(",");  // to every item except the last one.
                    }
                    groups_d3js.Clear();
                    apps_d3js.Clear();
                    numUsers++;
                    numGroups = 0;
                    numApps = 0;
                }

                d3js.Append("]}");



                foreach (var user in users)
                {
                    userItem = new User();
                    userItem.Id = user.id.Value.ToString();
                    userItem.FirstName = user.profile.firstName.Value == null ? "" : user.profile.firstName.Value.ToString();
                    userItem.LastName = user.profile.lastName.Value == null ? "" : user.profile.lastName.Value.ToString();
                    userItem.Email = user.profile.email.Value == null ? "" : user.profile.email.Value.ToString();
                    userItem.Login = user.profile.login.Value == null ? "" : user.profile.login.Value.ToString();
                    userItem.MobilePhone = user.profile.mobilePhone.Value == null ? "" : user.profile.mobilePhone.Value.ToString();
                    userItem.Status = user.status.Value == null ? "" : user.status.Value.ToString();
                    userItem.Created = user.created.Value == null ? "" : user.created.Value.ToString();
                    userItem.Activated = user.activated.Value == null ? "" : user.activated.Value.ToString();
                    userItem.StatusChanged = user.statusChanged.Value == null ? "" : user.statusChanged.Value.ToString();
                    userItem.LastLogin = user.lastLogin.Value == null ? "" : user.lastLogin.Value.ToString();
                    userItem.LastUpdated = user.lastUpdated.Value == null ? "" : user.lastUpdated.Value.ToString();
                    userItem.PasswordChanged = user.passwordChanged.Value == null ? "" : user.passwordChanged.Value.ToString();

                    oktaUserList.Add(userItem);
                }

            }
            catch (Exception ex)
            {
              
            }

            this.dgwOktaUserList.DataSource = oktaUserList;
            dgwOktaUserList.Update();

            writeOutput(json.ToString());
        }*/
         
        private void btnUsersGet_Click(object sender, EventArgs e)
        {
            string endpoint = oktaEnv + "/api/v1/users?limit=100";
            string json = GetAll(endpoint, "GET");

            writeOutput(endpoint);

            try
            {
                dynamic users = JsonConvert.DeserializeObject(json);

                User userItem;
                oktaUserList = new List<User>();
                oktaUserList.Clear();

                foreach (var user in users)
                {
                    userItem = new User();
                    userItem.Id = user.id.Value.ToString();
                    userItem.FirstName = user.profile.firstName.Value == null ? "" : user.profile.firstName.Value.ToString();
                    userItem.LastName = user.profile.lastName.Value == null ? "" : user.profile.lastName.Value.ToString();
                    userItem.Email = user.profile.email.Value == null ? "" : user.profile.email.Value.ToString();
                    userItem.Login = user.profile.login.Value == null ? "" : user.profile.login.Value.ToString();
                    userItem.MobilePhone = user.profile.mobilePhone.Value == null ? "" : user.profile.mobilePhone.Value.ToString();
                    userItem.Status = user.status.Value == null ? "" : user.status.Value.ToString();
                    userItem.Created = user.created.Value == null ? "" : user.created.Value.ToString();
                    userItem.Activated = user.activated.Value == null ? "" : user.activated.Value.ToString();
                    userItem.StatusChanged = user.statusChanged.Value == null ? "" : user.statusChanged.Value.ToString();
                    userItem.LastLogin = user.lastLogin.Value == null ? "" : user.lastLogin.Value.ToString();
                    userItem.LastUpdated = user.lastUpdated.Value == null ? "" : user.lastUpdated.Value.ToString();
                    userItem.PasswordChanged = user.passwordChanged.Value == null ? "" : user.passwordChanged.Value.ToString();

                    oktaUserList.Add(userItem);
                }
            }
            catch (Exception ex)
            {
              
            }

            this.dgwOktaUserList.DataSource = oktaUserList;
            dgwOktaUserList.Update();

            writeOutput(json.ToString());
        }

        public static bool isValidJSON(string json)
        {
            try
            {
                JToken token = JObject.Parse(json);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public string CreateNewUser(string endpoint, string method, string postdata)
        {
            var responseText = "";
            var webRequest = WebRequest.Create(new Uri(endpoint)) as HttpWebRequest;

            if (webRequest != null)
            {
                webRequest.Method = method;
                webRequest.Headers.Add("Authorization", "SSWS " + apiToken);
                webRequest.Accept = "application/json";
                webRequest.ContentType = "application/json";


                JObject user = JObject.Parse(postdata);
                bool validJson = isValidJSON(postdata);

                using (var requestWriter = new StreamWriter(webRequest.GetRequestStream()))
                {
                    requestWriter.Write(postdata);
                }

                try
                {
                    var response = (HttpWebResponse)webRequest.GetResponse();
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        responseText = reader.ReadToEnd();
                    }
                }
                catch (WebException ex)
                {
                    using (WebResponse response = ex.Response)
                    {
                        var httpResponse = (HttpWebResponse)response;

                        using (Stream data = response.GetResponseStream())
                        {
                            try
                            {
                                StreamReader sr = new StreamReader(data);
                                throw new Exception(sr.ReadToEnd());
                            }
                            catch (Exception e1)
                            {
                                responseText = "Error: " + e1.ToString();
                            }
                        }
                    }
                }
            }

            return responseText;
        }
        public string UpdateUser(string endpoint, string method, string postdata)
        {
            var responseText = "";
            var webRequest = WebRequest.Create(new Uri(endpoint)) as HttpWebRequest;

            if (webRequest != null)
            {
                webRequest.Method = method;
                webRequest.Headers.Add("Authorization", "SSWS " + apiToken);
                webRequest.Accept = "application/json";
                webRequest.ContentType = "application/json";


                JObject user = JObject.Parse(postdata);
                bool validJson = isValidJSON(postdata);

                using (var requestWriter = new StreamWriter(webRequest.GetRequestStream()))
                {
                    requestWriter.Write(postdata);
                }

                try
                {
                    var response = (HttpWebResponse) webRequest.GetResponse();
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        responseText = reader.ReadToEnd();
                    }
                }
                catch (WebException ex)
                {
                    using (WebResponse response = ex.Response)
                    {
                        var httpResponse = (HttpWebResponse)response;

                        using (Stream data = response.GetResponseStream())
                        {
                            try
                            {
                                StreamReader sr = new StreamReader(data);
                                throw new Exception(sr.ReadToEnd());
                            }
                            catch (Exception e1)
                            {
                                responseText = "Error: "+ e1.ToString();
                            }
                        }
                    }
                }
            }

            return responseText;
        }
        public string DeleteUser(string endPoint, string method)
        {
            var responseText = "";
            var webRequest = WebRequest.Create(new Uri(endPoint)) as HttpWebRequest;

            if (webRequest != null)
            {
                webRequest.Method = method;
                webRequest.Headers.Add("Authorization", "SSWS " + apiToken);
                webRequest.Accept = "application/json";
                webRequest.ContentType = "application/json";

                try { 
                    var response = webRequest.GetResponse();
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        responseText = reader.ReadToEnd();
                    }
                }
                catch (WebException ex)
                {
                    using (WebResponse response = ex.Response)
                    {
                        var httpResponse = (HttpWebResponse)response;

                        using (Stream data = response.GetResponseStream())
                        {
                            try
                            {
                                StreamReader sr = new StreamReader(data);
                                throw new Exception(sr.ReadToEnd());
                            }
                            catch (Exception e1)
                            {
                                responseText = "Error: " + e1.ToString();
                            }
                        }
                    }
                }
            }

            return responseText;
        }
        public string GetAll(string endpoint, string method)
        {
            var responseText = "";
            var webRequest = WebRequest.Create(new Uri(endpoint)) as HttpWebRequest;

            if (webRequest != null)
            {
                webRequest.Method = method;
                webRequest.Headers.Add("Authorization", "SSWS " + apiToken);
                webRequest.Accept = "application/json";
                webRequest.ContentType = "application/json";

                var response = webRequest.GetResponse();
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    responseText = reader.ReadToEnd();
                }
            }

            return responseText;
        }
        public string GetSessionToken(string endpoint, string method, string postdata)
        {
            var responseText = "";
            var webRequest = WebRequest.Create(new Uri(endpoint)) as HttpWebRequest;

            if (webRequest != null)
            {
                webRequest.Method = method;
                webRequest.Headers.Add("Authorization", "SSWS " + apiToken);
                webRequest.Accept = "application/json";
                webRequest.ContentType = "application/json";

                JObject user = JObject.Parse(postdata);
                bool validJson = isValidJSON(postdata);

                using (var requestWriter = new StreamWriter(webRequest.GetRequestStream()))
                {
                    requestWriter.Write(postdata);
                }

                try
                {
                    var response = (HttpWebResponse)webRequest.GetResponse();

                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        responseText = reader.ReadToEnd();
                    }
                }
                catch (WebException ex)
                {
                    using (WebResponse response = ex.Response)
                    {
                        var httpResponse = (HttpWebResponse)response;

                        using (Stream data = response.GetResponseStream())
                        {
                            try
                            {
                                StreamReader sr = new StreamReader(data);
                                throw new Exception(sr.ReadToEnd());
                            }
                            catch (Exception e1)
                            {
                                responseText = "Error: " + e1.ToString();
                            }
                        }
                    }
                }
            }

            return responseText;
        }
        public string GetAccessToken(string endpoint, string method)
        {
            var responseText = "";
            var webRequest = WebRequest.Create(new Uri(endpoint)) as HttpWebRequest;

            if (webRequest != null)
            {
                webRequest.Method = method;
                webRequest.AllowAutoRedirect = false;

                HttpWebResponse response = (HttpWebResponse) webRequest.GetResponse();
                string redirectLocation = "";
                if (response.StatusCode == HttpStatusCode.Found)
                {
                    redirectLocation = response.Headers["Location"];
                    responseText = redirectLocation;
                }
                /*using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    responseText = reader.ReadToEnd();
                }*/
            }

            return responseText;
        }
        public string GetUserInfo(string endpoint, string method, string access_token)
        {
            var responseText = "";
            var webRequest = WebRequest.Create(new Uri(endpoint)) as HttpWebRequest;

            if (webRequest != null)
            {
                webRequest.Method = method;
                webRequest.Headers.Add("Authorization", "Bearer " + access_token);
                webRequest.Accept = "application/json";
                webRequest.ContentType = "application/json";

                var response = webRequest.GetResponse();
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    responseText = reader.ReadToEnd();
                }
            }

            return responseText;
        }
        public string GetUser(string endpoint, string method)
        {
            var responseText = "";
            var webRequest = WebRequest.Create(new Uri(endpoint)) as HttpWebRequest;

            if (webRequest != null)
            {
                webRequest.Method = method;
                webRequest.Headers.Add("Authorization", "SSWS " + apiToken);
                webRequest.Accept = "application/json";
                webRequest.ContentType = "application/json";

                var response = webRequest.GetResponse();
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    responseText = reader.ReadToEnd();
                }
            }

            return responseText;
        }

        private void metroBtnLogin_Click(object sender, EventArgs e)
        {
            string username = ""; //this.metroUserName.Text;
            string password = ""; //this.metroPassword.Text;

            string endpoint, postdata;

            endpoint = oktaEnv + "/api/v1/authn";
            postdata = "{\"username\":\"" + username + "\",\"password\":\"" + password + "\",\"relayState\":\"/myapp/some/deep/link/i/want/to/return/to\",\"options\":{\"multiOptionalFactorEnroll\":false,\"warnBeforePasswordExpired\":false}}";
            string newAuth = AuthUserPublicApp(endpoint, "POST", postdata);

        }
 

        private void metroBtnCreateUser_Click(object sender, EventArgs e)
        {
            CreateBrowserLoginForm createUserForm = new CreateBrowserLoginForm(this);
            createUserForm.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            createUserForm.ShowDialog();
        }

        private void metroBtnDeleteUser_Click(object sender, EventArgs e)
        {
            //string userID = "00ub0oNGTSWTBKOLGLNR";

            if (dgwOktaUserList == null || dgwOktaUserList.CurrentRow == null)
            {
                MessageBox.Show("Select user to get deleted", "User Deletion"); return;
            }

            int selUserId = dgwOktaUserList.CurrentRow.Index;
            string userID = dgwOktaUserList[0, selUserId].Value.ToString();

            if (!string.IsNullOrEmpty(userID))
            {
                User selUser = new User();
                foreach (User userItem in oktaUserList)
                {
                    if (userItem.Id == userID)
                    {
                        selUser = userItem;
                    }
                }

                string endPoint = string.Concat(oktaEnv + "/api/v1/users/" + userID);
                string user = DeleteUser(endPoint, "DELETE");
            }
        }

        private void metroBtnUpdateUser_Click(object sender, EventArgs e)
        {
            if (dgwOktaUserList == null || dgwOktaUserList.CurrentRow == null)
            {
                MessageBox.Show("Select user to get updated", "User Update"); return;
            }

            int selUserId = dgwOktaUserList.CurrentRow.Index;
            string userID = dgwOktaUserList[0, selUserId].Value.ToString();

            User selUser = new User();
            if (!string.IsNullOrEmpty(userID))
            {
                
                foreach (User userItem in oktaUserList)
                {
                    if (userItem.Id == userID)
                    {
                        selUser = userItem;
                        UpdateUserForm updateUserForm = new UpdateUserForm(this, selUser);
                        updateUserForm.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
                        updateUserForm.ShowDialog();
                    }
                }
            }
        }
        public string AuthUserPublicApp(string endpoint, string method, string postdata)
        {
            var responseText = "";
            var webRequest = WebRequest.Create(new Uri(endpoint)) as HttpWebRequest;

            if (webRequest != null)
            {
                webRequest.Method = method;
                webRequest.Accept = "application/json";
                webRequest.ContentType = "application/json";


                JObject user = JObject.Parse(postdata);
                bool validJson = isValidJSON(postdata);

                using (var requestWriter = new StreamWriter(webRequest.GetRequestStream()))
                {
                    requestWriter.Write(postdata);
                }

                try
                {
                    var response = (HttpWebResponse)webRequest.GetResponse();
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        responseText = reader.ReadToEnd();
                    }
                }
                catch (WebException ex)
                {
                    using (WebResponse response = ex.Response)
                    {
                        var httpResponse = (HttpWebResponse)response;

                        using (Stream data = response.GetResponseStream())
                        {
                            try
                            {
                                StreamReader sr = new StreamReader(data);
                                throw new Exception(sr.ReadToEnd());
                            }
                            catch (Exception e1)
                            {
                                responseText = "Error: " + e1.ToString();
                            }
                        }
                    }
                }
            }

            return responseText;
        }
        private void btnCreateProfile_Click(object sender, EventArgs e)
        {

            LoginForm loginForm = new LoginForm(this);
            loginForm.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            loginForm.ShowDialog();
        }
        public string ResetFactorsUser(string endpoint, string method, string postdata)
        {
            var responseText = "";
            var webRequest = WebRequest.Create(new Uri(endpoint)) as HttpWebRequest;

            if (webRequest != null)
            {
                webRequest.Method = method;
                webRequest.Headers.Add("Authorization", "SSWS " + apiToken);
                webRequest.Accept = "application/json";
                webRequest.ContentType = "application/json";

                using (var requestWriter = new StreamWriter(webRequest.GetRequestStream()))
                {
                    requestWriter.Write(postdata);
                }

                try
                {
                    var response = (HttpWebResponse)webRequest.GetResponse();
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        responseText = reader.ReadToEnd();
                    }
                }
                catch (WebException ex)
                {
                    using (WebResponse response = ex.Response)
                    {
                        var httpResponse = (HttpWebResponse)response;

                        using (Stream data = response.GetResponseStream())
                        {
                            try
                            {
                                StreamReader sr = new StreamReader(data);
                                throw new Exception(sr.ReadToEnd());
                            }
                            catch (Exception e1)
                            {
                                responseText = "Error: " + e1.ToString();
                            }
                        }
                    }
                }
            }

            return responseText;
        }
        private void btnResetFactors_Click(object sender, EventArgs e)
        {
            if (dgwOktaUserList == null || dgwOktaUserList.CurrentRow == null)
            {
                MessageBox.Show("Select user to get factor reset", "Reseting Factors"); return;
            }

            int selUserId = dgwOktaUserList.CurrentRow.Index;
            string userID = dgwOktaUserList[0, selUserId].Value.ToString();

            User selUser = new User();
            if (!string.IsNullOrEmpty(userID))
            {

                foreach (User userItem in oktaUserList)
                {
                    if (userItem.Id == userID)
                    {
                        selUser = userItem;

                        string endpoint = oktaEnv + "/api/v1/users/" + selUser + "/lifecycle/reset_factors";
                        string postdata = "";
                        string reset_factors = ResetFactorsUser(endpoint, "POST", postdata);

                        MessageBox.Show("Factor reset: " + reset_factors, "Reseting Factors");
                    }
                }
            }
        }
        public string ClearSessionsUser(string endpoint, string method, string postdata)
        {
            var responseText = "";
            var webRequest = WebRequest.Create(new Uri(endpoint)) as HttpWebRequest;

            if (webRequest != null)
            {
                webRequest.Method = method;
                webRequest.Headers.Add("Authorization", "SSWS " + apiToken);
                webRequest.Accept = "application/json";
                webRequest.ContentType = "application/json";

                try
                {
                    var response = (HttpWebResponse)webRequest.GetResponse();
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        responseText = reader.ReadToEnd();
                    }
                }
                catch (WebException ex)
                {
                    using (WebResponse response = ex.Response)
                    {
                        var httpResponse = (HttpWebResponse)response;

                        using (Stream data = response.GetResponseStream())
                        {
                            try
                            {
                                StreamReader sr = new StreamReader(data);
                                throw new Exception(sr.ReadToEnd());
                            }
                            catch (Exception e1)
                            {
                                responseText = "Error: " + e1.ToString();
                            }
                        }
                    }
                }
            }

            return responseText;
        }
        private void btnClearSessions_Click(object sender, EventArgs e)
        {
            if (dgwOktaUserList == null || dgwOktaUserList.CurrentRow == null)
            {
                MessageBox.Show("Select user to get sessions cleared", "Clearing User Session"); return;
            }

            int selUserId = dgwOktaUserList.CurrentRow.Index;
            string userID = dgwOktaUserList[0, selUserId].Value.ToString();

            User selUser = new User();
            if (!string.IsNullOrEmpty(userID))
            {

                foreach (User userItem in oktaUserList)
                {
                    if (userItem.Id == userID)
                    {
                        selUser = userItem;

                        string endpoint = oktaEnv + "/api/v1/users/" + selUser + "/sessions";
                        string postdata = "";
                        string reset_factors = ClearSessionsUser(endpoint, "DELETE", postdata);

                        MessageBox.Show("Clear Sessions: " + reset_factors, "Clearing User Session");
                    }
                }
            }
        }

        private void btnGroupsGet_Click(object sender, EventArgs e)
        {
            string endpoint = oktaEnv + "/api/v1/groups?limit=100";
            string json = GetAll(endpoint, "GET");

            writeOutput(endpoint);

            try
            {
                dynamic groups = JsonConvert.DeserializeObject(json);

                Group groupItem;
                oktaGroupList = new List<Group>();
                oktaGroupList.Clear();

                foreach (var group in groups)
                {
                    groupItem = new Group();
                    groupItem.Id = group.id.Value.ToString();
                    groupItem.Name = group.profile.name.Value == null ? "" : group.profile.name.Value.ToString();
                    groupItem.Description = group.profile.description.Value == null ? "" : group.profile.description.Value.ToString();

                    try
                    { 
                        if (groupItem.Name.Contains("Marketing")){
                            writeOutput(json.ToString());
                        }
                        string endpoint_users = oktaEnv + "/api/v1/groups/" + groupItem.Id + "/users/";
                        string json_users = GetAll(endpoint_users, "GET");

                        string user_item  = "";
                        List<string> user_list = new List<string>();
                        dynamic users = JsonConvert.DeserializeObject(json_users);
                        foreach (var user in users)
                        {
                            user_item = user.profile.login.Value == null ? "" : user.profile.login.Value.ToString();
                            user_list.Add(user_item);
                        }
                        groupItem.Users = String.Join(". ", user_list.ToArray());
                    }
                    catch (Exception ex)
                    {
                        groupItem.Users = "";
                    }

                    oktaGroupList.Add(groupItem);
                }
            }
            catch (Exception ex)
            {
            }

            this.dgwOktaGroupList.DataSource = oktaGroupList;
            dgwOktaGroupList.Update();

            writeOutput(json.ToString());
        }

        private void metroBtnAddUser_Click(object sender, EventArgs e)
        {

            if (dgwOktaUserList == null || dgwOktaUserList.CurrentRow == null)
            {
                MessageBox.Show("Select user to be added", "User Selection"); return;
            }
            if (dgwOktaGroupList == null || dgwOktaGroupList.CurrentRow == null)
            {
                MessageBox.Show("Select group to add user", "Group Selection"); return;
            }

            int selUserId = dgwOktaUserList.CurrentRow.Index;
            string userID = dgwOktaUserList[0, selUserId].Value.ToString();

            int selGroupId = dgwOktaGroupList.CurrentRow.Index;
            string groupID = dgwOktaGroupList[0, selGroupId].Value.ToString();

            if (!string.IsNullOrEmpty(userID))
            {
                User selUser = new User();
                foreach (User userItem in oktaUserList)
                {
                    if (userItem.Id == userID)
                    {
                        selUser = userItem;
                    }
                }

                Group selGroup = new Group();
                foreach (Group groupItem in oktaGroupList)
                {
                    if (groupItem.Id == groupID)
                    {
                        selGroup = groupItem;
                    }
                }

                string endPoint = string.Concat(oktaEnv + "/api/v1/groups/" + groupID + "/users/" + userID);
                string user = DeleteUser(endPoint, "PUT");
            }
        
        }

        private void metroBtnDelUser_Click(object sender, EventArgs e)
        {
            if (dgwOktaUserList == null || dgwOktaUserList.CurrentRow == null)
            {
                MessageBox.Show("Select user to be removed", "User Selection"); return;
            }
            if (dgwOktaGroupList == null || dgwOktaGroupList.CurrentRow == null)
            {
                MessageBox.Show("Select group to remove user", "Group Selection"); return;
            }

            int selUserId = dgwOktaUserList.CurrentRow.Index;
            string userID = dgwOktaUserList[0, selUserId].Value.ToString();

            int selGroupId = dgwOktaGroupList.CurrentRow.Index;
            string groupID = dgwOktaGroupList[0, selGroupId].Value.ToString();

            if (!string.IsNullOrEmpty(userID))
            {
                User selUser = new User();
                foreach (User userItem in oktaUserList)
                {
                    if (userItem.Id == userID)
                    {
                        selUser = userItem;
                    }
                }

                Group selGroup = new Group();
                foreach (Group groupItem in oktaGroupList)
                {
                    if (groupItem.Id == groupID)
                    {
                        selGroup = groupItem;
                    }
                }

                string endPoint = string.Concat(oktaEnv + "/api/v1/groups/" + groupID + "/users/" + userID);
                string user = DeleteUser(endPoint, "DELETE");
            }
        }

        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
    
        }

        private async void metroBtnBrower_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm(this);

            BrowserLoginForm browserLoginForm = new BrowserLoginForm(this);
            browserLoginForm.StartPosition = FormStartPosition.CenterParent;
            browserLoginForm.ShowDialog();
        }
 
    }
}
