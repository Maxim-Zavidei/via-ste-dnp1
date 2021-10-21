using System;
using System.Collections.Generic;

namespace CarAndPredicates {
    class Program {
		static void Main(string[] args) {

            List<Car> CarList = new List<Car>();

            CarList.Add(new Car("red", 3, 3, true));
            CarList.Add(new Car("blue", 1, 5, false));
            CarList.Add(new Car("red", 2, 4, false));
            CarList.Add(new Car("yellow", 2, 1, true));
            CarList.Add(new Car("cat", 4, 2, true));


            Console.WriteLine("Red cars:");
            CarList.FindAll(Car => Car.Color.Equals("red")).ForEach(Car => Console.WriteLine(Car.ToString()));
	
            Console.WriteLine("Red and Yellow cars:");
            CarList.FindAll(Car => Car.Color.Equals("red") || Car.Color.Equals("yellow")).ForEach(Car => Console.WriteLine(Car.ToString()));

            string[] ArrayOfColors = new string[] {"red", "yellow", "cat"};
            Console.WriteLine("Cars of colors of an array:");
            CarList.FindAll(Car => {
                foreach (string color in ArrayOfColors) {
                    if (Car.Color.Equals(color)) return true;
                }
                return false;
            }).ForEach(Car => Console.WriteLine(Car.ToString()));

            int size = 2;
            Console.WriteLine("Cars with engine size bigger then " + size + ":");
            CarList.FindAll(Car => Car.EngineSize > size).ForEach(Car => Console.WriteLine(Car.ToString()));

            int lower = 2;
            int upper = 4;
            Console.WriteLine("Cars with engine size bigger then " + lower + "and smaller then " + upper + ":");
            CarList.FindAll(Car => Car.EngineSize > lower && Car.EngineSize < upper).ForEach(Car => Console.WriteLine(Car.ToString()));

            int fuelEconomy = 5;
            Console.WriteLine("Cars with fuel economy lower then " + fuelEconomy + " :");
            CarList.FindAll(Car => Car.FuelEconomy < fuelEconomy).ForEach(Car => Console.WriteLine(Car.ToString()));

            int fuelEconomy2 = 5;
            Console.WriteLine("Cars with manual shift and fuel economy lower then " + fuelEconomy2 + " :");
            CarList.FindAll(Car => Car.FuelEconomy < fuelEconomy2).FindAll(Car => Car.IsManualShift).ForEach(Car => Console.WriteLine(Car.ToString()));
		}
	}
}