
class Program
{
    static void Main()
    {
        List<Usuario> usuarios = new List<Usuario>()
        {
            new Usuario("a", "a", true),
            new Usuario("u", "u", false)
        };
        List<Livro> biblioteca = new List<Livro>()
        {
            new Livro("Dom Quixote", "Miguel de Cervantes", "Aventura", 1),
            new Livro("Um Conto de Duas Cidades", "Charles Dickens", "Romance", 1),
            new Livro("O Senhor dos Anéis", "J. R. R. Tolkien", "Fantasia", 1)
        };
        List<Livro> livrosAlugados = new List<Livro>();

        Console.Clear();
        Console.WriteLine("SISTEMA DE GERENCIAMENTO DE BIBLIOTECA");
        Console.WriteLine("1- Fazer Login");
        Console.WriteLine("2- Cadastrar Novo Usuário");
        Console.WriteLine("0- Sair");

    escolhaOpcao1:
        Console.Write("Escolha uma opção: ");
        if (!int.TryParse(Console.ReadLine(), out int escolhaUsuario) && !(escolhaUsuario >= 0 && escolhaUsuario <= 2))
        {
            Console.WriteLine("Opção inválida. Tente novamente.");
            goto escolhaOpcao1;
        }
        else
        {
            switch (escolhaUsuario)
            {
                case 1:
                    Console.WriteLine("FAZER LOGIN");
                    Console.Write("Usuário: ");
                    string nomeUsuario = Console.ReadLine();
                    Console.Write("Senha: ");
                    string senha = Console.ReadLine();

                    Usuario usuarioLogado = ValidarLogin(usuarios, nomeUsuario, senha);

                    if (usuarioLogado != null)
                    {
                        Console.WriteLine($"Login bem-sucedido. Bem-vindo(a), {usuarioLogado.NomeUsuario}!");
                        if (usuarioLogado.EhAdmin)
                        {
                            Console.WriteLine("Você tem acesso de administrador.");
                            Console.Write("Pressione qualquer tecla para continuar...");
                            Console.ReadKey();
                            while (true)
                            {
                                Console.Clear();
                                Console.WriteLine("SISTEMA DE GERENCIAMENTO DE BIBLIOTECA");
                                Console.WriteLine("1- Consultar Catálogo");
                                Console.WriteLine("2- Cadastrar Livro");
                                Console.WriteLine("0- Sair");

                            escolhaOpcao2:
                                Console.Write("Escolha uma opção: ");
                                if (!int.TryParse(Console.ReadLine(), out escolhaUsuario) && !(escolhaUsuario >= 0 && escolhaUsuario <= 2))
                                {
                                    Console.WriteLine("Opção inválida. Tente novamente.");
                                    goto escolhaOpcao2;
                                }
                                else
                                {
                                    switch (escolhaUsuario)
                                    {
                                        case 1:
                                            Console.WriteLine("CONSULTAR CATÁLOGO");
                                            foreach (var livro in biblioteca)
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

                                            biblioteca.Add(new Livro(titulo, autor, genero, quantidade));
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
                        else
                        {
                            Console.WriteLine("Você é um usuário comum.");
                            Console.Write("Pressione qualquer tecla para continuar...");
                            Console.ReadKey();
                            while (true)
                            {
                                Console.Clear();
                                Console.WriteLine("SISTEMA DE GERENCIAMENTO DE BIBLIOTECA");
                                Console.WriteLine("1- Consultar Catálogo");
                                Console.WriteLine("2- Alugar Livro");
                                Console.WriteLine("3- Devolver Livro");
                                Console.WriteLine("0- Sair");

                            escolhaOpcao3:
                                Console.Write("Escolha uma opção: ");
                                if (!int.TryParse(Console.ReadLine(), out escolhaUsuario) && !(escolhaUsuario >= 0 && escolhaUsuario <= 2))
                                {
                                    Console.WriteLine("Opção inválida. Tente novamente.");
                                    goto escolhaOpcao3;
                                }
                                else
                                {
                                    switch (escolhaUsuario)
                                    {
                                        case 1:
                                            Console.WriteLine("CONSULTAR CATÁLOGO");
                                            foreach (var livro in biblioteca)
                                            {
                                                Console.WriteLine($"Título: {livro.Titulo}");
                                                Console.WriteLine($"Autor: {livro.Autor}");
                                                Console.WriteLine($"Gênero: {livro.Genero}");
                                                Console.WriteLine($"Quantidade: {livro.Quantidade}\n");
                                            }
                                            break;

                                        case 2:
                                            Console.WriteLine("ALUGAR LIVRO");
                                            Console.Write("Insira o nome do livro: ");
                                            string livroAAlugar = Console.ReadLine();
                                            bool contemLivro = false;
                                            foreach (var livro in biblioteca)
                                            {
                                                if (livro.Titulo == livroAAlugar)
                                                {
                                                    contemLivro = true;
                                                    livro.Quantidade--;
                                                    Console.WriteLine("Livro emprestado com sucesso!");
                                                    break;
                                                }
                                            }
                                            if (!contemLivro)
                                            {
                                                Console.WriteLine("Livro não encontrado.");
                                            }
                                            break;
                                            break;

                                        case 3:
                                            Console.WriteLine("DEVOLVER LIVRO");
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
                    else
                    {
                        Console.WriteLine("Nome de usuário ou senha inválido(s).");
                    }
                    break;

                case 2:
                    Console.WriteLine("CADASTRAR NOVO USUÁRIO");
                    CadastrarUsuario(usuarios);
                    break;

                case 0:
                    Console.WriteLine("Saindo... Até a próxima!");
                    break;
            }
        }
    }
    static Usuario ValidarLogin(List<Usuario> usuarios, string nomeUsuario, string senha)
    {
        foreach (var usuario in usuarios)
        {
            if (usuario.NomeUsuario == nomeUsuario && usuario.Senha == senha)
                return usuario;
        }
        return null;
    }
    static void CadastrarUsuario(List<Usuario> usuarios)
    {
        Console.Write("Usuário: ");
        string nomeUsuario = Console.ReadLine();

        if (usuarios.Exists(u => u.NomeUsuario == nomeUsuario))
        {
            Console.WriteLine("Usuário já cadastrado. Tente outro.");
            return;
        }

        Console.Write("Senha: ");
        string senha = Console.ReadLine();

        bool ehAdmin = false;

        usuarios.Add(new Usuario(nomeUsuario, senha, ehAdmin));

        Console.WriteLine("Usuário cadastrado com sucesso!");
    }
}
public class Usuario
{
    public string NomeUsuario { get; }
    public string Senha { get; }
    public bool EhAdmin { get; }

    public Usuario(string nomeUsuario, string senha, bool ehAdmin)
    {
        NomeUsuario = nomeUsuario;
        Senha = senha;
        EhAdmin = ehAdmin;
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