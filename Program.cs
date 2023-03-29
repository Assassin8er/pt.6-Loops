using System.Reflection.Emit;
using System;
using System.Transactions;

namespace pt._6_Loops
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random generator = new Random();
            int min, max, mid, ans1, count;
            bool done1 = false; bool done2 = false; bool done3 = false; bool done4 = false; bool done5 = false; bool done6 = false;
            min = 0; max = 0; ans1 = 0; count = 0;
            while (!done1)//Prompter
            {
                Console.WriteLine("Enter a Minimum:");
                if (int.TryParse(Console.ReadLine(), out min))
                {
                    Console.WriteLine("Enter a Maximum:");
                    if (int.TryParse(Console.ReadLine(), out max) && max > min)
                    {
                        Console.WriteLine($"Min:{min}, Max:{max}");
                        done1 = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Input!");
                }
            }
            max = max + 1;
            mid = generator.Next(min, max);
            while (!done2)
            {
                Console.WriteLine("Guess the number in-between the maximum and minimum(3 Attempts)");
                if (int.TryParse(Console.ReadLine(), out ans1) && ans1 >= min && ans1 <= max)
                {
                    if (ans1 == mid)
                    {
                        Console.WriteLine("Correct!");
                    }
                    else
                    {
                        Console.WriteLine("Wrong!!!!");
                        count++;
                        if (count == 3)
                        {
                            Console.WriteLine("GAME OVER!");
                            done2 = true;
                        }
                        else if (count == 2)
                            Console.WriteLine("Last Attempt!");
                        else if (count == 1)
                            Console.WriteLine("2 More Attempts!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Input!");
                }

            }

        }
    }
}