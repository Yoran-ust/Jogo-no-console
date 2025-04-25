using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace jogoNoConsole
{
    public class Jogador
    {
        public string Name { get; set; }    
        public string  Function { get; set; }
        public int Life { get; set; }
        public int Defense {  get; set; }
        public int Atack {  get; set; } 
        public int Xp { get; set; } = 0;
        public int Level { get; set; } = 1;

        public Jogador(string name, string function)
        {
            Name = name;
            Function = function;
            
            switch (function.ToLower())
            {
                case "guerreiro":
                    Life = 100;
                    Atack = 60;
                    Defense = 70;
                    break;

                case "mago":
                    Life = 50;
                    Atack = 80;
                    Defense = 60;
                    break;

                case "arqueiro":
                    Life = 60;
                    Atack = 60;
                    Defense = 55;
                    break;

                default:
                    Console.WriteLine("classe invalida!! nova classe funcionado... NECROMANTE");
                    Life = 300;
                    Atack = 100;
                    Defense = 50;
                    break;
            }

           
        } 
        public void ReceberDano(int ataqueInimigo)
        {
            Dano calculadora = new Dano();
            int danoRecebido = calculadora.CalcularDano(ataqueInimigo, this.Defense);
            this.Life -= danoRecebido;
            Console.WriteLine($"{Name} carambolas você recebeu {danoRecebido} de vida!! oia tua vida {Life}");

        }


    }
}
