using System;
using Newtonsoft.Json;

namespace CIPL.AppCode
{
	public class CommonResponse
	{
		public Int32 code { get; set; }
		public string message { get; set; }
		public Int32 status { get; set; }
	}
	public class RegistrationResponse : CommonResponse
	{
		public SystemRegistration data { get; set; }
	}
	public class SystemRegistration
	{
		public string systemid { set; get; }
		public string ipaddress { set; get; }
		public string status { set; get; }
		public string mac_address { set; get; }
		public string updated_at { set; get; }
		public string created_at { set; get; }
		public string _id { set; get; }
		public Int32 next_request { get; set; }
	}
    public class Response
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
    public class CategoriesData
	{
		public int id { set; get; }
		public string entitytype { set; get; }
		public string displaylabel { set; get; }
	}
	public class QuestionData
    {
		public int Id { get; set; }
		public int MfAreaId { get; set; }
		public int categoryId { get; set; }
		public int subCategoryId { get; set; }
		public string Question { get; set; }
	}
    public class AnswerData
    {
		public int Id { get; set; }
		public string Answer { get; set; }
		public int QuestionId { get; set; }
	}
    public class AdminUsersDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public string MfuserId { get; set; }
        public int Location { get; set; }
        public string FirstName { get; set; }


    }

    public class AntivirusSingleData
    {
		public string AntivirusProduct { get; set; }//:  "Windows Defender",
		public string AntivirusStatus { get; set; }//:  397568;

    }

public class AntivirusData
    {
        [JsonProperty("AntivirusProduct")]
        public string[] AntivirusProduct { get; set; }

        [JsonProperty("AntivirusStatus")]
        public int[] AntivirusStatus { get; set; }
    }
}
