using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TopSappAPIClient.Helpers {
    public class ConsumingApiHelper {
        private HttpClient _client;

        public ConsumingApiHelper(string baseAdress) {
            var httpClientHandler = new HttpClientHandler {
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; }
            };
            _client = new HttpClient(httpClientHandler) {
                BaseAddress = new Uri(baseAdress)
            };

            _client.Timeout = TimeSpan.FromMinutes(30);
            var mediaType = new MediaTypeWithQualityHeaderValue("application/json");
            _client.DefaultRequestHeaders.Accept.Add(mediaType);
        }


        public (T result, string statusCode, string message) Get<T>(string endPoint) {
            return GetAssync<T>(endPoint).Result;
        }

        public async Task<(T result, string statusCode, string message)> GetAssync<T>(string endPoint) {
            var response = await _client.GetAsync($"{_client.BaseAddress}{endPoint}");
            return DeserializeResponse<T>(response);
        }

        public (TResult result, string statusCode, string message) Post<T, TResult>(string endPoint, T obj) {
            var response = _client.PostAsync($"{_client.BaseAddress}{endPoint}", ObjectToHttpContent(obj)).Result;
            return DeserializeResponse<TResult>(response);
        }

        public async Task<(TResult result, string statusCode, string message)> PostWithFormDataAsync<TResult>(string endPoint, FormUrlEncodedContent obj) {
            var response = await _client.PostAsync($"{_client.BaseAddress}{endPoint}", obj);
            return DeserializeResponse<TResult>(response);
        }

        public (TResult result, string statusCode, string message) Put<T, TResult>(string endPoint, T obj) {
            var response = _client.PutAsync($"{_client.BaseAddress}{endPoint}", ObjectToHttpContent(obj)).Result;
            return DeserializeResponse<TResult>(response);
        }

        public (bool result, string message) Delete(string endPoint) {
            var response = _client.DeleteAsync($"{_client.BaseAddress}{endPoint}").Result;
            var responseContent = response.Content.ReadAsStringAsync().Result;
            if (response.IsSuccessStatusCode) {
                return (true, responseContent);
            } else {
                return (false, responseContent);
            }
        }

        public (T result, string statusCode, string message) DeserializeResponse<T>(HttpResponseMessage response) {
            var responseContent = response.Content.ReadAsStringAsync().Result;
            var statusCode = response.StatusCode.ToString();
            try {
                if (response.IsSuccessStatusCode) {
                    return (JsonConvert.DeserializeObject<T>(responseContent), statusCode, responseContent);
                } else {
                    return (default(T), statusCode, responseContent);
                }
            } catch (Exception e) {
                return (default(T), statusCode, responseContent);
            }

        }

        public HttpContent ObjectToHttpContent(object obj) {
            if (obj.GetType().IsPrimitive || obj.GetType() == typeof(string) || obj.GetType() == typeof(decimal)) {
                return new StringContent(obj.ToString());
            }
            string json = JsonConvert.SerializeObject(obj, Formatting.Indented);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }

    }
}
