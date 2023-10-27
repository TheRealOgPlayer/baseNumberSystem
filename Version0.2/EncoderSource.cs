//Made by therealogplayer
//Made on 10/26/2023
//Encoder

using System;

namespace DecoderOfBases
{
    class Program
    {
        static void Main(string[] args)
        {
            string exitCode = "";

            bool debug = false;
            Console.Write("Do You Want To Enable Debugging To See What Errors You Get?\nYes(Y) No(Anything Else)\n>> ");
            string debugInput = Console.ReadLine();
            if (debugInput.ToUpper() == "Y") debug = true;

            do
            {
                //Check
                try
                {
                    Console.Clear();

                    string symbols = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz!@#$%^&*()_+-=/[]{};?.<>";

                    long newBase = 0;

                    //Gets The Info To Convert
                    Console.Write("Enter The Original Base\n(Max Of {0} Because We Only Have So Many Symbols)\n>> ", symbols.Length);
                    long ogBase = Convert.ToInt64(Console.ReadLine());

                    Console.Write("Enter The Number To Convert Back To Decimal\n>> ");
                    string userInput = Console.ReadLine();

                    //Puts Every Digit From `userInput` Into An Array
                    char[] digitHolder = new char[userInput.Length];

                    for (int i = 0; i < digitHolder.Length; i++)
                    {
                        digitHolder[i] = userInput[i];
                    }

                    //Makes Every Digit A Base 10 So `A` Is `10` and `B` is `11`
                    long[] convertedNumbers = new long[digitHolder.Length];

                    for (int i = 0; i < convertedNumbers.Length; i++)
                    {
                        convertedNumbers[i] = symbols.IndexOf(Convert.ToString(digitHolder[i]));
                    }

                    //Multiplies The Symbole To The Base
                    long[] output = new long[convertedNumbers.Length];

                    for (int i = 0; i < convertedNumbers.Length; i++)
                    {
                        int reverseI = (convertedNumbers.Length - i) - 1;

                        newBase = Convert.ToInt64(Math.Pow(ogBase, reverseI));

                        if ((i + 1) == convertedNumbers.Length)
                        {
                            output[i] = convertedNumbers[i];
                        }
                        else
                        {
                            output[i] = newBase * convertedNumbers[i];
                        }
                        //Console.WriteLine("I: {0}, ogBase: {1}, convertedNumbers: {2}, output:{3}", i, newBase, convertedNumbers[i],output[i]);
                    }

                    //Adds Everthing In The Out Array And Displays The Output
                    long counter = 0;
                    for (int i = 0; i < output.Length; i++)
                    {
                        counter = counter + output[i];
                    }

                    Console.Write("\nResult: {0}\n", counter);

                }
                catch (Exception e)
                {
                    if (debug)
                    {
                        Console.WriteLine("\nOh No Something Failled, Perhaps The Number Is Too Big \nError {0}", e);
                    }
                    else 
                    {
                        Console.WriteLine("\nOh No Something Failled, Perhaps The Number Is Too Big");
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
