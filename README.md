# Teste Técnico — Target

Sistema web desenvolvido como solução para o teste técnico da Target, reunindo três funcionalidades: cálculo de comissões sobre vendas, movimentação de estoque e cálculo de juros por atraso.

## Funcionalidades

### 1. Cálculo de comissões

Calcula a comissão individual de cada venda conforme seu valor e apresenta os totais agrupados por vendedor.

Regras de comissão:

* Vendas inferiores a R$ 100,00: sem comissão.
* Vendas a partir de R$ 100,00 e inferiores a R$ 500,00: comissão de 1%.
* Vendas a partir de R$ 500,00: comissão de 5%.

### 2. Movimentação de estoque

Permite registrar entradas e saídas de produtos, informando o código do produto, o tipo de movimentação, a descrição e a quantidade.

A funcionalidade retorna os dados da movimentação e a quantidade atualizada em estoque. Saídas superiores à quantidade disponível são rejeitadas.

### 3. Cálculo de juros

Calcula os juros de atraso com base no valor original e na data de vencimento, aplicando a taxa de 2,5% ao dia.

O resultado apresenta o valor original, a data de vencimento, os dias de atraso, o valor dos juros e o valor total atualizado.

## Tecnologias utilizadas

### Backend

* C#
* ASP.NET Core Web API
* .NET 10
* Entity Framework Core e SQL Server na funcionalidade com persistência em banco de dados

### Frontend

* HTML5
* CSS3
* JavaScript

### Ferramentas

* Visual Studio Code
* Postman
* Git e GitHub

## Estrutura do projeto

```text
TesteTecnicoTarget/
├── Backend/
│   └── DesafioTecnico.API/
│       ├── Controllers/
│       ├── DTOs/
│       ├── Models/
│       ├── Services/
│       ├── Program.cs
│       └── appsettings.json
├── Frontend/
│   ├── index.html
│   ├── css/
│   │   └── style.css
│   └── js/
│       └── app.js
├── .gitignore
└── README.md
```

## Como executar o projeto

### Pré-requisitos

* .NET SDK 10
* Visual Studio Code ou outra IDE compatível
* Navegador web atualizado
* Extensão Live Server no Visual Studio Code
* SQL Server configurado para a funcionalidade que utiliza persistência em banco de dados

### 1. Executar o backend

Abra um terminal na pasta `Backend/DesafioTecnico.API` e execute:

```bash
dotnet restore
dotnet build
dotnet run
```

A API utilizada pelo frontend está configurada para executar em:

`http://localhost:5031`

### 2. Configurar o banco de dados

Caso necessário, configure a conexão com o SQL Server nas configurações da API, utilizando uma connection string compatível com o ambiente local.

Certifique-se de que o SQL Server esteja acessível e de que o banco de dados e a estrutura de tabelas necessários à funcionalidade persistida estejam configurados.

Não publique credenciais ou senhas de banco de dados no repositório.

### 3. Executar o frontend

Abra a pasta `Frontend` no Visual Studio Code.

No arquivo `index.html`, clique com o botão direito e selecione **Open with Live Server**.

O frontend deve ser acessado pelo endereço:

`http://127.0.0.1:5500`

Mantenha o backend em execução enquanto utiliza o sistema.

## Endpoints da API

| Método | Endpoint              | Funcionalidade                             |
| ------ | --------------------- | ------------------------------------------ |
| POST   | `/api/Comissao`       | Calcula as comissões das vendas informadas |
| POST   | `/api/Estoque`        | Registra uma movimentação de estoque       |
| POST   | `/api/Juros/calcular` | Calcula os juros por atraso                |

As requisições utilizam JSON no corpo da mensagem.

## Observações

* O frontend consome a API por meio de requisições HTTP.
* A API realiza os cálculos e as validações das regras de negócio.
* A comunicação entre frontend e backend requer que ambos estejam em execução e que a origem do frontend esteja permitida pela configuração de CORS da API.

## Autor

Desenvolvido como parte do processo seletivo da Target.
