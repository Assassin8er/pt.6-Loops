using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace pt._6_Loops
{
    public class Die
    {
        private int _roll;
        private Random _generator;
        public Die()
        {
            _generator = new Random();
            _roll = _generator.Next(1, 7);
        }
        public Die(int roll)
        {
            _generator = new Random();
            if (roll < 1)
                _roll = 1;
            else if (roll > 6)
                _roll = 6;
            else
                _roll = roll;


        }

        public int Roll { get { return _roll; } }

        public override string ToString()
        {
            return _roll.ToString();
        }
        public void RollDie()
        {
            _roll = _generator.Next(1, 7);
        }

        public void DrawRoll()
        {
            if(_roll == 1)
            {
                Console.WriteLine();
                Console.WriteLine(" ____________");
                Console.WriteLine("|            |");
                Console.WriteLine("|            |");
                Console.WriteLine("|     ()     |");
                Console.WriteLine("|            |");
                Console.WriteLine("|            |");
                Console.WriteLine("|____________|");
                Console.WriteLine();
            }
            else if (_roll == 2)
            {
                Console.WriteLine();
                Console.WriteLine(" ____________");
                Console.WriteLine("| ()         |");
                Console.WriteLine("|            |");
                Console.WriteLine("|            |");
                Console.WriteLine("|            |");
                Console.WriteLine("|        ()  |");
                Console.WriteLine("|____________|");
                Console.WriteLine();
            }
            else if (_roll == 3)
            {
                Console.WriteLine();
                Console.WriteLine(" ____________");
                Console.WriteLine("| ()         |");
                Console.WriteLine("|            |");
                Console.WriteLine("|     ()     |");
                Console.WriteLine("|            |");
                Console.WriteLine("|         () |");
                Console.WriteLine("|____________|");
                Console.WriteLine();
            }
            else if (_roll == 4)
            {
                Console.WriteLine();
                Console.WriteLine(" ____________");
                Console.WriteLine("| ()      () |");
                Console.WriteLine("|            |");
                Console.WriteLine("|            |");
                Console.WriteLine("|            |");
                Console.WriteLine("| ()      () |");
                Console.WriteLine("|____________|");
                Console.WriteLine();
            }
            else if (_roll == 5)
            {
                Console.WriteLine();
                Console.WriteLine(" ____________");
                Console.WriteLine("| ()      () |");
                Console.WriteLine("|            |");
                Console.WriteLine("|     ()     |");
                Console.WriteLine("|            |");
                Console.WriteLine("| ()      () |");
                Console.WriteLine("|____________|");
                Console.WriteLine();
            }
            else if (_roll == 6)
            {
                Console.WriteLine();
                Console.WriteLine(" ____________");
                Console.WriteLine("| ()      () |");
                Console.WriteLine("|            |");
                Console.WriteLine("| ()      () |");
                Console.WriteLine("|            |");
                Console.WriteLine("| ()      () |");
                Console.WriteLine("|____________|");
                Console.WriteLine();
            }   
        }
    }
}
