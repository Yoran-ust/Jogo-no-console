using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jogoNoConsole
{
    public class Dano
    {
        public int CalcularDano(int atack, int defense)
        {
            Random rand = new Random();

            bool isCritico = rand.Next(0, 100) < 15;

            int danoBase = atack - defense;

            if(isCritico)
            {
                Console.WriteLine("É UM CRITICOOOOOOOO");
                danoBase *= 2;
            }

            return (danoBase > 0) ? danoBase : 1;
        }
    }
}
