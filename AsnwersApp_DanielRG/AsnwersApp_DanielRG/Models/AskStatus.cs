using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Net;
using RestSharp;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace AsnwersApp_DanielRG.Models
{
    public class AskStatus
    {
        [JsonIgnore]

        public RestRequest Request { get; set; }
        public AskStatus() { }
        public int AskStatusId { get; set; }
        public string AskStatus1 { get; set; } = null!;

        public async Task<List<AskStatus>> GetAskStatus()
        {
            try
            {

                string RouteSufix = string.Format("AskStatus");

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
                    var list = JsonConvert.DeserializeObject<List<AskStatus>>(response.Content);


                    return list;
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
