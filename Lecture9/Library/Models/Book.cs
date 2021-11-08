using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace Library.Models {
    public class Book {
        [Key]
        public int ISBN { get; set; }
        [Required, MaxLength(300)]
        public string Title { get; set; }
        [Required]
        public int TotalPages { get; set; }
        [Required]
        public DateTime PublishDate { get; set; }
        [Required]
        public Genre Genre { get; set; }
        [Required]
        public Author Author { get; set; }
        
        public override string ToString() {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions {
                WriteIndented = true
            });
        }
    }
}