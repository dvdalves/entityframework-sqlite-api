# API CRUD com SQLite

Esta é uma simples API CRUD (Create, Read, Update, Delete) desenvolvida em .NET para fins de estudo. A API utiliza o banco de dados SQLite para armazenar os dados das pessoas.

## Tecnologias Utilizadas

- .NET 8
- ASP.NET WebAPI
- Entity Framework Core
- SQLite

## Funcionalidades

A API oferece as seguintes funcionalidades:

- Listar todas as pessoas cadastradas.
- Obter os detalhes de uma pessoa específica pelo seu ID.
- Adicionar uma nova pessoa.
- Atualizar os dados de uma pessoa existente.
- Excluir uma pessoa.

## Configuração do Banco de Dados

O banco de dados utilizado é o SQLite, um banco de dados leve e de fácil configuração. A configuração da string de conexão com o banco de dados está no arquivo `appsettings.json`.

## Executando o Projeto

Para executar o projeto localmente, siga estas etapas:

1. Certifique-se de ter o SDK do .NET Core instalado em sua máquina.
2. Clone este repositório em sua máquina local.
3. Abra o projeto em seu ambiente de desenvolvimento preferido (por exemplo, Visual Studio, Visual Studio Code).
4. Configure a string de conexão com o banco de dados no arquivo `appsettings.json`, se necessário.
5. Execute a aplicação.
