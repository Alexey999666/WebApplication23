using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp23
{
    internal class APIMethod1
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        private static readonly string _apiBaseUrl = "http://localhost:7082/";

        public static T Get<T>(string endPoint)
        {
            var respone = _httpClient.GetAsync(_apiBaseUrl + endPoint).Result;
            if (!respone.IsSuccessStatusCode)
            {
                var error = respone.Content.ReadAsStringAsync().Result;
                throw new HttpRequestException($"Ошибка чтения данных\n{error}");
            }
            var content = respone.Content.ReadAsStringAsync().Result;
            var data = JsonConvert.DeserializeObject<T>(content);
            return data;
        }

        public static T GetId<T>(int id, string endPoint)
        {
            var response = _httpClient.GetAsync(_apiBaseUrl + endPoint + "/" + id.ToString()).Result;
            if (!response.IsSuccessStatusCode)
            {
                var error = response.Content.ReadAsStringAsync().Result;
                throw new HttpRequestException($"Ошибка чтения данных\n{error}");
            }
            var content = response.Content.ReadAsStringAsync().Result;
            var data = JsonConvert.DeserializeObject<T>(content);
            return data;
        }

        public static string Post<T>(T body, string endPoint)
        {
            var json = JsonConvert.SerializeObject(body);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = _httpClient.PostAsync(_apiBaseUrl + endPoint, content).Result;
            if (!response.IsSuccessStatusCode)
            {
                var error = response.Content.ReadAsStringAsync().Result;
                throw new HttpRequestException($"Ошибка добавления данных\n{error}");
            }
            return response.ToString();
        }

        public static string Put<T>(T body, int id, string endPoint)
        {
            var json = JsonConvert.SerializeObject(body);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = _httpClient.PutAsync(_apiBaseUrl + endPoint + "/" + id.ToString(), content).Result;
            if (!response.IsSuccessStatusCode)
            {
                var error = response.Content.ReadAsStringAsync().Result;
                throw new HttpRequestException($"Ошибка изменения данных\n{error}");
            }
            return response.ToString();
        }

        public static string Delete(int id, string endPoint)
        {
            var response = _httpClient.DeleteAsync(_apiBaseUrl + endPoint + "/" + id.ToString()).Result;
            if (!response.IsSuccessStatusCode)
            {
                var error = response.Content.ReadAsStringAsync().Result;
                throw new HttpRequestException($"Ошибка удаления данных\n{error}");
            }
            return response.ToString();
        }
    }
}
