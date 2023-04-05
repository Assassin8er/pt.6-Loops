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
            int min1 = 0, max1 = 0, mid, ans1, score = 0, wrong = 0, markamt = 0;
            int above70, num = 0, sum = 0, max2 = 0, min2 = 0, BetType = 0;
            bool done = false;
            bool done0 = false;
            bool done1 = false;
            double percentabove70 = 0, bet = 0, balance = 100.00, win = 0;
            Die dice1 = new Die();
            Die dice2 = new Die();
            while (!done)//Prompter
            {
                Console.WriteLine("Enter a minimum:");
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
            for (int i = 0; i < markamt; i++)
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
            for (int i = 1; i <= num; i += 2)
                sum += i;
            Console.WriteLine($"the sum of odd numbers is:{sum}");
            Console.WriteLine();
            done = false;
            Console.WriteLine("Enter a new max and min and I will generate 25 numbers within that range");// Random Numbers
            Console.WriteLine();
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
            Console.WriteLine();
            Random rand = new Random();
            for (int i = 0; i <= 25; i++)
            {
                int RandNum = rand.Next(min2, max2 + 1);
                Console.WriteLine(RandNum);
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Welcome To Dice Game!");
            while (!done0)
            {
                if (balance == 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("Looks like you cant play anymore! Come again soon!");
                    done0 = true;
                }
                done1 = false;
                Console.WriteLine("Please enter the # of the following Options");
                Console.WriteLine(" _______________________");
                Console.WriteLine("|1:Not Doubles          |");
                Console.WriteLine("|2:Doubles              |");
                Console.WriteLine("|3:EvenSum             |");
                Console.WriteLine("|4:OddSum              |");
                Console.WriteLine("|5:QUIT                 |");
                Console.WriteLine("|/\\/\\/\\/\\/\\/\\/\\/\\/\\/\\/\\\\|");
                if (int.TryParse(Console.ReadLine(), out BetType) && BetType >= 1 && BetType <= 5)
                {
                    if (BetType == 1)
                    {
                        while (!done1)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Welcome to \"Not Doubles\". In this game you win by rolling non matching die.");
                            Console.WriteLine($"You Currently have ${Math.Round(balance, 2)}");
                            Console.WriteLine("Enter Your Bet:");
                            if (double.TryParse(Console.ReadLine(), out bet) && bet <= balance && bet >= 0)
                            {
                                Console.WriteLine("Rolling...");
                                Thread.Sleep(1000);
                                dice1.RollDie();
                                dice2.RollDie();
                                dice1.DrawRoll();
                                dice2.DrawRoll();
                                if (dice1.Roll != dice2.Roll)
                                {
                                    win = bet / 2;
                                    Console.WriteLine($"You won :{Math.Round(win, 2)}$");
                                    balance = balance + win;
                                    done1 = true;
                                }
                                else
                                {
                                    Console.WriteLine($"You Lost:${Math.Round(bet, 2)}");
                                    Console.WriteLine("Better Luck Next Time!");
                                    Console.WriteLine();
                                    balance = balance - bet;
                                    done1 = true;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid Input! try again.");
                            }
                        }
                    }
                    else if (BetType == 2)
                    {
                        while (!done1)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Welcome to \"Doubles\". In this game you win by rolling DOUBLES.");
                            Console.WriteLine($"You Currently have ${Math.Round(balance, 2)}");
                            Console.WriteLine("Enter Your Bet:");
                            if (double.TryParse(Console.ReadLine(), out bet) && bet <= balance && bet >= 0)
                            {
                                Console.WriteLine("Rolling...");
                                Thread.Sleep(1000);
                                dice1.RollDie();
                                dice2.RollDie();
                                dice1.DrawRoll();
                                dice2.DrawRoll();
                                if (dice1.Roll == dice2.Roll)
                                {
                                    win = bet * 2;
                                    Console.WriteLine($"You won :{Math.Round(win, 2)}$");
                                    balance = balance + win;
                                    done1 = true;
                                }
                                else
                                {
                                    Console.WriteLine($"You Lost:${Math.Round(bet, 2)}");
                                    Console.WriteLine("Better Luck Next Time!");
                                    Console.WriteLine();
                                    balance = balance - bet;
                                    done1 = true;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid Input! try again.");
                            }
                        }
                    }
                    else if (BetType == 3)
                    {
                        while (!done1)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Welcome to \"EvenSum\". In this game you win by rolling an even number.");
                            Console.WriteLine($"You Currently have ${Math.Round(balance, 2)}");
                            Console.WriteLine("Enter Your Bet:");
                            if (double.TryParse(Console.ReadLine(), out bet) && bet <= balance && bet >= 0)
                            {
                                Console.WriteLine("Rolling...");
                                Thread.Sleep(1000);
                                dice1.RollDie();
                                dice2.RollDie();
                                int Sum = dice1.Roll + dice2.Roll;
                                dice1.DrawRoll();
                                dice2.DrawRoll();
                                if (Sum % 2 == 0)
                                {
                                    win = bet;
                                    Console.WriteLine($"You won :{Math.Round(win, 2)}$");
                                    balance = balance + win;
                                    done1 = true;
                                }
                                else
                                {
                                    Console.WriteLine($"You Lost:${Math.Round(bet, 2)}");
                                    Console.WriteLine("Better Luck Next Time!");
                                    Console.WriteLine();
                                    balance = balance - bet;
                                    done1 = true;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid Input! try again.");
                            }
                        }
                    }
                    else if (BetType == 4)
                    {
                        while (!done1)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Welcome to \"OddSum\". In this game you win by rolling an odd number.");
                            Console.WriteLine($"You Currently have ${Math.Round(balance, 2)}");
                            Console.WriteLine("Enter Your Bet:");
                            if (double.TryParse(Console.ReadLine(), out bet) && bet <= balance && bet >= 0)
                            {
                                Console.WriteLine("Rolling...");
                                Thread.Sleep(1000);
                                dice1.RollDie();
                                dice2.RollDie();
                                int Sum = dice1.Roll + dice2.Roll;
                                dice1.DrawRoll();
                                dice2.DrawRoll();
                                if (Sum % 2 == 0)
                                {
                                    Console.WriteLine($"You Lost:${Math.Round(bet, 2)}");
                                    Console.WriteLine("Better Luck Next Time!");
                                    Console.WriteLine();
                                    balance = balance - bet;
                                    done1 = true;
                                }
                                else
                                {
                                    win = bet;
                                    Console.WriteLine($"You won :{Math.Round(win, 2)}$");
                                    balance = balance + win;
                                    done1 = true;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid Input! try again.");
                            }
                        }
                    }
                    else if (BetType == 5)
                    {
                        Console.WriteLine("Have a good day!");
                        Thread.Sleep(200);
                        done0 = true;
                    }
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("INVALID INPUT!");
                }
            }
        }
    }
}
