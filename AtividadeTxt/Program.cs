using System;
using System.IO;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("MENU PRINCIPAL:");
            Console.WriteLine("1 - Criar pasta");
            Console.WriteLine("2 - Criar arquivo");
            Console.WriteLine("3 - Exibir arquivos do diretório");
            Console.WriteLine("4 - Editar nome do arquivo");
            Console.WriteLine("5 - Editar nome da pasta");
            Console.WriteLine("6 - Deletar Arquivo");
            Console.WriteLine("7 - Deletar Pasta");
            Console.WriteLine("8 - SAIR");
            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    CriarPasta();
                    break;
                case "2":
                    CriarArquivo();
                    break;
                case "3":
                    ExibirArquivos();
                    break;
                case "4":
                    RenomearArquivo();
                    break;
                case "5":
                    RenomearPasta();
                    break;
                case "6":
                    DeletarArquivo();
                    break;
                case "7":
                    DeletarPasta();
                    break;
                case "8":
                    return;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        }
    }

    static void CriarPasta()
    {
        Console.Write("Digite o nome da pasta: ");
        string nomePasta = Console.ReadLine();

        if (Directory.Exists(nomePasta))
        {
            Console.WriteLine("A pasta já existe!");
        }
        else
        {
            Directory.CreateDirectory(nomePasta);
            Console.WriteLine("Pasta criada com sucesso!");
        }
        Console.ReadKey();
    }

    static void CriarArquivo()
    {
        Console.Write("Digite o nome da pasta onde criar o arquivo: ");
        string nomePasta = Console.ReadLine();

        if (!Directory.Exists(nomePasta))
        {
            Console.WriteLine("A pasta não existe!");
            Console.ReadKey();
            return;
        }

        Console.Write("Digite o nome do arquivo (com .txt): ");
        string nomeArquivo = Console.ReadLine();
        string caminhoArquivo = Path.Combine(nomePasta, nomeArquivo);

        Console.Write("Digite o conteúdo do arquivo: ");
        string conteudo = Console.ReadLine();

        File.WriteAllText(caminhoArquivo, conteudo);
        Console.WriteLine("Arquivo criado com sucesso!");
        Console.ReadKey();
    }

    static void ExibirArquivos()
    {
        Console.Write("Digite o nome da pasta para exibir os arquivos: ");
        string nomePasta = Console.ReadLine();

        if (Directory.Exists(nomePasta))
        {
            string[] arquivos = Directory.GetFiles(nomePasta);
            Console.WriteLine("Arquivos encontrados:");
            foreach (string arquivo in arquivos)
            {
                Console.WriteLine(Path.GetFileName(arquivo));
            }
        }
        else
        {
            Console.WriteLine("A pasta não existe!");
        }
        Console.ReadKey();
    }

    static void RenomearArquivo()
    {
        Console.Write("Digite o nome do arquivo atual (com .txt): ");
        string nomeAtual = Console.ReadLine();

        if (!File.Exists(nomeAtual))
        {
            Console.WriteLine("O arquivo não existe!");
            Console.ReadKey();
            return;
        }

        Console.Write("Digite o novo nome do arquivo (com .txt): ");
        string novoNome = Console.ReadLine();
        File.Move(nomeAtual, novoNome);

        Console.WriteLine("Arquivo renomeado com sucesso!");
        Console.ReadKey();
    }

    static void RenomearPasta()
    {
        Console.Write("Digite o nome da pasta atual: ");
        string nomeAtual = Console.ReadLine();

        if (!Directory.Exists(nomeAtual))
        {
            Console.WriteLine("A pasta não existe!");
            Console.ReadKey();
            return;
        }

        Console.Write("Digite o novo nome da pasta: ");
        string novoNome = Console.ReadLine();
        Directory.Move(nomeAtual, novoNome);

        Console.WriteLine("Pasta renomeada com sucesso!");
        Console.ReadKey();
    }

    static void DeletarArquivo()
    {
        Console.Write("Digite o nome do arquivo para deletar (com .txt): ");
        string nomeArquivo = Console.ReadLine();

        if (File.Exists(nomeArquivo))
        {
            File.Delete(nomeArquivo);
            Console.WriteLine("Arquivo deletado com sucesso!");
        }
        else
        {
            Console.WriteLine("O arquivo não existe!");
        }
        Console.ReadKey();
    }

    static void DeletarPasta()
    {
        Console.Write("Digite o nome da pasta para deletar: ");
        string nomePasta = Console.ReadLine();

        if (Directory.Exists(nomePasta))
        {
            Directory.Delete(nomePasta, true);
            Console.WriteLine("Pasta deletada com sucesso!");
        }
        else
        {
            Console.WriteLine("A pasta não existe!");
        }
        Console.ReadKey();
    }
}
