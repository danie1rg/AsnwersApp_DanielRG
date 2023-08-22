using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Net;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace AsnwersApp_DanielRG.Models
{
    public class Ask
    {
        public Ask()
        {
            IsStrike = false;
        }
        [JsonIgnore]

        public RestRequest Request { get; set; }
        
        public long AskId { get; set; }
        public DateTime Date { get; set; }
        public string Ask1 { get; set; } = null!;
        public int UserId { get; set; }
        public int AskStatusId { get; set; }
        public bool? IsStrike { get; set; }
        public string? ImageUrl { get; set; }
        public string? AskDetail { get; set; }

        //public virtual AskStatus AskStatus { get; set; } = null!;
        //public virtual User User { get; set; } = null!;

        public async Task<bool> AddAskAsync()
        {
            try
            {
                string RouteSufix = string.Format("Asks");

                string URL = Services.APIConnection.ProductionPrefixURL + RouteSufix;

                RestClient client = new RestClient(URL);

                Request = new RestRequest(URL, Method.Post);


                Request.AddHeader(Services.APIConnection.ApiKeyName, Services.APIConnection.ApiKeyValue);

                Request.AddHeader(GlobalObject.ContentType, GlobalObject.MimeType);


                string SerializedModel = JsonConvert.SerializeObject(this);

                Request.AddBody(SerializedModel, GlobalObject.MimeType);


                RestResponse response = await client.ExecuteAsync(Request);


                HttpStatusCode statusCode = response.StatusCode;

                if (statusCode == HttpStatusCode.Created)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw;
            }

        }

        public async Task<ObservableCollection<Ask>> GetAsksByAskStatus()
        {
            try
            {

                string RouteSufix = string.Format("Asks", this);

                string URL = Services.APIConnection.ProductionPrefixURL + RouteSufix;

                RestClient client = new RestClient(URL);

                Request = new RestRequest(URL, Method.Get);

                Request.AddHeader(Services.APIConnection.ApiKeyName, Services.APIConnection.ApiKeyValue);
                Request.AddHeader(GlobalObject.ContentType, GlobalObject.MimeType);


                RestResponse response = await client.ExecuteAsync(Request);

                HttpStatusCode statusCode = response.StatusCode;

                if (statusCode == HttpStatusCode.OK)
                {
                    var list = JsonConvert.DeserializeObject<ObservableCollection<Ask>>(response.Content);

                    
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
