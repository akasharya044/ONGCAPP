
using System.IO;
using System.Net;
using System.Text;
using System;

namespace CIPLV2.Tickets
{
    public static class TicketApi
    {
        public static string GET_TICKET_URL { get; set; }
        public static string UPDATE_TICKET_URL { get; set; }
        public static int IncidentId { get; set; }
        public static string action { get; set; }
        public static int starcount { get; set; }
        public static string Remarks { get; set; }
    }

    public static class SendData
    {
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
	}
}
