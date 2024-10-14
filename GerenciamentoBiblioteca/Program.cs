
class Program
{
    static void Main()
    {
        List<Usuario> usuarios = new List<Usuario>()
        {
            new Usuario("a", "a", true, 0),
            new Usuario("u", "u", false, 0)
        };
        List<Livro> biblioteca = new List<Livro>()
        {
            new Livro("Dom Quixote", "Miguel de Cervantes", "Aventura", 4),
            new Livro("Um Conto de Duas Cidades", "Charles Dickens", "Romance", 5),
            new Livro("O Senhor dos Anéis", "J. R. R. Tolkien", "Fantasia", 1),
            new Livro("O Pequeno Príncipe", "Antoine de Saint-Exupéry", "Infantojuvenil", 2),
            new Livro("Harry Potter e a Pedra Filosofal", "J. K. Rowling", "Fantasia", 3)
        };

        Console.Clear();
        Console.WriteLine("SISTEMA DE GERENCIAMENTO DE BIBLIOTECA\n");
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
                    Console.WriteLine("FAZER LOGIN\n");
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
                                            Console.WriteLine("CONSULTAR CATÁLOGO\n");
                                            foreach (var livro in biblioteca)
                                            {
                                                Console.WriteLine($"Título: {livro.Titulo}");
                                                Console.WriteLine($"Autor: {livro.Autor}");
                                                Console.WriteLine($"Gênero: {livro.Genero}");
                                                Console.WriteLine($"Quantidade: {livro.Quantidade}\n");
                                                foreach (var usuario in livro.UsuariosAlugando)
                                                {
                                                    Console.WriteLine($"Usuários alugando: {usuario}\n");
                                                }
                                            }
                                            break;

                                        case 2:
                                            Console.WriteLine("CADASTRAR LIVRO\n");

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
                                Console.WriteLine("SISTEMA DE GERENCIAMENTO DE BIBLIOTECA\n");
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
                                            Console.WriteLine("CONSULTAR CATÁLOGO\n");
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
                                            break;

                                        case 2:
                                            Console.WriteLine("ALUGAR LIVRO\n");
                                            if (usuarioLogado.QntLivrosAlugados < 3)
                                            {
                                                Console.Write("Insira o nome do livro: ");
                                                string livroAAlugar = Console.ReadLine();
                                                bool contemLivro = false;
                                                foreach (var livro in biblioteca)
                                                {
                                                    if (livro.Titulo == livroAAlugar && livro.Quantidade > 0)
                                                    {
                                                        contemLivro = true;
                                                        livro.Quantidade--;
                                                        usuarioLogado.QntLivrosAlugados++;
                                                        livro.UsuariosAlugando.Add(usuarioLogado.NomeUsuario);
                                                        Console.WriteLine("Livro alugado com sucesso!");
                                                        break;
                                                    }
                                                }
                                                if (!contemLivro)
                                                {
                                                    Console.WriteLine("Livro não encontrado ou indisponível no momento.");
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("Você não pode alugar mais livros no momento, pois já atingiu o limite de 3. Devolva algum livro e tente novamente.");
                                            }
                                            break;

                                        case 3:
                                            Console.WriteLine("DEVOLVER LIVRO\n");
                                            bool usuarioAlugouLivro = false;
                                            foreach (var livro in biblioteca)
                                            {
                                                foreach (var usuario in livro.UsuariosAlugando)
                                                {
                                                    if (usuario == usuarioLogado.NomeUsuario)
                                                    {
                                                        usuarioAlugouLivro = true;
                                                        break;
                                                    }
                                                }
                                            }
                                            if (usuarioAlugouLivro)
                                            {
                                                Console.Write("Insira o nome do livro: ");
                                                string livroADevolver = Console.ReadLine();
                                                bool contemLivro = false;
                                                foreach (var livro in biblioteca)
                                                {
                                                    if (livro.Titulo == livroADevolver)
                                                    {
                                                        contemLivro = true;
                                                        livro.Quantidade++;
                                                        usuarioLogado.QntLivrosAlugados--;
                                                        livro.UsuariosAlugando.Remove(usuarioLogado.NomeUsuario);
                                                        Console.WriteLine("Livro devolvido com sucesso!");
                                                        break;
                                                    }
                                                }
                                                if (!contemLivro)
                                                {
                                                    Console.WriteLine("Parece que você não alugou este livro ou digitou o nome incorretamente. Tente novamente.");
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("Você não tem nenhum livro alugado, portanto não há o que devolver. Alugue algum livro e tente novamente.");
                                            }
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

        int qntLivrosAlugados = 0;

        usuarios.Add(new Usuario(nomeUsuario, senha, ehAdmin, qntLivrosAlugados));

        Console.WriteLine("Usuário cadastrado com sucesso!");
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