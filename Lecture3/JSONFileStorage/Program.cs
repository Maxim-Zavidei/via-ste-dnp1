using System;
using System.Collections.Generic;

namespace JSONFileStorage {
    class Program {
        static void Main(string[] args) {
            Person p1 = new() {
                FirstName = "1",
                LastName = "2",
                Age = 65,
                Height = 35,
                isMarried = true,
                Sex = 'M',
                Hobbies = new string[] {"coding", "skiing", "climbing"}
            };

            Person p2 = new() {
                FirstName = "2",
                LastName = "3",
                Age = 42,
                Height = 54,
                isMarried = false,
                Sex = 'F',
                Hobbies = new string[] {"reading", "coding", "skiing", "climbing"}
            };

            Person p3 = new() {
                FirstName = "3",
                LastName = "4",
                Age = 35,
                Height = 12,
                isMarried = true,
                Sex = 'F',
                Hobbies = new string[] {"reading", "coding", "skiing", "climbing"}
            };

            List<Person> People = new();
            People.Add(p1);
            People.Add(p2);
            People.Add(p3);

            PersonPersistence.StoreObjects(People);
            Console.WriteLine(PersonPersistence.ReadJSON("example.json"));
        }
    }
}