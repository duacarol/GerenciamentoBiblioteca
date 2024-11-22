# GerenciamentoBiblioteca
Projeto desenvolvido durante as aulas do curso técnico em Informática para Internet do [SENAI-MG](https://www.fiemg.com.br/senai/). A atividade consistiu na criação de um sistema de gerenciamento de biblioteca simulado a partir de um aplicativo de console em .NET.  

## Ferramentas utilizadas
-  **Linguagem de programação:** C#
-  **Framework:** .NET
-  **IDE**: Visual Studio Code
-  **Versionamento:** GIT
-  **Gestão de repositórios:** GitHub  

## Etapas implementadas  

### Funcionalidades básicas
- [x] **Cadastro de usuário**: Permite o cadastro de novos usuários com nome de usuário e senha únicos.  
- [x] **Login**: Valida as credenciais de usuários e administradores para acesso ao sistema.
- [x] **Consulta ao catálogo (A/U)**: Usuários e administradores podem consultar os livros disponíveis, com título, autor, gênero e quantidade.
- [x] **Cadastro de novos livros (A)**: Administradores podem cadastrar livros novos, incluindo título, autor, gênero e quantidade.
- [x] **Aluguel de livros (U)**: Usuários podem alugar livros, respeitando o limite de 3 livros alugados por usuário.
- [x] **Devolução de livros (U)**: Usuários podem devolver livros alugados, atualizando o estoque e a contagem de livros alugados.  

### Detalhes técnicos
-  **Estruturas de decisão**: O sistema utiliza estruturas de decisão para:
    -  **Verificar o estoque de livros**: Antes de permitir um empréstimo, o sistema verifica se o livro desejado está disponível.
    -  **Controlar os tipos de conta**: O sistema diferencia entre contas de administrador e de usuário comum, permitindo ações específicas para cada tipo.
    -  **Limite de livros por usuário**: O sistema impõe um limite de 3 livros alugados por usuário, verificando antes de um novo empréstimo se o usuário já atingiu esse limite.
-  **Menu de opções**: O menu de opções aparece continuamente até que o usuário decida sair do sistema, permitindo que o usuário interaja com as funcionalidades de maneira contínua.
-  **Validação**: Todas as entradas do usuário passam por validação para evitar dados inconsistentes.
-  **Persistência simulada**: Os dados de usuários e livros são armazenados em listas durante a execução.
-  **Mensagens dinâmicas**: *Feedback* colorido (verde para sucesso, vermelho para erros) melhora a experiência do usuário.  

## Backlog
- [ ] **Persistência de dados**: Implementar um banco de dados para armazenar informações de livros e usuários.
- [ ] **Controle de sessão**: Registrar histórico de alugueis e devoluções por usuário.
- [ ] **Relatórios**: Gerar relatórios de uso, como livros mais alugados e usuários ativos.
- [ ] **Segurança**: Implementar *hashing* de senhas.  

## Conclusão
O projeto é um ponto de partida sólido para o gerenciamento de bibliotecas, atendendo a funções básicas de administração e empréstimo de livros. Ele pode ser ampliado com funcionalidades mais complexas, como persistência de dados e interfaces modernas, para se tornar uma solução robusta para bibliotecas maiores.