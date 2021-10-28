using System.Collections.Generic;

namespace Application.Models {
    public class Family {
        public Family() {
            Adults = new List<Adult>();
        }
        public string StreetName { get; set; }
        public int HouseNumber { get; set; }
        public List<Adult> Adults { get; set; }
        public List<Child> Children { get; set; }
        public List<Pet> Pets { get; set; }
    }
}