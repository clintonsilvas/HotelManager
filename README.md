🏨 HotelManager

Sistema simples desenvolvido para demonstrar testes automatizados de unidade utilizando C#, .NET e xUnit.

📌 Sobre o projeto

O HotelManager é um domínio fictício criado apenas para fins didáticos.
O objetivo é implementar funcionalidades básicas de gerenciamento de hotel e, principalmente, demonstrar boas práticas de testes unitários, incluindo organização por branches, pull requests e CI.

A aplicação possui três partes principais:

✔ Testes Unitários

Foram desenvolvidos testes automatizados utilizando xUnit, testando as regras de negócio dos serviços.

🧩 Tecnologias Utilizadas
💻 Linguagem e Framework

C# 12

.NET 8

Biblioteca de testes: xUnit

Gerenciamento de dependências: NuGet

IDE recomendada: Visual Studio 2022

🧪 Framework de Testes

Utilizamos o xUnit por ser:

Gratuito e open source

Amplamente utilizado em projetos .NET

Integrado ao Visual Studio

Simples para testar regras de negócio puras

📁 Estrutura do Projeto
HotelManager/
│
├── HotelManager/               # Projeto principal
│   ├── Models/                 # Classes de domínio (Cliente, Quarto)
│   └── Services/               # Regras de negócio (ClienteService, QuartoService)
│
└── HotelManager.Tests/         # Projeto de testes
    ├── ClienteServiceTests.cs  # Testes de Cliente
    └── QuartoServiceTests.cs   # Testes de Quarto

▶ Como executar os testes
✔ 1. Via Visual Studio

Abra a solução no Visual Studio

Vá ao menu Test > Run All Tests

Todos os testes devem ser executados automaticamente

ou pressione o atalho:

Ctrl + R, A

✔ 2. Via linha de comando (CLI)

No diretório da solução, execute:

dotnet test


O .NET irá:

Restaurar pacotes

Compilar o projeto

Executar os testes e exibir o resultado no terminal

✔ Exemplos de testes realizados
🔸 Validação de cadastro de cliente

Cliente válido deve ser cadastrado

Cliente com dados inválidos deve falhar

Documento duplicado deve ser rejeitado

🔸 Validação de quarto

Quarto válido deve ser cadastrado

Número duplicado deve ser rejeitado

Deve ser possível ocupar e liberar quarto

👥 Equipe do Projeto

Clinton

Samuel

Baldini

Rafael

Projeto desenvolvido para trabalho acadêmico envolvendo:

GitFlow

Pull Requests

Testes unitários

Boas práticas de versionamento colaborativo