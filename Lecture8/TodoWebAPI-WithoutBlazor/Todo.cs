using System.ComponentModel.DataAnnotations;

namespace TodoWebAPI_WithoutBlazor {
    public class Todo {
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public int userId { get; set; }
        public int id { get; set; }
        [Required, MaxLength(128)]
        public string title { get; set; }
        public bool completed { get; set; }
    }
}