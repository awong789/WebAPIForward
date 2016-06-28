using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPIForward.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly string requestRoute = "/v2/feeds/295611432";
        private readonly string host = "api.xively.com";
        private readonly string apiKey = "8RLV5CvPiBRfFUs7y223S71bPTadYm8XKsHBHmNMDPWrKZr4";
        private readonly RestClient restClient;

        public ValuesController()
        {
            restClient = new RestClient(string.Format("http://{0}", host));
        }
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
   
        public string Get(string longitude, string latitude)
        {
            var modelRequest = new Models.DataItem()
            {
                longitude = longitude,
                latitude = latitude
            };

            List<Models.DataStream> lDataStream = new List<Models.DataStream>();
            lDataStream.Add(new Models.DataStream { id = "longitude", current_value = longitude });
            lDataStream.Add(new Models.DataStream { id = "latitude", current_value = latitude });

            Models.SensorRequest sRequest = new Models.SensorRequest() {
                datastreams = lDataStream
            };

            var strJsonContent = JsonConvert.SerializeObject(sRequest, Formatting.Indented, new JsonSerializerSettings { });
            var request = new RestRequest(requestRoute, Method.PUT);
            request.AddHeader("X-ApiKey", apiKey);
            request.AddParameter("application/json", strJsonContent, ParameterType.RequestBody);

            var result = restClient.Execute<object>(request);
            
            return result.StatusCode.ToString();
            
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
