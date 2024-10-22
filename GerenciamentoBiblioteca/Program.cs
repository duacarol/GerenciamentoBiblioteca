class Program
{
    static void Main()
    {
        List<Usuario> usuarios = new List<Usuario>
        {
            new Usuario("admin", "admin123", true, 0)
        };
        List<Livro> biblioteca = new List<Livro>
        {
            new Livro("Dom Quixote", "Miguel de Cervantes", "Aventura", 4),
            new Livro("Um Conto de Duas Cidades", "Charles Dickens", "Romance", 5),
            new Livro("O Senhor dos Anéis", "J. R. R. Tolkien", "Fantasia", 1),
            new Livro("O Pequeno Príncipe", "Antoine de Saint-Exupéry", "Infantojuvenil", 2),
            new Livro("Harry Potter e a Pedra Filosofal", "J. K. Rowling", "Fantasia", 3)
        };

        while (true)
        {
            Console.Clear();
            EscreverTitulo("Sistema de Gerenciamento de Biblioteca");
            ExibirMenuPrincipal();
            int escolhaUsuario = LerOpcao(0, 2);
            switch (escolhaUsuario)
            {
                case 1:
                    Console.Clear();
                    EscreverTitulo("Sistema de Gerenciamento de Biblioteca");
                    FazerLogin(usuarios, biblioteca);
                    break;
                case 2:
                    Console.Clear();
                    EscreverTitulo("Sistema de Gerenciamento de Biblioteca");
                    CadastrarUsuario(usuarios);
                    break;
                case 0:
                    Console.Clear();
                    EscreverTitulo("Sistema de Gerenciamento de Biblioteca");
                    Console.WriteLine("Saindo... Até a próxima!");
                    return;
            }
        }
    }

    static void ExibirMenuPrincipal()
    {
        Console.WriteLine("1- Fazer Login");
        Console.WriteLine("2- Cadastrar Novo Usuário");
        Console.WriteLine("0- Sair");
    }

    static void FazerLogin(List<Usuario> usuarios, List<Livro> biblioteca)
    {
        EscreverTitulo("Fazer Login");
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
                MenuAdmin(usuarioLogado, biblioteca);
            }
            else
            {
                MenuUsuario(usuarioLogado, biblioteca);
            }
        }
        else
        {
            ColorirLinha("Nome de usuário ou senha inválido(s).", ConsoleColor.Red);
        }
    }

    static void MenuAdmin(Usuario usuarioLogado, List<Livro> biblioteca)
    {
        while (true)
        {
            Console.Clear();
            EscreverTitulo("Sistema de Gerenciamento de Biblioteca");
            Console.WriteLine("1- Consultar Catálogo");
            Console.WriteLine("2- Cadastrar Livro");
            Console.WriteLine("0- Sair");

            int escolha = LerOpcao(0, 2);
            switch (escolha)
            {
                case 1:
                    ConsultarCatalogo(biblioteca);
                    break;
                case 2:
                    CadastrarLivro(biblioteca);
                    break;
                case 0:
                    return;
            }
        }
    }

    static void MenuUsuario(Usuario usuarioLogado, List<Livro> biblioteca)
    {
        while (true)
        {
            Console.Clear();
            EscreverTitulo("Sistema de Gerenciamento de Biblioteca");
            Console.WriteLine("1- Consultar Catálogo");
            Console.WriteLine("2- Alugar Livro");
            Console.WriteLine("3- Devolver Livro");
            Console.WriteLine("0- Sair");

            int escolha = LerOpcao(0, 3);
            switch (escolha)
            {
                case 1:
                    ConsultarCatalogo(biblioteca);
                    break;
                case 2:
                    AlugarLivro(usuarioLogado, biblioteca);
                    break;
                case 3:
                    DevolverLivro(usuarioLogado, biblioteca);
                    break;
                case 0:
                    return;
            }
        }
    }

    static void ConsultarCatalogo(List<Livro> biblioteca)
    {
        EscreverTitulo("Consultar Catálogo");
        foreach (var livro in biblioteca)
        {
            if (livro.Quantidade > 0)
            {
                Console.WriteLine($"Título: {livro.Titulo}");
                Console.WriteLine($"Autor: {livro.Autor}");
                Console.WriteLine($"Gênero: {livro.Genero}");
                Console.WriteLine($"Quantidade: {livro.Quantidade}\n");
            }
        }
        Console.Write("Pressione qualquer tecla para continuar...");
        Console.ReadKey();
    }

    static void CadastrarLivro(List<Livro> biblioteca)
    {
        EscreverTitulo("Cadastrar Livro");

        Console.Write("Insira o título do livro: ");
        string titulo = Console.ReadLine();

        Console.Write("Insira o autor do livro: ");
        string autor = Console.ReadLine();

        Console.Write("Insira o gênero do livro: ");
        string genero = Console.ReadLine();

        Console.Write("Insira a quantidade disponível do livro: ");
        int quantidade = LerQuantidade();

        biblioteca.Add(new Livro(titulo, autor, genero, quantidade));
        ColorirLinha("Livro cadastrado com sucesso!", ConsoleColor.Green);
    }

    static void AlugarLivro(Usuario usuarioLogado, List<Livro> biblioteca)
    {
        if (usuarioLogado.QntLivrosAlugados < 3)
        {
            EscreverTitulo("Alugar Livro");
            Console.Write("Insira o nome do livro: ");
            string livroAAlugar = Console.ReadLine();
            foreach (var livro in biblioteca)
            {
                if (livro.Titulo.Equals(livroAAlugar, StringComparison.OrdinalIgnoreCase) && livro.Quantidade > 0)
                {
                    livro.Quantidade--;
                    usuarioLogado.QntLivrosAlugados++;
                    livro.UsuariosAlugando.Add(usuarioLogado.NomeUsuario);
                    Console.WriteLine("Livro alugado com sucesso!");
                    return;
                }
            }
            ColorirLinha("Livro não encontrado ou indisponível no momento.", ConsoleColor.Red);
        }
        else
        {
            ColorirLinha("Você não pode alugar mais livros no momento, pois já atingiu o limite de 3. Devolva algum livro e tente novamente.", ConsoleColor.Red);
        }
        Console.Write("Pressione qualquer tecla para continuar...");
        Console.ReadKey();
    }

    static void DevolverLivro(Usuario usuarioLogado, List<Livro> biblioteca)
    {
        EscreverTitulo("Devolver Livro");
        Console.Write("Insira o nome do livro: ");
        string livroADevolver = Console.ReadLine();
        foreach (var livro in biblioteca)
        {
            if (livro.Titulo.Equals(livroADevolver, StringComparison.OrdinalIgnoreCase))
            {
                if (livro.UsuariosAlugando.Contains(usuarioLogado.NomeUsuario))
                {
                    livro.Quantidade++;
                    usuarioLogado.QntLivrosAlugados--;
                    livro.UsuariosAlugando.Remove(usuarioLogado.NomeUsuario);
                    ColorirLinha("Livro devolvido com sucesso!", ConsoleColor.Green);
                    return;
                }
                else
                {
                    ColorirLinha("Você não alugou este livro.", ConsoleColor.Red);
                    return;
                }
            }
        }
        ColorirLinha("Livro não encontrado ou você não alugou este livro.", ConsoleColor.Red);
        Console.Write("Pressione qualquer tecla para continuar...");
        Console.ReadKey();
    }

    static int LerOpcao(int min, int max)
    {
        while (true)
        {
            Console.Write("Escolha uma opção: ");
            if (int.TryParse(Console.ReadLine(), out int escolha) && escolha >= min && escolha <= max)
            {
                return escolha;
            }
            ColorirLinha("Opção inválida. Tente novamente.", ConsoleColor.Red);
        }
    }

    static int LerQuantidade()
    {
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out int quantidade) && quantidade >= 0)
            {
                return quantidade;
            }
            ColorirLinha("Quantidade inválida. Insira um número não negativo.", ConsoleColor.Red);
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
            ColorirLinha("Nome de usuário já está em uso. Tente outro.", ConsoleColor.Red);
            return;
        }

        Console.Write("Senha: ");
        string senha = Console.ReadLine();

        usuarios.Add(new Usuario(nomeUsuario, senha, false, 0));
        ColorirLinha("Usuário cadastrado com sucesso!", ConsoleColor.Green);
    }

    static void EscreverTitulo(string titulo)
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("=".PadLeft(titulo.Length, '='));
        Console.WriteLine(titulo);
        Console.WriteLine("=".PadLeft(titulo.Length, '='));
        Console.ResetColor();
    }

    static void ColorirLinha(string texto, ConsoleColor cor)
    {
        Console.ForegroundColor = cor;
        Console.WriteLine(texto);
        Console.ResetColor();
    }
}

public class Usuario
{
    public string NomeUsuario { get; }
    public string Senha { get; }
    public bool EhAdmin { get; }
    public int QntLivrosAlugados { get; set; }

    public Usuario(string nomeUsuario, string senha, bool ehAdmin, int qntLivrosAlugados)
    {
        NomeUsuario = nomeUsuario;
        Senha = senha;
        EhAdmin = ehAdmin;
        QntLivrosAlugados = qntLivrosAlugados;
    }
}

public class Livro
{
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public string Genero { get; set; }
    public int Quantidade { get; set; }
    public List<string> UsuariosAlugando { get; set; }

    public Livro(string titulo, string autor, string genero, int quantidade)
    {
        Titulo = titulo;
        Autor = autor;
        Genero = genero;
        Quantidade = quantidade;
        UsuariosAlugando = new List<string>();
    }
}