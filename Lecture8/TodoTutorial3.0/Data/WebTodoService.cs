using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TodoTutorial3._0.Models;

namespace TodoTutorial3._0.Data {
    public class WebTodoService : ITodoData {
        private string uri = "http://jsonplaceholder.typicode.com";
        private readonly HttpClient client;

        public WebTodoService() {
            client = new HttpClient();
        }

        public async Task<IList<Todo>> GetTodosAsync(int userId, bool isCompleted) {
            HttpResponseMessage responseMessage = await client.GetAsync($"{uri}/Todos?userId={userId}&completed={isCompleted.ToString().ToLower()}");

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
            HttpResponseMessage response = await client.DeleteAsync("https://jsonplaceholder.typicode.com/Todos/1");
            if (!response.IsSuccessStatusCode)
                throw new Exception($@"Error: {response.StatusCode}, {response.ReasonPhrase}");
        }

        public async Task UpdateAsync(Todo todo) {
            string todoAsJson = JsonSerializer.Serialize(todo);
            HttpContent content = new StringContent(todoAsJson,
                Encoding.UTF8,
                "application/json");
            HttpResponseMessage response = await client.PatchAsync($"{uri}/todos/{todo.TodoId}", content);
            if (!response.IsSuccessStatusCode) {
                throw new Exception($"Error, {response.StatusCode}, {response.ReasonPhrase}");
            }
        }

        public async Task<Todo> GetAsync(int id) {
            HttpResponseMessage responseMessage = await client.GetAsync($"{uri}/todos/{id}");

            if (!responseMessage.IsSuccessStatusCode)
                throw new Exception($@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");

            string result = await responseMessage.Content.ReadAsStringAsync();

            Todo todo = JsonSerializer.Deserialize<Todo>(result, new JsonSerializerOptions {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            return todo;
        }
    }
}