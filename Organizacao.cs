using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jogoNoConsole
{
    public class Organizacao
    {
        public void MostrarStatus(Jogador jogador)
        {
            Console.WriteLine($"Nome: ({jogador.Name}) ");
            Console.WriteLine($"Clase: ({jogador.Function})");
            Console.WriteLine($"vida: ({jogador.Life})");
            Console.WriteLine($"defesa: ({jogador.Defense})");
            Console.WriteLine($"atack: ({jogador.Atack})");
            Console.WriteLine($"XP/Experiencia ({jogador.Xp})");
            Console.WriteLine($"level: ({jogador.Level})");
        }
        public  void MostrarClasses()
        {
            Console.WriteLine($"Gueirro status: (life - 100) (atack - 60) (defense - 70)");
            Console.WriteLine($"Mago status: (life - 50 ) (atack - 80 ) (defense - 30 )");
            Console.WriteLine($"Argqueiro status: (life - 60 ) (atack - 60) (defense - 55)");

        }
        public void Menu()
        {

        }
    }
}
