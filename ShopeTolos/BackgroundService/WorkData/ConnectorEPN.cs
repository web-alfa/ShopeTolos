using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using ShopeTolos.BackgroundService.WorkData.Model;
using System;
using System.Collections.Generic;

namespace ShopeTolos.BackgroundService.WorkData
{
    public class ConnectorEPN
    {
        private IRestResponse response = null;
        private string content = null;
        private RestClient client = null;
        private RestRequest request = null;

        public ConnectorEPN()
        {
            client = new RestClient("http://api.epn.bz");
            request = new RestRequest("json", Method.POST);
        }

        public List<Categorie> GetCategories()
        {
            string req_data_2 = "{\"action\":\"list_categories\"}";
            string requests_to_process = "{\"cat\":" + req_data_2 + "}";
            string json = "{\"user_api_key\":\"7c16978b02e8175c92e0553252b7f357\",\"user_hash\":\"psw5xl287q2fpfkyc2osnef1t2dqopqh\",\"api_version\":\"2\",\"requests\":" + requests_to_process + "}";
            request.Parameters.Clear();
            request.AddJsonBody(json);
            response = client.Execute(request);
            content = response.Content;
            return GetData(content);
        }

        private List<Categorie> GetData(string respJsonStr)
        {
            var responseAppS = JObject.Parse(respJsonStr);
            var stepJson = responseAppS.GetValue("results").Value<JToken>("cat").Value<JToken>("categories").ToString();
            return JsonConvert.DeserializeObject<List<Categorie>>(stepJson);
        }

        public List<Offer> GetOffers(int idCati, ref int countTotalFound, int offset)
        {
            string req_data_1 = "{\"action\":\"search\",\"category\":\""+idCati.ToString()+ "\",\"offset\":\""+ offset + "\",\"limit\":\"1000\"}";
            string requests_to_process = "{\"offe\":" + req_data_1 + "}";
            string json = "{\"user_api_key\":\"7c16978b02e8175c92e0553252b7f357\",\"user_hash\":\"psw5xl287q2fpfkyc2osnef1t2dqopqh\",\"api_version\":\"2\",\"requests\":" + requests_to_process + "}";
            request.Parameters.Clear();
            request.AddJsonBody(json);
            response = client.Execute(request);
            content = response.Content;
            return GetData1(content, ref countTotalFound);
        }

        private List<Offer> GetData1(string respJsonStr, ref int countTotalFound)
        {
            var responseAppS = JObject.Parse(respJsonStr);
            var stepJson = responseAppS.GetValue("results").Value<JToken>("offe").Value<JToken>("offers").ToString();
            countTotalFound = GetCountTotalFound(respJsonStr);
            return JsonConvert.DeserializeObject<List<Offer>>(stepJson);
        }

        private int GetCountTotalFound(string content)
        {
            content = content.Remove(0, content.IndexOf("\"total_found\":") + "\"total_found\":".Length).Trim();
            content = content.Remove(content.IndexOf("\n"));
            return Convert.ToInt32(content);
        }
    }
}
