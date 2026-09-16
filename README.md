# Projeto CRUD em C#

Trabalho escolar desenvolvido por três alunos do 1º ano do Ensino Médio Técnico do SENAC.

## Autores

* Filipe Rocha
* Kauã Heinzen
* Pedro Soares

---

# Manual de Instalação e Execução do Sistema Escolar

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

## 5. Instalação e configuração do MySQL Workbench

Abra o MySQL Workbench e copie o código presente no arquivo **codigosql.sql**.

Cole o código na área de consultas do MySQL Workbench.

Caso ainda não tenha o MySQL Workbench instalado, faça o download pelo site oficial:

https://www.mysql.com/products/workbench/

### Configuração da senha

Para que o sistema consiga se conectar ao banco de dados, a senha do usuário **root** deve ser:

**Senac2026**

Caso seja utilizada outra senha, será necessário alterar a senha configurada no arquivo **MySql.cs**, na linha 4, para a senha escolhida.

## 6. Criação do banco de dados

Depois de colar o código do arquivo **codigosql.sql** no MySQL Workbench:

1. Verifique se o código foi inserido corretamente.
2. Clique no botão **Executar**, representado pelo ícone de raio.
3. Aguarde a execução do script.

O código será responsável pela criação do banco de dados e das tabelas necessárias para o funcionamento do sistema.

## 7. Executando o sistema

Existem duas formas de executar o sistema.

### Opção 1 — Executar o arquivo `.exe`

Abra a pasta do projeto e execute o arquivo:

**Trabalho-CRUD-Bruno.exe**

> Caso o nome do arquivo `.exe` tenha sido alterado, execute o arquivo executável correspondente ao projeto.

Certifique-se de que a senha configurada no sistema seja a mesma senha utilizada no MySQL.

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

O sistema será compilado e iniciado automaticamente.

## 8. Requisitos

Para executar o sistema corretamente, é necessário possuir:

* Visual Studio Code;
* .NET SDK;
* Extensão C# Dev Kit;
* MySQL Server;
* MySQL Workbench;
* Banco de dados configurado através do arquivo **codigosql.sql**;
* Senha do usuário `root` configurada corretamente.

Após realizar todas essas etapas, o sistema estará pronto para ser utilizado.

---

# <span style="color:#2563EB;">9. Pesquisa</span>

## <span style="color:#2563EB;">9.1 Conexão</span>

### <span style="color:#475569;">Como C# realiza uma conexão com um banco de dados?</span>

C# utiliza uma biblioteca ou driver para se comunicar com o banco de dados.

### <span style="color:#475569;">Qual biblioteca/driver é utilizado pelo banco escolhido?</span>

No projeto, utilizamos o MySQL com a biblioteca <span style="color:#2563EB;"><strong>MySqlConnector</strong></span>.

### <span style="color:#475569;">Como essa biblioteca é adicionada ao projeto?</span>

A biblioteca é adicionada pelo <span style="color:#2563EB;"><strong>NuGet (gerenciador de pacotes para projetos .NET)</strong></span> através do comando:

```bash
dotnet add package MySqlConnector
```

### <span style="color:#475569;">O que é uma string de conexão?</span>

É uma sequência de informações que indica ao programa como acessar o banco de dados.

### <span style="color:#475569;">Quais informações aparecem em uma string de conexão?</span>

Normalmente aparecem informações como <strong>servidor, nome do banco de dados, usuário, senha</strong> e, em alguns casos, a <strong>porta</strong>.

---

## <span style="color:#2563EB;">9.2 Comandos SQL</span>

* <span style="color:#16A34A;"><strong>INSERT</strong></span>: adiciona dados ao banco.
* <span style="color:#2563EB;"><strong>SELECT</strong></span>: consulta dados.
* <span style="color:#F59E0B;"><strong>UPDATE</strong></span>: altera dados existentes.
* <span style="color:#DC2626;"><strong>DELETE</strong></span>: exclui dados.

---

## <span style="color:#2563EB;">9.3 Consulta de dados</span>

O C# recebe os resultados de um comando <span style="color:#2563EB;"><strong>SELECT</strong></span> através de um leitor, como o <span style="color:#2563EB;"><strong>MySqlDataReader</strong></span>.

Os resultados podem ser percorridos linha por linha e utilizados para criar objetos de uma classe, permitindo que os dados do banco sejam utilizados dentro do sistema.

---

## <span style="color:#2563EB;">9.4 Segurança</span>

Os parâmetros SQL permitem enviar os valores separadamente do comando SQL. Eles ajudam a evitar <span style="color:#DC2626;"><strong>SQL Injection (injeção de SQL)</strong></span>.

<span style="color:#DC2626;"><strong>SQL Injection (injeção de SQL)</strong></span> é um tipo de ataque no qual uma pessoa insere comandos SQL maliciosos em campos de um sistema para tentar acessar, alterar ou excluir dados do banco.

Quando o sistema coloca diretamente os textos digitados pelo usuário dentro de um comando SQL, ele pode ficar vulnerável a esse tipo de ataque.

Por isso, é recomendado utilizar <span style="color:#16A34A;"><strong>comandos SQL parametrizados</strong></span>.
