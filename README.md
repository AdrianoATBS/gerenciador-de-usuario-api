# 👨‍💻 Gerenciador de Usuários

## 📖 Descrição

API REST desenvolvida para gerenciamento de usuários, criada com foco em estudos de desenvolvimento Backend utilizando .NET 8.
O projeto foi construído seguindo os princípios de Arquitetura em Camadas, separando responsabilidades entre Domain, Application, Infrastructure e API.

---

## 🚀 Funcionalidades

* ✅ Criar usuário
* ✅ Obter usuário por Id
* ✅ Alterar nome
* ✅ Alterar email
* ✅ Desativar usuário
* ✅ Reativar usuário
* ✅ Excluir usuário
* ✅ Login com JWT
* ✅ Autenticação e autorização via Bearer Token

---

## 🛠 Tecnologias Utilizadas

* .NET 8
* ASP.NET Core
* Entity Framework Core
* SQL Server
* JWT Authentication
* Swagger / OpenAPI
* Docker
* Azure Data Studio
* C#

---

## 🏗 Arquitetura

O projeto foi desenvolvido utilizando Arquitetura em Camadas.

```text
GerenciadorDeUsuarios

├── GerenciadorDeUsuarios.API
│   ├── Controllers
│   └── Configurações

├── GerenciadorDeUsuarios.Application
│   ├── UseCases
│   ├── Requests
│   ├── Responses
│   └── Interfaces

├── GerenciadorDeUsuarios.Domain
│   ├── Entities
│   └── Regras de Negócio

└── GerenciadorDeUsuarios.Infrastructure
    ├── Data
    ├── Repositories
    ├── Security
    ├── Middlewares
    └── Extensions
```

---

## 🎯 Objetivos de Aprendizado

Este projeto foi desenvolvido com o objetivo de praticar:

* Arquitetura em Camadas
* Repository Pattern
* Injeção de Dependência
* Entity Framework Core
* SQL Server
* JWT Authentication
* Middleware Global
* APIs REST
* Clean Code
* Separação de Responsabilidades

---

## 📌 Endpoints

| Método | Endpoint                  |
| ------ | ------------------------- |
| POST   | `/api/usuarios`           |
| POST   | `/api/usuarios/login`     |
| GET    | `/api/usuarios/{id}`      |
| PUT    | `/api/usuarios/nome`      |
| PUT    | `/api/usuarios/email`     |
| PUT    | `/api/usuarios/desativar` |
| PUT    | `/api/usuarios/reativar`  |
| DELETE | `/api/usuarios/{id}`      |

---

## ⚙ Como Executar o Projeto

### 1. Clonar o repositório

```bash
git clone <url-do-repositorio>
```

### 2. Entrar na pasta do projeto

```bash
cd GerenciadorDeUsuarios
```

### 3. Restaurar dependências

```bash
dotnet restore
```

### 4. Aplicar as migrations

```bash
dotnet ef database update \
--project GerenciadorDeUsuarios.Infrastructure \
--startup-project GerenciadorDeUsuarios.API
```

### 5. Executar a API

```bash
cd GerenciadorDeUsuarios.API

dotnet run
```

---

## 🗄 Banco de Dados

O projeto utiliza SQL Server executando via Docker.

A string de conexão pode ser configurada no arquivo:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "SuaConnectionString"
  }
}
```

---

## 🔐 Autenticação

A API utiliza JWT Authentication.

Para acessar endpoints protegidos:

1. Realize login em `/api/usuarios/login`
2. Copie o token retornado
3. Clique em **Authorize** no Swagger
4. Informe:

```text
Bearer SEU_TOKEN
```

---

## 📚 Conceitos Aplicados

Durante o desenvolvimento deste projeto foram utilizados os seguintes conceitos:

* Clean Architecture (adaptada)
* Arquitetura em Camadas
* Repository Pattern
* Dependency Injection
* JWT Authentication
* Middleware Global para tratamento de erros
* DTOs (Request e Response)
* Entity Framework Core
* SQL Server
* Swagger/OpenAPI

