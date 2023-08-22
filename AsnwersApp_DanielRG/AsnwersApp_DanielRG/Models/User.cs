using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace AsnwersApp_DanielRG.Models
{
    public class User
    {

        [JsonIgnore]

        public RestRequest Request { get; set; }

        public int UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string UserPassword { get; set; } = null!;
        public int StrikeCount { get; set; }
        public string BackUpEmail { get; set; } = null!;
        public string? JobDescription { get; set; }
        public int UserStatusId { get; set; }
        public int CountryId { get; set; }
        public int UserRoleId { get; set; }


        public async Task<User> GetUsuario()
        {
            try
            {

                string RouteSufix = string.Format("Users", 3);

                string URL = Services.APIConnection.ProductionPrefixURL + RouteSufix;

                RestClient client = new RestClient(URL);

                Request = new RestRequest(URL, Method.Get);


                Request.AddHeader(Services.APIConnection.ApiKeyName, Services.APIConnection.ApiKeyValue);
                Request.AddHeader(GlobalObject.ContentType, GlobalObject.MimeType);


                RestResponse response = await client.ExecuteAsync(Request);

                HttpStatusCode statusCode = response.StatusCode;

                if (statusCode == HttpStatusCode.OK)
                {
                    var list = JsonConvert.DeserializeObject<List<User>>(response.Content);

                    var item = list[0];
                    return item;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw;
            }
        }





    }
}
