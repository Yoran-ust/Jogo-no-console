
namespace jogoNoConsole
{
    public class Organizacao
    {
        public void MostrarStatus(Jogador jogador)
        {
            Console.WriteLine($"Nome: {jogador.Name}");
            Console.WriteLine($"Classe: {jogador.Function}");
            Console.WriteLine($"Vida: {jogador.Life}");
            Console.WriteLine($"Ataque: {jogador.Atack}");
            Console.WriteLine($"Defesa: {jogador.Defense}");
            Console.WriteLine($"XP: {jogador.Xp}/{jogador.Level * 100}");
            Console.WriteLine($"Nível: {jogador.Level}");
        }

        public void MostrarClasses()
        {
            Console.WriteLine("1 - Guerreiro (Vida: 100, Ataque: 60, Defesa: 70)");
            Console.WriteLine("2 - Arqueiro (Vida: 60, Ataque: 60, Defesa: 55)");
            Console.WriteLine("3 - Mago (Vida: 50, Ataque: 80, Defesa: 30)");
        }
    }
}