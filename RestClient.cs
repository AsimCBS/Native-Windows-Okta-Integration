using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using Newtonsoft.Json;


public enum HttpVerb
{
    GET,
    POST,
    PUT,
    DELETE
}

namespace WindowsRestAPI
{
    public class RestClient
    {
        public string EndPoint { get; set; }
        public HttpVerb Method { get; set; }
        public string ContentType { get; set; }
        public string PostData { get; set; }
        public string Header { get; set; }
        public string AdminUsername { get; set; }
        public string AdminPassword { get; set; }
        public string OutType { get; set; }
        public string TenantKey { get; set; }
 

        public RestClient()
        {
            EndPoint = "";
            Method = HttpVerb.GET;
            ContentType = "text/xml";
            PostData = "";
        }
        public RestClient(string endpoint)
        {
            EndPoint = endpoint;
            Method = HttpVerb.GET;
            ContentType = "text/xml";
            PostData = "";
        }
        public RestClient(string endpoint, int num)
        {
            EndPoint = endpoint;
            Method = HttpVerb.POST;
            ContentType = "application/json";
            PostData = "";
        }
        public RestClient(string endpoint, HttpVerb method, string header)
        {
            EndPoint = endpoint;
            Method = method;
            ContentType = "text/xml";
            PostData = "";
            Header = header;
        }

        public RestClient(string endpoint, HttpVerb method, string postData, string header, string username, string password, string outtype, string tenantkey)
        {
            EndPoint = endpoint;
            Method = method;
            ContentType = "text/xml";
            PostData = postData;
            Header = header;
            AdminUsername = username;
            AdminPassword = password;
            OutType = outtype;
            TenantKey = tenantkey;
        }

        public string MakeRequest()
        {
            return MakeRequest("");
        }
        public string MakeRequestOkta()
        {
            ServicePointManager.DefaultConnectionLimit = 1000;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(EndPoint);

            request.Method = Method.ToString();
            //request.ContentLength = 0;
            //request.Method = HttpVerb.POST;
            request.ContentType = ContentType;
            //request.Headers.Add(HttpRequestHeader.Authorization, "SSWS 00BS85bHnNdGUh99YX2oBWWLjgFc_pXpcGyraMUBRw");
            //request.Headers[HttpRequestHeader.Authorization] = "SSWS 00BS85bHnNdGUh99YX2oBWWLjgFc_pXpcGyraMUBRw";
            request.Headers.Add("Authorization", "SSWS 00BS85bHnNdGUh99YX2oBWWLjgFc_pXpcGyraMUBRw");
            //request.Headers.Add("Accept", "application/json");
            //request.Headers.Add("Content-Type", "application/json");
            request.Accept = "application/json";
            request.ContentType = "application/json";

            PostData = "{ \"firstName\": \"Isaac\",\"lastName\": \"Brock\",\"email\": \"isaac.brock@example.com\",\"login\": \"isaac.brock@example.com\",\"mobilePhone\": \"555-415-1337\"}";
 
            if (!string.IsNullOrEmpty(PostData) && Method == HttpVerb.POST)
            {
                var encoding = new UTF8Encoding();
                var bytes = Encoding.GetEncoding("iso-8859-1").GetBytes(PostData);
                request.ContentLength = bytes.Length;

                using (var writeStream = request.GetRequestStream())
                {
                    writeStream.Write(bytes, 0, bytes.Length);
                }

            }

            try
            {
                //request.ReadWriteTimeout = 32000;
                //request.KeepAlive = true;
                System.Threading.Thread.Sleep(1000);
                var responseValue = string.Empty;
                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    // grab the response
                    using (var responseStream = response.GetResponseStream())
                    {
                        if (responseStream != null)
                        {
                            using (var reader = new StreamReader(responseStream))
                            {
                                responseValue = reader.ReadToEnd();
                                reader.Close();
                            }
                        }
                    }

                    return responseValue;
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string MakeRequest(string parameters)
        {
            ServicePointManager.DefaultConnectionLimit = 1000;
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(EndPoint + parameters);

            request.Method = Method.ToString();
            //request.ContentLength = 0;
            request.ContentType = ContentType;

            if (!string.IsNullOrEmpty(AdminUsername) && !string.IsNullOrEmpty(AdminPassword) && !string.IsNullOrEmpty(TenantKey))
            {
                request.Headers.Add(HttpRequestHeader.Authorization, Header);
                request.Credentials = new NetworkCredential(AdminUsername, AdminPassword);
                request.Accept = "application/" + OutType;
                request.Headers.Add("aw-tenant-code", TenantKey);
            }
           if (!string.IsNullOrEmpty(PostData) && Method == HttpVerb.POST)
            {
                var encoding = new UTF8Encoding();
                var bytes = Encoding.GetEncoding("iso-8859-1").GetBytes(PostData);
                request.ContentLength = bytes.Length;

                using (var writeStream = request.GetRequestStream())
                {
                    writeStream.Write(bytes, 0, bytes.Length);
                }

            }

           try
           {
               //request.ReadWriteTimeout = 32000;
               //request.KeepAlive = true;
               System.Threading.Thread.Sleep(1000);
               var responseValue = string.Empty;
               using (var response = (HttpWebResponse) request.GetResponse())
               { 
                    // grab the response
                    using (var responseStream = response.GetResponseStream())
                    {
                        if (responseStream != null)
                        {
                            using (var reader = new StreamReader(responseStream))
                            {
                                responseValue = reader.ReadToEnd();
                                reader.Close();
                            }
                        }
                    }

                    return responseValue;
                }
           }
           catch (Exception e)
           {
               return e.Message;
           }
         }


    } // class
}
