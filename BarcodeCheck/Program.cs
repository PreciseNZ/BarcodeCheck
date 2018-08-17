using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarcodeLibrary;

namespace BarcodeCheck
{
    class Program
    {
        public static string characters;
        public static bool debug = false;
        static void Main(string[] args)
        {
            Console.WriteLine("--- Barcode Check ---");
            Console.WriteLine();
            if (args.Length == 0)
            {
                Console.WriteLine("Enter barcode:");
                characters = Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Using '"+args[0]+"' as barcode.");
                characters = args[0];
            }

            if (!string.IsNullOrEmpty(characters))
            {

                var checkDigit = Convert.ToInt16(characters.Substring(characters.Length - 1));
                Debug("CheckDigit to test " + checkDigit);
                var barcode = characters.Substring(0, characters.Length - 1);
                Debug("Shortened barcode " + barcode);
                var check = Barcode.CalculateCheckDigit(barcode);
                if (check == checkDigit)
                {
                    Console.WriteLine("Last digit confirmed as CheckDigit");
                }
                else
                {
                    check = Barcode.CalculateCheckDigit(characters);
                    Console.WriteLine("Last digit not CheckDigit.  Check digit calculated to be " + check);
                } 
            }
        }

        private static void Debug(string outputToWrite)
        {
            if (debug)
                Console.WriteLine(outputToWrite);
        }
    }
}
