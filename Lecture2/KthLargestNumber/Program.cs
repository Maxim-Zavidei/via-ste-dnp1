using System;

namespace KthLargestNumber {
    class Program {
        static int Largest(int[] ints, int k) {
            if (k > ints.Length) throw new Exception("K is bigger then the array size.");

            for (int i = 0; i < ints.Length; i++) {
                for (int j = 0; j < ints.Length - 1 - i; j++)
                    if (ints[j] > ints[j + 1]) {
                        int tmp = ints[j + 1];
                        ints[j + 1] = ints[j];
                        ints[j] = tmp;
                    }
            }

            return ints[ints.Length - k];
        }

        static void Main(string[] args) {
            Console.WriteLine(Largest(new int[] {6, 3, 5, 9, 1, 2}, 1));
        }
    }
}