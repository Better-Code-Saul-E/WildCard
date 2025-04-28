using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wildcard
{
    static class Utility
    {
        public static Random RandomNumber = new Random();
        public static int GetRandomNumber(int max) => RandomNumber.Next(max); 
        public static void Pause(){ 
            Print("\nPress any key to continue");
            Console.ReadKey();
        }
        public static void Clear() => Console.Clear();
        public static string GetInput() => Console.ReadLine().Trim();
        public static void Print(string message) => Console.WriteLine(message);
        public static void PrintLine() => Console.WriteLine(Environment.NewLine);


        // make this dynamic accept int for border length
        public static void PrintBorder() => Print("============================================");
    }
}
