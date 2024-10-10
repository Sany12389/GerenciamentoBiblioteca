using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Digite seu nome: ");
        string nomePessoa = Console.ReadLine();
        bool sair = false;
        // Criando o catálogo de livros
        List<Livro> catalogoLivros = new List<Livro>
        {
            new Livro("Educação de Surdos olhares multidisciplicares", "Welbert Vinícius de Souza Sansão", "Dialética"),
            new Livro("Língua de Sinais Brasileira", "Ronice Müller de Quadro e Lodenir Becker Karnopp", "Estudo Linguística"),
            new Livro("Língu de Herança", "Ronice Müller de Quadro", "Linguística"),
            new Livro("A Saga do Surdo", "Maria Alice Floriano Franco", "Fábula"),
            new Livro("Três Patetas Surdos", "Lucas Ramon", "Qaudrinho"),
            new Livro("Tibi e Joca", "Claudio Bisol", "Literatura Surda"),
            new Livro("A Cigarra surda e as formigas", "Boldo: Oliveira", "Literatura Surda"),
            new Livro("Cinderala Surda", "Strobel", "Literatura surda"),
            new Livro("Repunzel Surda", "Strobel", "Literatura"),
            new Livro("Patinho Surdo", "Rosa e Karnopp", "Literatura Surda")
        };
        // Dicionário para armazenar os livros pegados por cada usuário
        Dictionary<string, List<Livro>> livrosEmprestados = new Dictionary<string, List<Livro>>();
        while (!sair)
        {
            Console.Clear();
            Console.WriteLine("Bem Vindo à Biblioteca, " + nomePessoa + "!");
            Console.WriteLine("1. Usuário.");
            Console.WriteLine("2. Administrador.");
            Console.WriteLine("3. Sair.");
            int opcaoUser;
            if (int.TryParse(Console.ReadLine(), out opcaoUser))
            {
                switch (opcaoUser)
                {
                    case 1:
                        bool sairUsuario = false;
                        while (!sairUsuario)
                        {
                            Console.Clear();
                            Console.WriteLine("O que você deseja:");
                            Console.WriteLine("1. Catálogo.");
                            Console.WriteLine("2. Devolver livros.");
                            Console.WriteLine("3. Pegar livro.");
                            Console.WriteLine("4. Voltar.");
                            Console.Write("Escolha uma opção: ");
                            int opcao = int.Parse(Console.ReadLine());
                            switch (opcao)
                            {
                                case 1:
                                    // Lógica para visualizar o catálogo de livros
                                    Console.Clear();
                                    Console.WriteLine("Catálogo de Livros:");
                                    foreach (var livro in catalogoLivros)
                                    {
                                        Console.WriteLine($"{livro.Titulo} - {livro.Autor} ({livro.Genero})");
                                    }

                                    break;
                                case 2:
                                    // Lógica para devolver livros
                                    Console.WriteLine("Você escolheu devolver livros.");
                                    break;
                                case 3:
                                    // Lógica para pegar um ou mais livros emprestados
                                    List<Livro> livrosEscolhidos = new List<Livro>();
                                    int contador = 0;
                                    while (contador < 3)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Escolha um livro para pegar emprestado (ou digite 0 para finalizar):");
                                        for (int i = 0; i < catalogoLivros.Count; i++)
                                        {
                                            Console.WriteLine($"{i + 1}. {catalogoLivros[i].Titulo} - {catalogoLivros[i].Autor}");
                                        }

                                        Console.Write("Escolha uma opção: ");
                                        int escolha = int.Parse(Console.ReadLine());
                                        if (escolha == 0)
                                        {
                                            break; // Finaliza a seleção de livros
                                        }

                                        if (escolha > 0 && escolha <= catalogoLivros.Count)
                                        {
                                            livrosEscolhidos.Add(catalogoLivros[escolha - 1]);
                                            contador++;
                                            Console.WriteLine($"Você escolheu: {catalogoLivros[escolha - 1].Titulo}");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Opção inválida.");
                                        }

                                        if (contador < 3)
                                        {
                                            Console.WriteLine("Pressione qualquer tecla para continuar...");
                                            Console.ReadKey();
                                        }
                                    }

                                    // Armazenando os livros escolhidos pelo usuário
                                    if (!livrosEmprestados.ContainsKey(nomePessoa))
                                    {
                                        livrosEmprestados[nomePessoa] = new List<Livro>();
                                    }

                                    livrosEmprestados[nomePessoa].AddRange(livrosEscolhidos);
                                    // Salvando os livros emprestados em um arquivo .txt
                                    SalvarLivrosEmprestados(nomePessoa, livrosEscolhidos);
                                    Console.WriteLine("Livros emprestados com sucesso!");
                                    Console.WriteLine("Você pegou os seguintes livros:");
                                    foreach (var livro in livrosEscolhidos)
                                    {
                                        Console.WriteLine($"- {livro.Titulo}");
                                    }

                                    break;
                                case 4:
                                    sairUsuario = true; // Voltar ao menu principal
                                    break;
                                default:
                                    Console.WriteLine("Opção inválida.");
                                    break;
                            }

                            if (!sairUsuario)
                            {
                                Console.WriteLine("Pressione qualquer tecla para continuar...");
                                Console.ReadKey();
                            }
                        }

                        break;
                    case 2:
                        bool sairAdmin = false;
                        while (!sairAdmin)
                        {
                            Console.Clear();
                            Console.WriteLine("O que você deseja como Administrador:");
                            Console.WriteLine("1. Gerenciar usuários.");
                            Console.WriteLine("2. Gerenciar livros.");
                            Console.WriteLine("3. Voltar.");
                            Console.Write("Escolha uma opção: ");
                            int opcaoAdmin = int.Parse(Console.ReadLine());
                            switch (opcaoAdmin)
                            {
                                case 1:
                                    // Lógica para gerenciar usuários
                                    Console.WriteLine("Você escolheu gerenciar usuários.");
                                    break;
                                case 2:
                                    // Lógica para gerenciar livros
                                    Console.WriteLine("Você escolheu gerenciar livros.");
                                    break;
                                case 3:
                                    sairAdmin = true; // Voltar ao menu principal
                                    break;
                                default:
                                    Console.WriteLine("Opção inválida.");
                                    break;
                            }

                            if (!sairAdmin)
                            {
                                Console.WriteLine("Pressione qualquer tecla para continuar...");
                                Console.ReadKey();
                            }
                        }

                        break;
                    case 3:
                        sair = true; // Sair do loop principal
                        break;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Entrada inválida.");
            }

            if (!sair)
            {
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }
    }

    // Método para salvar os livros emprestados em um arquivo .txt
    static void SalvarLivrosEmprestados(string nomeUsuario, List<Livro> livros)
    {
        string caminhoArquivo = $"{nomeUsuario}_livros_emprestados.txt";
        using (StreamWriter sw = new StreamWriter(caminhoArquivo, true)) // 'true' para adicionar ao arquivo
        {
            sw.WriteLine($"Usuário: {nomeUsuario}");
            sw.WriteLine("Livros emprestados:");
            foreach (var livro in livros)
            {
                sw.WriteLine($"- {livro.Titulo} - {livro.Autor}");
            }

            sw.WriteLine(); // Linha em branco para separar registros
        }
    }

    // Classe para representar um livro
    class Livro
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Genero { get; set; }

        public Livro(string titulo, string autor, string genero)
        {
            Titulo = titulo;
            Autor = autor;
            Genero = genero;
        }
    }
}