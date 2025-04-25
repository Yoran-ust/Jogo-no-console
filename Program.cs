using jogoNoConsole;
using System;
class Program
{
    static Jogador jogador;
    static Organizacao organizacao = new Organizacao();
    static void Main(string[] args)
    {
        bool ingame = true;
        
        while (ingame)
        {
            organizacao.MostrarClasses();
        }

    }
}