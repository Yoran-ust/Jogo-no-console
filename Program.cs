
using jogoNoConsole;
using System;
using System.Threading;

class Program
{
    static Jogador jogador;
    static Organizacao organizacao = new Organizacao();
    static Random random = new Random();

    static void Main(string[] args)
    {
        bool game = true;

        while (game)
        {
            Console.WriteLine("==============D&D================");
            Console.WriteLine("1 - Novo jogo");
            Console.WriteLine("2 - Ver classes");
            Console.WriteLine("3 - Sair");
            Console.Write("\nEscolha: ");

            string op = Console.ReadLine();

            switch (op)
            {
                case "1":
                    CriarPersonagem();
                    MenuJogo();
                    break;
                case "2":
                    organizacao.MostrarClasses();
                    break;
                case "3":
                    game = false;
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }

            if (game)
            {
                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }

    static void MenuJogo()
    {
        bool emJogo = true;

        while (emJogo && jogador.Life > 0)
        {
            Console.Clear();
            Console.WriteLine($"=== {jogador.Name} (Nível {jogador.Level}) ===");
            Console.WriteLine("1 - Explorar");
            Console.WriteLine("2 - Ver Status");
            Console.WriteLine("3 - Voltar");
            Console.Write("\nEscolha: ");

            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    Explorar();
                    break;
                case "2":
                    organizacao.MostrarStatus(jogador);
                    Console.ReadKey();
                    break;
                case "3":
                    emJogo = false;
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        }
    }

    static void Explorar()
    {
        string[] locais = { "Floresta Sombria", "Caverna dos Ossos", "Ruínas Antigas" };
        string local = locais[random.Next(locais.Length)];

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine($"\nExplorando: {local}...");

        int evento = random.Next(1, 7);

        switch (evento)
        {
            case 1:
            case 2:
                string[] inimigos = { "Goblin", "Orc", "Esqueleto" };
                string inimigo = inimigos[random.Next(inimigos.Length)];
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nUm {inimigo} te atacou!");
                Combate(new Inimigo(inimigo, random.Next(15, 26), random.Next(30, 51)));
                break;

            case 3:
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nVocê encontrou um tesouro! (+25 XP)");
                jogador.Xp += 25;
                break;

            case 4:
                Console.ForegroundColor = ConsoleColor.DarkRed;
                int dano = random.Next(10, 21);
                Console.WriteLine($"\nArmadilha! Você sofreu {dano} de dano!");
                jogador.Life -= dano;
                break;

            case 5:
                Console.ForegroundColor = ConsoleColor.Green;
                int cura = random.Next(15, 31);
                jogador.Life = Math.Min(jogador.Life + cura,
                    jogador.Function == "Guerreiro" ? 100 :
                    jogador.Function == "Mago" ? 50 : 60);
                Console.WriteLine($"\nVocê descansou e recuperou {cura} de vida!");
                break;

            case 6:
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("\nNada interessante encontrado...");
                break;
        }

        VerificarNivel();
        Console.ResetColor();
        Console.WriteLine("\nPressione qualquer tecla para continuar...");
        Console.ReadKey();
    }

    static void Combate(Inimigo inimigo)
    {
        while (jogador.Life > 0 && inimigo.Life > 0)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"\n{jogador.Name}: {jogador.Life} HP");
            Console.WriteLine($"{inimigo.Name}: {inimigo.Life} HP");

            Console.WriteLine("\n1 - Atacar");
            Console.WriteLine("2 - Defender");
            Console.WriteLine("3 - Fugir");
            Console.Write("Escolha: ");

            string escolha = Console.ReadLine();

            switch (escolha)
            {
                case "1":
                    int danoJogador = new Dano().CalcularDano(jogador.Atack, inimigo.Life / 5);
                    inimigo.Life -= danoJogador;
                    Console.WriteLine($"\nVocê atacou causando {danoJogador} de dano!");
                    break;

                case "2":
                    int danoReduzido = new Dano().CalcularDano(inimigo.Atack, jogador.Defense) / 2;
                    jogador.Life -= danoReduzido;
                    Console.WriteLine($"\nVocê defendeu! Sofreu {danoReduzido} de dano!");
                    break;

                case "3":
                    if (random.Next(100) < 40)
                    {
                        Console.WriteLine("\nVocê fugiu!");
                        return;
                    }
                    Console.WriteLine("\nFalha ao fugir!");
                    break;

                default:
                    Console.WriteLine("\nAção inválida!");
                    break;
            }

            if (inimigo.Life > 0 && escolha != "2")
            {
                int danoInimigo = new Dano().CalcularDano(inimigo.Atack, jogador.Defense);
                jogador.Life -= danoInimigo;
                Console.WriteLine($"\n{inimigo.Name} te atacou causando {danoInimigo} de dano!");
            }
        }

        if (inimigo.Life <= 0)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            int xpGanho = inimigo.Atack + inimigo.Life / 2;
            Console.WriteLine($"\nVocê derrotou {inimigo.Name}! Ganhou {xpGanho} XP!");
            jogador.Xp += xpGanho;
        }
    }

    static void VerificarNivel()
    {
        int xpNecessario = jogador.Level * 100;

        if (jogador.Xp >= xpNecessario)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nPARABÉNS! VOCÊ SUBIU DE NÍVEL!");
            jogador.Level++;
            jogador.Xp -= xpNecessario;
            jogador.Atack += 5;
            jogador.Defense += 3;
            jogador.Life += 20;

            Console.WriteLine($"Agora você é nível {jogador.Level}!");
            Console.WriteLine("+5 Ataque, +3 Defesa, +20 Vida");
        }
    }

    static void CriarPersonagem()
    {
        Console.Write("\nEscolha um nome: ");
        string name = Console.ReadLine();

        Console.WriteLine("\nEscolha sua classe:");
        organizacao.MostrarClasses();
        Console.Write("\nOPÇÃO (1, 2, 3): ");

        string classe = Console.ReadLine() switch
        {
            "1" => "Guerreiro",
            "2" => "Arqueiro",
            "3" => "Mago",
            _ => "Necromante"
        };

        if (classe == "Necromante")
        {
            Console.Clear();
            for (int stage = 1; stage <= 5; stage++)
            {
                Console.Clear();
                DrawExplosion(stage);
                Thread.Sleep(200);
                Console.Beep(200 + (stage * 100), 150);
            }

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(@"
  _______ _______ ______  _______ _______ 
 |   |   |   _   |   __ \|     __|    ___|
 |       |       |      <|__     |    ___|
 |__|_|__|___|___|___|__|_______|_______|
            ");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(@"
  _____ _____ _____ _____ _____ _____ 
 |_   _|_   _|_   _|_   _|_   _|_   _|
   | |   | |   | |   | |   | |   | |  
   | |   | |   | |   | |   | |   | |  
   |_|   |_|   |_|   |_|   |_|   |_|  
            ");

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("\nUM TERROR SE ABATEU SOBRE A TERRA!");

            Thread.Sleep(3000);
            Console.ResetColor();
            Console.Clear();
        }

        jogador = new Jogador(name, classe);
        Console.ForegroundColor = classe == "Necromante" ? ConsoleColor.DarkMagenta : ConsoleColor.Green;
        Console.WriteLine($"\nPersonagem criado: {jogador.Name} o {jogador.Function}!");
        Console.ResetColor();
    }

    static void DrawExplosion(int stage)
    {
        string[] explosionFrames = {
            @"
               .-^-.
              /%%%%%\
             |%┌─┐%|
             |%└─┘%|
              \%%%/
               |_|
            ",
            @"
               .-^-.
              /#@#@#\
             |#┌┬┐#|
             |#└┴┘#|
              \###/
               |#|
            ",
            @"
               .-^-.
              /▓▒░▒▓\
             |▓┌┬┬┐▓|
             |▓└┴┴┘▓|
              \▓▓▓▓/
               |▓|
            ",
            @"
               .-^-.
              /█▄▀▄█\
             |█┌─┬─┐█|
             |█└─┴─┘█|
              \█████/
               |█|
            ",
            @"
               .-^-.
              /▓▓▓▓▓\
             |▓▓▓▓▓▓|
             |▓▓▓▓▓▓|
              \▓▓▓▓/
               |▓|
            "
        };

        Console.ForegroundColor = stage switch
        {
            1 => ConsoleColor.DarkYellow,
            2 => ConsoleColor.DarkRed,
            3 => ConsoleColor.Red,
            4 => ConsoleColor.Magenta,
            5 => ConsoleColor.White,
            _ => ConsoleColor.Gray
        };

        Console.WriteLine(explosionFrames[stage - 1]);
        Console.WriteLine("\nUM TERROR SE ABATEU SOBRE A TERRA!");
    }
}