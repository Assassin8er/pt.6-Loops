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
            int min1 = 0, max1= 0, mid, ans1, score = 0, wrong = 0, markamt = 0, i, above70, num = 0, sum = 0, max2 = 0, min2 = 0;
            bool done = false;
            double percentabove70 = 0;
            while (!done)//Prompter
            {
                Console.WriteLine("Enter a min1imum:");
                if (int.TryParse(Console.ReadLine(), out min1))
                {
                    done = true;
                }
                else
                    Console.WriteLine("Invalid Input!");
            }
            done = false;
            while (!done)
            {
                Console.WriteLine("Enter a Maximum");
                if (int.TryParse(Console.ReadLine(), out max1) && max1 > min1)
                {
                    done = true;
                }
                else
                    Console.WriteLine("Invalid Input!");
            }
            max1 = max1 + 1;
            mid = generator.Next(min1, max1);
            done = false;
            while (!done)
            {
                Console.WriteLine("Guess the number in range of the maximum and minimum(3 Attempts)");
                if (int.TryParse(Console.ReadLine(), out ans1) && ans1 >= min1 && ans1 <= max1)
                {
                    if (ans1 == mid)
                    {
                        Console.WriteLine("Correct!");
                        done = true;
                    }
                    else
                    {
                        Console.WriteLine("Wrong!!!!");
                        wrong++;
                        if (wrong == 3)
                        {
                            Console.WriteLine("GAME OVER!");
                            done = true;
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
            done = false;
            while (!done)// Percent Passing Program
            {
                Console.WriteLine("Enter number of marks to be inputted(3 Minimum):");
                if (int.TryParse(Console.ReadLine(), out markamt) && markamt >= 3)
                    done = true;
                else
                    Console.WriteLine("Invaild Input! Enter a number eqaul to/greater than 3.");
            }
            done = false;
            above70 = 0;
            for (i = 0; i < markamt; i++)
            {
                while (!done)
                {
                    Console.WriteLine($"enter Mark {i + 1}:");
                    if (int.TryParse(Console.ReadLine(), out score) && score >= 0 && score <= 100)
                        done = true;
                    else
                        Console.WriteLine("Invalid Input!");
                }
                if (score >= 70)
                    above70++;
                done = false;
            }
            done = false;
            Console.WriteLine();
            Console.WriteLine("Calculating...");
            Thread.Sleep(400);
            Console.WriteLine();
            Console.WriteLine();
            percentabove70 = (double)above70 / markamt * 100;
            Console.WriteLine($"Scores above 70 are {above70}, Percent of scores above 70 is {Math.Round(percentabove70, 2)}%.");
            Console.WriteLine();
            Console.WriteLine("This program adds up all odd numbers from 1 to your number entered.");
            while (!done)// OddSum Program
            {
                Console.WriteLine("Enter a Number(Maximum is 10,000)");
                if (int.TryParse(Console.ReadLine(), out num) && num >= 1 && num <= 10000)
                    done = true;
                else
                    Console.WriteLine("Invalid Input!");
            }
            for (i = 1; i <= num; i += 2)
                sum += i;
            Console.WriteLine($"the sum of odd numbers is:{sum}");
            Console.WriteLine();
            done = false;
            Console.WriteLine("Enter a new max and min and I will generate 25 numbers within that range");// Random Numbers
            while (!done)
            {
                Console.WriteLine("Enter a Minimum:");
                if (int.TryParse(Console.ReadLine(), out min2))
                    done = true;
                else
                    Console.WriteLine("Invalid Input!");
            }
            done = false;
            while (!done)
            {
                Console.WriteLine("Enter a Maximum");
                if (int.TryParse(Console.ReadLine(), out max2) && max2 > min2)
                    done = true;
                else
                    Console.WriteLine("Invalid Input!");
            }
            Random rand = new Random();
            for (i = 0;i <= 25 ; i++)
            {
                int RandNum = rand.Next(min2, max2 + 1);
                Console.WriteLine(RandNum);
            }
        }
    }
}