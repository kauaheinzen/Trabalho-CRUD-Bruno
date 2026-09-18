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

## 7. Requisitos

Para executar o sistema corretamente, é necessário possuir:

* Visual Studio Code;
* .NET SDK;
* Extensão C# Dev Kit;
* MySQL Server;
* MySQL Workbench;
* Banco de dados configurado através do arquivo **codigosql.sql**;
* Senha do usuário `root` configurada corretamente.

Após realizar todas essas etapas, o sistema estará pronto para ser utilizado.

## 8. Executando o sistema

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

O sistema será compilado e iniciado automaticamente.
