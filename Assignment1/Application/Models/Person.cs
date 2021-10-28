using System.ComponentModel.DataAnnotations;

namespace Application.Models {
    public class Person {
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger then {1}")]
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string FirstName { get; set; }
        [Required, MaxLength(100)]
        public string LastName { get; set; }
        public string HairColor { get; set; }
        public string EyeColor { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a positive age")]
        public int Age { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a positive weight")] 
        public float Weight { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a positive height")]
        public int Height { get; set; }
        public string Sex { get; set; }
    }
}