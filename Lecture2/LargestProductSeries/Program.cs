using System;

namespace LargestProductSeries {
    class Program {

        static string LargestGroupOfFour(string x) {
            int maxSoFar = 0;
            string maxGroupSoFar = "";

            int currentValue = 0;
            for (int i = 0; i < x.Length - 3; i += 3) {
                currentValue = Int32.Parse("" + x[i]) * Int32.Parse("" + x[i + 1]) * Int32.Parse("" + x[i + 2]) * Int32.Parse("" + x[i + 3]);
                if (currentValue > maxSoFar) {
                    maxSoFar = currentValue;
                    maxGroupSoFar = "" + x[i] + x[i + 1] + x[i + 2] + x[i + 3];
                }
            }
            return maxGroupSoFar;
        }

        static string FindGroup(string x, int l) {
            int maxSoFar = 0;
            string maxGroupSoFar = "";

            int currentValue = 1;
            for (int i = 0; i < x.Length - l - 1; i += l - 1) {
                currentValue = 1;
                for (int j = 0; j < l; j++) currentValue *= Int32.Parse("" + x[i + j]);
                if (currentValue > maxSoFar) {
                    maxSoFar = currentValue;
                    maxGroupSoFar = "";
                    for (int j = 0; j < l; j++) maxGroupSoFar = maxGroupSoFar + x[i + j];
                }
            }
            return maxGroupSoFar;
        }
		

        static void Main(string[] args) {
            Console.WriteLine(FindGroup("7316717653133062491922511967442657474235534919493496983520312774506326239578318016984801", 4));
        }
    }
}