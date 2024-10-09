
class Program
{
    static void Main()
    {
        List<Livro> livros = new List<Livro>();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("SISTEMA DE GERENCIAMENTO DE BIBLIOTECA");
            // usuário
            // Console.WriteLine("1- Consultar Catálogo");
            // Console.WriteLine("2- Alugar Livro");
            // Console.WriteLine("3- Devolver Livro");
            // Console.WriteLine("0- Sair");
            // admin
            Console.WriteLine("1- Consultar Catálogo");
            Console.WriteLine("2- Cadastrar Livro");
            Console.WriteLine("0- Sair");

        escolhaOpcao:
            Console.Write("Escolha uma opção: ");
            if (!int.TryParse(Console.ReadLine(), out int escolhaUsuario) && !(escolhaUsuario >= 1 && escolhaUsuario <= 2))
            {
                Console.WriteLine("Opção inválida. Tente novamente.");
                goto escolhaOpcao;
            }
            else
            {
                switch (escolhaUsuario)
                {
                    case 1:
                        Console.WriteLine("CONSULTAR CATÁLOGO");
                        foreach (var livro in livros)
                        {
                            Console.WriteLine($"Título: {livro.Titulo}");
                            Console.WriteLine($"Autor: {livro.Autor}");
                            Console.WriteLine($"Gênero: {livro.Genero}");
                            Console.WriteLine($"Quantidade: {livro.Quantidade}\n");
                        }
                        break;

                    case 2:
                        Console.WriteLine("CADASTRAR LIVRO");

                        Console.Write("Insira o título do livro: ");
                        string titulo = Console.ReadLine();

                        Console.Write("Insira o autor do livro: ");
                        string autor = Console.ReadLine();

                        Console.Write("Insira o gênero do livro: ");
                        string genero = Console.ReadLine();

                        Console.Write("Insira a quantidade disponível do livro: ");
                        int quantidade = int.Parse(Console.ReadLine());

                        livros.Add(new Livro(titulo, autor, genero, quantidade));
                        break;

                    case 0:
                        Console.WriteLine("Saindo... Até a próxima!");
                        return;
                }
                Console.Write("Pressione qualquer tecla para continuar...");
                Console.ReadKey();                
            }
        }
    }
}
public class Livro
{
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public string Genero { get; set; }
    public int Quantidade { get; set; }

    public Livro(string titulo, string autor, string genero, int quantidade)
    {
        Titulo = titulo;
        Autor = autor;
        Genero = genero;
        Quantidade = quantidade;
    }
}