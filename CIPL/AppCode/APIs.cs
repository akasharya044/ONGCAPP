using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace CIPL.AppCode
{
    public static class APIs
    {
         //public static string HostURl = "http://localhost:5028/";
         //public static string HostURl = "http://65.2.100.52:1007/";

		public static string HostURl = "http://10.205.48.200:1007/";

        public static string ApiUrl = HostURl+"api/admin/login";
        public static string UserName { get; set; } = "";
        public static string Password { get; set; } = "";
        public static int StartParam { get; set; }

        public static string webGetMethod(string URL)
        {
            string jsonString = "";
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
                request.Method = "GET";
                request.Credentials = CredentialCache.DefaultCredentials;
                ((HttpWebRequest)request).UserAgent = "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 7.1; Trident/5.0)";
                request.Accept = "/";
                request.UseDefaultCredentials = true;
                request.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
                request.ContentType = "application/x-www-form-urlencoded";

                WebResponse response = request.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream());
                jsonString = sr.ReadToEnd();
                sr.Close();
            }
            catch (Exception ex)
            {

            }
            return jsonString;
        }
        public static string webPostMethod(string postData, string URL)
        {
            string responseFromServer = "";
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
                request.Method = "POST";
                request.Credentials = CredentialCache.DefaultCredentials;
                ((HttpWebRequest)request).UserAgent = "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 7.1; Trident/5.0)";
                request.Accept = "/";
                request.UseDefaultCredentials = true;
                request.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = byteArray.Length;
                Stream dataStream = request.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();

                WebResponse response = request.GetResponse();
                dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                responseFromServer = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();
                response.Close();
            }
            catch (Exception Ex)
            {
                //responseFromServer = Ex.Message;
            }
            return responseFromServer;
        }
        public static async Task EventLog(Events data)
        {
            var jsonData = JsonConvert.SerializeObject(data);
            using (HttpClient httpClient = new HttpClient())
            {
                var content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(ChatAPIs.Event_url, content);
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    Response responseModel = JsonConvert.DeserializeObject<Response>(responseBody);
                    if (responseModel != null)
                    {

                    }
                }
            }
        }

    }

    public static class ChatAPIs
    {
        public static string token { get; set; }
        public static string MfuserId { get; set; }
        public static string FirstName { get; set; } = string.Empty;
        public static int Location { get; set; }
        public static int catid { get; set; }
        public static int subcatid { get; set; }
        public static int areaid { get; set; }
        public static int questionId { get; set; }
        public static int deviceId { get; set; }
        public static string personDetailsId { get; set; }
        public static List<CategoriesData> catdata { get; set; }
        public static List<CategoriesData> subcatdata { get; set; }
        public static List<CategoriesData> areadata { get; set; }
        public static List<QuestionData> questiondata { get; set; }
        public static List<AnswerData> answerdata { get; set; }
        public static PersonRoot personDetails { get; set; } 
        public static DeviceRoot deviceDetails { get; set; }



        public static string Categories_Url = APIs.HostURl + "api/categories";

        public static string SubCategories_Url = APIs.HostURl + "api/subcategories/{categoriesid}?categoryId=";

        public static string Area_Url = APIs.HostURl + "api/area?categoryId=&SubcategoryId=";

        public static string Question_Url = APIs.HostURl + "api/subcategories/questions/text?text=";

        public static string Answer_Url = APIs.HostURl + "api/subcategories/";

        public static string ticketgenerate = APIs.HostURl + "api/tickets/raiseticket";

        public static string CIDevice_GetUrl = APIs.HostURl + "api/devicedetails/searchdevice/";

        public static string PersonDetail_GetUrl = APIs.HostURl + "api/persondetails/searchpersondetails/"; 
        
        public static string StarRating_postUrl = APIs.HostURl + "api/tickets/starrating";
        
        public static string Event_url = APIs.HostURl + "api/eventHistory";
        public static string Software_url = APIs.HostURl + "api/system/softwareinfo";
        public static string Hardware_url = APIs.HostURl + "api/system/hardwareinfo";


    }

}
