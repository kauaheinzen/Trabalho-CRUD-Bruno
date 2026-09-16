# Projeto CRUD em C#

Trabalho escolar desenvolvido por 3 alunos do 1º ano do Ensino Médio Técnico do SENAC.

## Autores

- Filipe Rocha
- Kauã Heinzen
- Pedro Soares

---

# Manual de Instalação e Execução do Sistema Escolar

Olá! Neste guia será mostrado como instalar e executar o sistema.

## Passo a passo

**1.** Instale o Visual Studio Code (VS Code), caso ainda não tenha:

https://code.visualstudio.com/

**2.** Instale o .NET:

https://dotnet.microsoft.com/en-us/download

**3.** Abra o VS Code, vá até a aba **Extensões** e instale a extensão **C# Dev Kit**.

**4.** Clone ou baixe este repositório e abra a pasta do projeto no VS Code.

**5.** Abra o MySQL Workbench e copie o código presente no arquivo **codigosql.sql**, colando-o na área de consultas.

Caso ainda não tenha o MySQL Workbench instalado, faça o download em:

https://www.mysql.com/products/workbench/

**Importante:** defina a senha do usuário **root** como **Senac2026**. Caso utilize outra senha, altere a configuração de conexão com o banco de dados no arquivo **MySql.cs** na linha 4 para corresponder à senha escolhida.

**6.** No MySQL Workbench, clique no botão de **Executar** (ícone de raio) para criar o banco de dados e as tabelas.

**7.** No VS Code, abra o terminal integrado e execute o comando:

```bash
dotnet restore

