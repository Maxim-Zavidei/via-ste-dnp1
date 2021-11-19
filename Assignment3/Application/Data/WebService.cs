using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Application.Models;

namespace Application.Data {
    public class WebService : IData, IUserService {
        private string uri = "http://localhost:5003";
        private readonly HttpClient client;

        public WebService() {
            client = new HttpClient();
        }

        public async Task<IList<Adult>> GetAdultsAsync(int? id, string name, int? age, string sex) {
            
            string finalUri = $"{uri}/Adults?";
            if (id != null) finalUri += $"adultId={id}&";
            if (name != null) finalUri += $"name={name}&";
            if (age != null) finalUri += $"age={age}&";
            if (sex != null) finalUri += $"sex={sex}&";

            finalUri = finalUri.Substring(0, finalUri.Length - 1);
            
            HttpResponseMessage responseMessage = await client.GetAsync(finalUri);

            if (!responseMessage.IsSuccessStatusCode)
                throw new Exception($@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");

            string result = await responseMessage.Content.ReadAsStringAsync();

            List<Adult> todos = JsonSerializer.Deserialize<List<Adult>>(result, new JsonSerializerOptions {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            return todos;
        }

        public async Task<Adult> AddAdultAsync(Adult adult) {
            string todoAsJson = JsonSerializer.Serialize(adult);

            StringContent content = new StringContent(todoAsJson, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(uri + "/Adults", content);
            if (!response.IsSuccessStatusCode)
                throw new Exception($@"Error: {response.StatusCode}, {response.ReasonPhrase}");
            return adult;
        }

        public async Task<User> ValidateUser(string UserName, string Password) {

            HttpResponseMessage responseMessage = await client.GetAsync(uri + $"/Users?username={UserName}&password={Password}");

            if (!responseMessage.IsSuccessStatusCode)
                throw new Exception($@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");

            string result = await responseMessage.Content.ReadAsStringAsync();
            Console.WriteLine(responseMessage.IsSuccessStatusCode);
            User user = JsonSerializer.Deserialize<User>(result, new JsonSerializerOptions());
            Console.WriteLine(user);
            return user;
        }

        public async Task RegisterUser(User user) {
            string todoAsJson = JsonSerializer.Serialize(user);

            StringContent content = new StringContent(todoAsJson, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(uri + "/Users", content);
            if (!response.IsSuccessStatusCode)
                throw new Exception($@"Error: {response.StatusCode}, {response.ReasonPhrase}");
        }
    }
}