using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TodoWebAPI_WithoutBlazor {
    class Program {
        
        private string uri = "http://jsonplaceholder.typicode.com";
        private readonly HttpClient client;
        
        public Program() {
            client = new HttpClient();
        }
        
        public async Task<IList<Todo>> GetTodosAsync(int? userId, int? id, bool? isCompleted) {

            string finalUri = $"{uri}/Todos?";
            if (userId != null) finalUri += $"userId={userId}&";
            if (id != null) finalUri += $"id={id}&";
            if (isCompleted != null) finalUri += $"completed={isCompleted.ToString().ToLower()}&";

            finalUri = finalUri.Substring(0, finalUri.Length - 1);
            Console.WriteLine(finalUri);

            HttpResponseMessage responseMessage = await client.GetAsync(finalUri);

            if (!responseMessage.IsSuccessStatusCode)
                throw new Exception($@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");

            string result = await responseMessage.Content.ReadAsStringAsync();

            List<Todo> todos = JsonSerializer.Deserialize<List<Todo>>(result, new JsonSerializerOptions {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            return todos;
        }
        
        public async Task AddTodoAsync(Todo todo) {
            string todoAsJson = JsonSerializer.Serialize(todo);

            StringContent content = new StringContent(todoAsJson, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(uri + "/Todos", content);
            if (!response.IsSuccessStatusCode)
                throw new Exception($@"Error: {response.StatusCode}, {response.ReasonPhrase}");
        }

        public async Task RemoveTodoAsync(int todoId) {
            HttpResponseMessage response = await client.DeleteAsync($"https://jsonplaceholder.typicode.com/Todos?id={todoId}");
            if (!response.IsSuccessStatusCode)
                throw new Exception($@"Error: {response.StatusCode}, {response.ReasonPhrase}");
        }
        
        static async Task Main(string[] args) {
            var program = new Program();

            program.GetTodosAsync(null, null, null);
            program.GetTodosAsync(null, null, false);
            program.GetTodosAsync(1, null, true);
            
            program.AddTodoAsync(new Todo() {
                completed = true,
                id = 5,
                title = "hello",
                userId = 8
            });
            program.RemoveTodoAsync(5);
        }
    }
}