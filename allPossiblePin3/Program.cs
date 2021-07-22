using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace allPossiblePin3
{
    class Program
    {
        public static int[] collectingNumbers(string pin, string[,] pinpad)
        {
            List<int> allNum = new List<int>();
            for (int z = 0; z < pin.Length; z++)
            {
                allNum.Add(Convert.ToInt32(pin[z].ToString()));
            }
            for (int k = 0; k < pin.Length; k++)
            {
                for (int i = 0; i < pinpad.GetLength(0); i++)
                {
                    for (int j = 0; j < pinpad.GetLength(1); j++)
                    {
                        if (pinpad[i, j] == pin[k].ToString())
                        {
                            if (i > 0)
                            {
                                allNum.Add(Convert.ToInt32(pinpad[i - 1, j]));
                            }
                            if (j > 0)
                            {
                                allNum.Add(Convert.ToInt32(pinpad[i, j - 1]));
                            }
                            if (pinpad[i + 1, j] != "" && i + 1 < pinpad.GetLength(0))
                            {
                                allNum.Add(Convert.ToInt32(pinpad[i + 1, j]));
                            }
                            if (pinpad[i, j + 1] != "" && j + 1 < pinpad.GetLength(1))
                            {
                                allNum.Add(Convert.ToInt32(pinpad[i, j + 1]));
                            }
                        }
                    }
                }
            }
            int[] result = allNum.ToArray();
            return result;
        }
        public static string convert_To_Len_th_base(int n, int[] arr, int len, int L)
        {

            string s = "";
            for (int i = 0; i < L; i++)
            {
                s += arr[n % len];
                n /= len;
            }
            return s;
        }
        public static List<string> rePermut(int[] arr, int len, int L)
        {
            List<string> result = new List<string>();
            for (int i = 0; i < (int)Math.Pow(len, L); i++)
            {
                result.Add(convert_To_Len_th_base(i, arr, len, L));
            }
            HashSet<string> noDuplicate = new HashSet<string>();
            for (int i = 0; i < result.Count; i++)
            {
                noDuplicate.Add(result[i]);
            }
            string[] helper = noDuplicate.ToArray();
            result.Clear();
            for (int i = 0; i < helper.Length; i++)
            {
                result.Add(helper[i]);
            }
            return result;
        }
        public static List<string> GetPINs(string observed)
        {
            string[,] numbers = new string[4, 3];
            int counter = 1;
            for (int i = 0; i < numbers.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < numbers.GetLength(1); j++)
                {
                    numbers[i, j] = counter.ToString();
                    counter++;
                }
            }
            numbers[3, 0] = "";
            numbers[3, 1] = "0";
            numbers[3, 2] = "";
            int[] pinVariants = collectingNumbers(observed, numbers);
            List<string> result = new List<string>();
            return rePermut(pinVariants, pinVariants.Length, observed.Length);
        }
        static void Main(string[] args)
        {
            List<string> result = GetPINs("11");
            for (int i = 0; i < result.Count; i++)
            {
                Console.WriteLine(result[i]);
            }
            Console.ReadKey();
        }
    }
}
