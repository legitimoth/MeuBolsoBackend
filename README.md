![Meu Bolso Backend](banner.jpg "meu bolso backend")

# 💼 MeuBolsoBackend

Backend desenvolvido em .NET Core 9 para o sistema de controle de finanças pessoais: **MeuBolso**.

## 📝 Sobre o Projeto

**MeuBolso** é uma aplicação que ajuda os usuários a monitorar suas finanças, permitindo o registro manual de compras feitas via cartão de crédito, débito ou Pix. O sistema categoriza essas compras por tags (ex.: lazer, alimentação, etc.) e calcula o total de gastos mensais, subtraindo da renda fixa do usuário.

## 🎯 Objetivo

O objetivo principal do **MeuBolso** é fornecer uma maneira simples e eficiente de acompanhar e controlar gastos pessoais.

## 🛠️ Tecnologias Utilizadas

- **.NET Core 9**: Plataforma backend para criação de APIs robustas e escaláveis.
- **Swagger**: Ferramenta de documentação e teste das APIs.
- **xUnit**: Framework de testes unitários para garantir a qualidade do código.
- **Auth0**: Plataforma de autenticação que utiliza o protocolo OAuth2 para autorização segura.

## 🚀 Funcionalidades

- Autenticação para múltiplos usuários.
- Registro manual de compras via cartão de crédito, débito ou Pix.
- Categorização de compras por **#tags**.
- Cálculo automático dos gastos mensais e saldo.
- Gráficos para análises financeiras. (Conforme eu for desenvolvendo vou melhorando aqui)

## 📚 Futuras Melhorias

- Em análise.

## 🏗️ Estrutura do Projeto

- **Api**: Contém a API principal do projeto.
- **MeuBolso.sln**: Arquivo de solução da aplicação.

## 🚧 Como Executar o Projeto

1. Clone o repositório:
   ```bash
   git clone https://github.com/seuusuario/MeuBolsoBackend.git
   ```
2. Navegue até o diretório:
   ```bash
   cd MeuBolsoBackend
   ```
3. Restaure as dependências:
   ```bash
   dotnet restore
   ```
4. Execute a aplicação:
   ```bash
   dotnet run --project Api
   ```

## ✅ Testes

Para rodar os testes unitários:

```bash
dotnet test
```
