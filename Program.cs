using System.Reflection.Emit;
using System;
using System.Transactions;
using System.Runtime.InteropServices;
using static System.Formats.Asn1.AsnWriter;
using System.Net.Sockets;

namespace pt._6_Loops
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random generator = new Random();
            int min, max, mid, ans1, score, wrong, marknum, i, above70, total;
            bool done1 = false; bool done2 = false; bool done3 = false; bool done4 = false; bool done5 = false; bool done6 = false;
            double percentabove70 = 0;
            min = 0; max = 0; ans1 = 0; score = 0; wrong = 0; marknum = 0;
            while (!done1)//Prompter
            {
                Console.WriteLine("Enter a Minimum:");
                if (int.TryParse(Console.ReadLine(), out min))
                {
                    done1 = true;
                }
                else
                    Console.WriteLine("Invalid Input!");
            }
            while (!done2)
            {
                Console.WriteLine("Enter a Maximum");
                if (int.TryParse(Console.ReadLine(), out max) && max > min)
                {
                    done2 = true;
                }
                else
                    Console.WriteLine("Invalid Input!");
            }
            max = max + 1;
            mid = generator.Next(min, max);
            while (!done3)
            {
                Console.WriteLine("Guess the number in range of the maximum and minimum(3 Attempts)");
                if (int.TryParse(Console.ReadLine(), out ans1) && ans1 >= min && ans1 <= max)
                {
                    if (ans1 == mid)
                    {
                        Console.WriteLine("Correct!");
                        done3 = true;
                    }
                    else
                    {
                        Console.WriteLine("Wrong!!!!");
                        wrong++;
                        if (wrong == 3)
                        {
                            Console.WriteLine("GAME OVER!");
                            done3 = true;
                        }
                        else if (wrong == 2)
                            Console.WriteLine("Last Attempt!");
                        else if (wrong == 1)
                            Console.WriteLine("2 More Attempts!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Input!");
                }
            }
            Console.WriteLine();
            while (!done4)// Percent Passing Program
            {
                Console.WriteLine("Enter number of marks to be inputted(3 Minimum):");
                if (int.TryParse(Console.ReadLine(), out marknum)&& marknum >= 3)
                    done4 = true;
                else
                    Console.WriteLine("Invaild Input! Enter a number eqaul to/greater than 3.");
            }

            above70 = 0;
            for (i = 0; i < marknum; i++) 
            {
                while (!done5)
                {
                    Console.WriteLine($"enter Mark {i + 1}:");
                    if (int.TryParse(Console.ReadLine(), out score)&& score >= 0 && score <= 100)
                        done5 = true;
                    else
                        Console.WriteLine("Invalid Input!");
                }
                if (score >= 70)
                    above70++;
                done5 = false;
            }
            Console.WriteLine();
            Console.WriteLine("Calculating...");
            Thread.Sleep(400);
            Console.WriteLine();
            Console.WriteLine();
            percentabove70 = (double)above70 / marknum * 100;

            Console.WriteLine($"Scores above 70 are {above70}, Percent of scores above 70 is {Math.Round(percentabove70, 2)}%.");
        }
    }
}