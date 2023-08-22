using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;

namespace AsnwersApp_DanielRG.Models
{
    public class UserDTO
    {

        [JsonIgnore]
        public RestRequest Request { get; set; }
        public int UserIdx { get; set; }
        public string UserNamex { get; set; } = null!;
        public string FirstNamex { get; set; } = null!;
        public string LastNamex { get; set; } = null!;
        public string? PhoneNumberx { get; set; }
        public string UserPasswordx { get; set; } = null!;
        public int StrikeCountx { get; set; }
        public string BackUpEmailx { get; set; } = null!;
        public string? JobDescriptionx { get; set; }
        public int UserStatusIdx { get; set; }
        public int CountryIdx { get; set; }
        public int UserRoleIdx { get; set; }
        public UserDTO() { }
        public async Task<UserDTO> GetUser(int id)
        {
            try
            {

                string RouteSufix = string.Format("Users/GetUserInfo?id={0}", id);

                string URL = Services.APIConnection.ProductionPrefixURL + RouteSufix;

                RestClient client = new RestClient(URL);

                Request = new RestRequest(URL, Method.Get);

                //agregamos la llave de seguridad, en este caso API KEY

                Request.AddHeader(Services.APIConnection.ApiKeyName, Services.APIConnection.ApiKeyValue);
                Request.AddHeader(GlobalObject.ContentType, GlobalObject.MimeType);

                //ejecutar la llamada al API

                RestResponse response = await client.ExecuteAsync(Request);

                HttpStatusCode statusCode = response.StatusCode;

                if (statusCode == HttpStatusCode.OK)
                {
                    var list = JsonConvert.DeserializeObject<List<UserDTO>>(response.Content);

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
