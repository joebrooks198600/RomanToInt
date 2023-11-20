using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanToIntConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = 1904;
            string romanNumeral = IntToRoman(num);

            string NumberalRoman = "MMIVC";
            int Rnum = RomanToIntNum(NumberalRoman);

            Console.WriteLine($"{num} 轉換為羅馬數字: {romanNumeral}");
            Console.WriteLine($"{NumberalRoman } 轉換為整數數字: {Rnum }");
            Console.ReadLine();
        }
        static string IntToRoman(int num)
        {
            if (num < 1 || num > 3999)
            {
                throw new ArgumentException("輸入的數字應在1到3999之間");
            }
            /*
             I, V, X, L, C, D and M.
             1,5,10,50,100,500,1000
             */
            string[] romanSymbols = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
            int[] values = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };

            string result = "";

            for (int i = 0; i < values.Length; i++)
            {
                while (num >= values[i])
                {
                    result += romanSymbols[i]; //Get Roman
                    num -= values[i]; // Get Num
                }
            }

            return result;
        }
        static int RomanToIntNum(string str)
        {
            Dictionary<char, int> romanValues = new Dictionary<char, int>
            {
                {'M', 1000},
                {'D', 500},
                {'C', 100},
                {'L', 50},
                {'X', 10},
                {'V', 5},
                {'I', 1}
            };

            int resultNum = 0;

            //string NumberalRoman = "MCMIV";
            for (int i = 0; i < str.Length; i++)
            {
                if (i + 1 < str.Length && romanValues[str[i]] < romanValues[str[i + 1]])
                {
                    resultNum -= romanValues[str[i]];                    
                }
                else
                {
                    resultNum += romanValues[str[i]];                    
                }
            }
            return resultNum;
        }
    }
}
