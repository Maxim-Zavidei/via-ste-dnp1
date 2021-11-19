using System.Text.Json.Serialization;

namespace Application.Models {
    public class User {
        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }
        [JsonPropertyName("lastName")]
        public string LastName { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonPropertyName("password")]
        public string Password { get; set; }
        [JsonPropertyName("securityLevel")]
        public int SecurityLevel { get; set; }
    }
}