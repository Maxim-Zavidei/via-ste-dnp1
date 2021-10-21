using System;

namespace SpellOutTheNumber {
    class Program {
        static string SpellOutNumber(long x) {

            if (x == 0) return "zero";

            string[] numbers = {"", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"};
            string[] stuff = {"", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "seventeen", "eighteen", "nineteen"};
            string[] decimals = {"", "ten", "twenty", "thirthy", "forty", "fifty", "sixty", "seventy", "eighty", "nineghty"};
            string[] order = {"thousand", "million", "billion", ""};

            string toReturn = "";
            int magnitude = 0;

            while (x != 0) {
                string tmp = "";
                long lastDigit = x % 10;

                tmp = numbers[x % 10] + " ";
                if ((x /= 10) == 0) {
                    toReturn = tmp + toReturn;
                    break;
                }

                toReturn = (x % 10 == 1 ? stuff[lastDigit] + " " : decimals[x % 10] + " " + tmp) + toReturn;
                if ((x /= 10) == 0) break;

                toReturn = (numbers[x % 10] != "" ? numbers[x % 10] + " hundred " : "") + toReturn;
                if ((x /= 10) == 0) break;
                toReturn = order[magnitude++] + " " + toReturn;
            }
            return toReturn;
        }

        static void Main(string[] args) {
            Console.WriteLine(SpellOutNumber(909945));
        }
    }
}