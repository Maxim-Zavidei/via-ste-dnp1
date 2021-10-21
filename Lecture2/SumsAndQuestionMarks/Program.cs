using System;

namespace SumsAndQuestionMarks {
    class Program {
        static string GenerateRandomString() {
            string toReturn = "";
            for (int i = 0; i < 20; i++) {
                switch (new Random().Next(0, 3)) {
                    case 0:
                        toReturn += (char) new Random().Next(48, 58);
                        break;
                    case 1:
                        toReturn += "?";
                        break;
                    case 2:
                        toReturn += (char) new Random().Next(97, 123);
                        break;
                }
            }

            return toReturn;
        }

        static int FindSums(string s) {
            int sum = 0;
            for (int i = 0; i < s.Length; i++)
                if (47 < s[i] && s[i] < 58)
                    sum += s[i] - 48;
            return sum;
        }

        static void Main(string[] args) {
            string s = GenerateRandomString();
            Console.WriteLine(s);
            Console.WriteLine(FindSums(s));
        }
    }
}