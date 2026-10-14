# Projeto CRUD em C#

Trabalho escolar desenvolvido por três alunos do 1º ano do Ensino Médio Técnico do SENAC.

## Autores

* Filipe Rocha
* Kauã Heinzen
* Pedro Soares

---

## Sobre o projeto

Sistema de jogos executado pelo terminal, com CRUD completo (cadastrar, listar, buscar, atualizar e excluir) em C# conectado a um banco de dados MySQL.

| Item | Utilizado |
|------|-----------|
| Linguagem | C# (.NET) |
| **Banco de dados** | **MySQL** (banco `Jogos`, tabela `jogo`) |
| **Biblioteca/driver** | **MySqlConnector** (pacote NuGet) |
| Script do banco | `codigosql.sql` |
| Pesquisa | `pesquisa.txt` |

### Menu do sistema

```
================================
=        SISTEMA DE JOGOS      =
================================
1 - Cadastrar jogo
2 - Listar jogos
3 - Buscar jogo
4 - Atualizar jogo
5 - Excluir jogo
0 - Sair
```

### Tabela `jogo`

| Coluna | Descrição |
|--------|-----------|
| `id` | Chave primária (AUTO_INCREMENT) |
| `nome` | Nome do jogo |
| `franquia` | Franquia do jogo |
| `genero_principal` | Gênero principal |
| `data_lancamento` | Data de lançamento |
| `nota` | Nota do jogo (0 a 99) |

### Arquivos do projeto

| Arquivo | Função |
|---------|--------|
| `Program.cs` | Menu e interação com o usuário pelo terminal |
| `Jogo_MySql.cs` | Classe da entidade: propriedades com validação, construtores e `ToString()` |
| `MySql.cs` | Conexão com o banco e comandos SQL (INSERT, SELECT, UPDATE, DELETE) |
| `codigosql.sql` | Script que cria o banco e a tabela |
| `pesquisa.txt` | Respostas da parte de pesquisa |

---

# Manual de Instalação e Execução do Sistema

Olá! Neste manual será apresentado o passo a passo para instalar, configurar e executar o sistema.

## 1. Instalação do Visual Studio Code

Caso ainda não possua o Visual Studio Code instalado, faça o download pelo site oficial:

https://code.visualstudio.com/

Após a instalação, abra o programa.

## 2. Instalação do .NET

Instale o .NET pelo site oficial:

https://dotnet.microsoft.com/en-us/download

Recomenda-se instalar o **SDK do .NET**, pois ele é necessário para executar comandos como `dotnet restore` e `dotnet run`.

## 3. Instalação da extensão C# Dev Kit

No Visual Studio Code:

1. Abra a aba **Extensões**.
2. Pesquise por **C# Dev Kit**.
3. Instale a extensão.

Ela fornece suporte ao desenvolvimento de aplicações C# no VS Code.

## 4. Abrir o projeto

Clone ou baixe este repositório e abra a **pasta do projeto** no Visual Studio Code.

Certifique-se de que os arquivos do projeto, incluindo o arquivo `.csproj`, estejam dentro da pasta aberta.

## 5. Instalação das dependências (driver do MySQL)

O C# precisa de um **driver** para conversar com o MySQL. Neste projeto o driver é o **MySqlConnector**, que já está listado no arquivo `.csproj`. Para baixá-lo, execute no terminal, dentro da pasta do projeto:

```bash
dotnet restore
```

Caso fosse necessário adicionar o driver manualmente em um projeto novo, o comando seria:

```bash
dotnet add package MySqlConnector
```

## 6. Instalação e configuração do MySQL Workbench

Abra o MySQL Workbench e copie o código presente no arquivo **codigosql.sql**.

Cole o código na área de consultas do MySQL Workbench.

Caso ainda não tenha o MySQL Workbench instalado, faça o download pelo site oficial:

https://www.mysql.com/products/workbench/

### Configuração da senha

Para que o sistema consiga se conectar ao banco de dados, a senha do usuário **root** deve ser:

**Senac2026**

Caso seja utilizada outra senha, será necessário alterar a senha configurada na string de conexão (campo `conexao`, no início da classe) do arquivo **MySql.cs**, para a senha escolhida.

## 7. Criação do banco de dados

Depois de colar o código do arquivo **codigosql.sql** no MySQL Workbench:

1. Verifique se o código foi inserido corretamente.
2. Clique no botão **Executar**, representado pelo ícone de raio.
3. Aguarde a execução do script.

O código será responsável pela criação do banco de dados e das tabelas necessárias para o funcionamento do sistema.

## 8. Requisitos

Para executar o sistema corretamente, é necessário possuir:

* Visual Studio Code;
* .NET SDK;
* Extensão C# Dev Kit;
* Driver MySqlConnector (instalado com `dotnet restore`);
* MySQL Server;
* MySQL Workbench;
* Banco de dados configurado através do arquivo **codigosql.sql**;
* Senha do usuário `root` configurada corretamente.

Após realizar todas essas etapas, o sistema estará pronto para ser utilizado.

## 9. Executando o sistema

Existem duas formas de executar o sistema.

### Opção 1 — Executar o arquivo `.exe`

Abra a pasta **bin** do projeto e execute o arquivo:

**Trabalho-CRUD-Bruno.exe**

> Caso o nome do arquivo `.exe` tenha sido alterado, execute o arquivo executável correspondente ao projeto.

Certifique-se de que a senha configurada no MySQL seja a mesma senha pré-definida no sistema.

### Opção 2 — Executar pelo Visual Studio Code

No Visual Studio Code, abra o **Terminal Integrado** e certifique-se de que o terminal esteja localizado na pasta do projeto.

Execute primeiro:

```bash
dotnet restore
```

Depois, execute:

```bash
dotnet run
```

## 10. Como funciona a conexão com o banco de dados

O C# não conversa com o MySQL sozinho: ele usa o driver **MySqlConnector**, que oferece as classes `MySqlConnection`, `MySqlCommand` e `MySqlDataReader` (namespace `MySqlConnector`). Todo esse código está no arquivo **MySql.cs**.

### String de conexão

É um texto que informa ao driver onde está o banco e como entrar nele:

```
Server=localhost;Database=Jogos;User Id=root;Password=Senac2026;
```

* `Server`: onde o MySQL está rodando (`localhost` é o próprio computador);
* `Database`: qual banco usar (`Jogos`);
* `User Id` e `Password`: usuário e senha do MySQL.

### Passo a passo de cada operação

1. **Abrir a conexão:** cria-se um `MySqlConnection` com a string de conexão e chama-se `Open()`.
2. **Montar o SQL:** cria-se um `MySqlCommand` com o texto do comando (INSERT, SELECT, UPDATE ou DELETE).
3. **Passar os valores por parâmetros:** os dados digitados entram como `@nome`, `@id` etc. (`Parameters.AddWithValue`). Assim o valor nunca é misturado ao texto do SQL, o que impede **SQL Injection**.
4. **Executar o comando:**
   * INSERT, UPDATE e DELETE usam `ExecuteNonQuery()`, que devolve quantas linhas foram afetadas;
   * SELECT usa `ExecuteReader()`, que devolve um leitor percorrido linha a linha com `Read()`.
5. **Transformar o resultado em objetos:** para cada linha lida, o método `MontarJogo` cria um objeto `Jogo_MySql`. O SELECT devolve uma `List<Jogo_MySql>`, e o `Program.cs` imprime os objetos usando o `ToString()`.
6. **Fechar a conexão:** o bloco `using` fecha a conexão automaticamente ao terminar, mesmo se ocorrer um erro.

### Como os dados do banco viram objetos

Cada linha da tabela `jogo` é representada por um objeto da classe `Jogo_MySql`, que possui dois construtores:

* um para **cadastrar** (valida os dados digitados e chama o INSERT);
* um para **montar o objeto a partir do banco** (usado no SELECT, não insere nada).

## 11. Perguntas

As perguntas foram respondidas no arquivo **pesquisa.txt**
