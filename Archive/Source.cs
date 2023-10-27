//Made By therealogplayer 
//On 10/25/2023

using System;

namespace BaseNumberSystemCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            string exitCode = "";

            do
            {
                Console.Clear();

                string symbols = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz!@#$%^&*()_+-=/[]{};?.<>";
                int powerI = 0;
                long baseInputPower = 0;

                //Gets The Base
                Console.Write("Enter What Base Number System You Want To Count In\n(Max Of {0} Because We Only Have So Many Symbols)\n>> ", symbols.Length);
                long baseInput = long.Parse(Console.ReadLine());

                //Gets The Number To Convert
                Console.Write("Give Me A Number In Decimal To Convert To Base {0}\n>> ", baseInput);
                long userInput = long.Parse(Console.ReadLine());

                //Check
                if (baseInput <= 1 || baseInput > symbols.Length || userInput > 249999999999999999)
                {
                    Console.WriteLine("\nThe Info You Have Entered Is Incorrect And Will Result In An Error\nPress Enter To Continue\n");
                    Console.ReadLine();
                    continue;
                }
                else 
                {
                    //Gets The Max Power We Will Need To Go To
                    do
                    {
                        baseInputPower = Convert.ToInt64(Math.Pow(baseInput, powerI++));
                    } while (baseInputPower <= userInput);

                    //Creates And Array To Hold The Values Of The Powers Of The Bases
                    long[] powers = new long[powerI];

                    //Puts The Powers In The `powers` array
                    for (int i = 0; i < powers.Length; i++)
                    {
                        powers[i] = Convert.ToInt64(Math.Pow(baseInput, i));
                    }

                    //Starts Mathing
                    long modUserinput = userInput;
                    char[] output = new char[powers.Length];


                    for (int i = 0; i < powers.Length; i++)
                    {
                        int reversI = (powers.Length - i) - 1;
                        long modInput = Convert.ToInt64(decimal.Round(modUserinput / powers[reversI], 0));

                        //Console.WriteLine("Powers[i]: {0} ModUserInput: {1} Result: {2}", powers[reversI], modUserinput, modInput);
                        modUserinput = Convert.ToInt64(decimal.Round(modUserinput - (modInput * powers[reversI]), 0));
                        output[i] = symbols[Convert.ToInt32(modInput)];
                    }

                    for (int i = 0; i < output.Length; i++)
                    {
                        Console.Write(output[i]);
                    }
                }
                //Exit Code
                Console.WriteLine("");
                Console.WriteLine("Type E To Exit\nEnter To Continue");
                exitCode = Console.ReadLine();


            } while (exitCode.ToUpper() != "E");
        }
    }
}
