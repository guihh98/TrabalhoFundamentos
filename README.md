# TrabalhoFundamentos
Repositorio destinado para hospedar o codigo e os documentos do trabalho para apresentacao

## Visão Geral

Este projeto é uma aplicação em C# que gerencia de hotelaria. Os dados são armazenados e recuperados de arquivos JSON. O projeto está estruturado em duas principais pastas: `Models` e `Services`.

## Estrutura do Projeto

project/
│
├── Models/
│ ├── Cliente.cs
│ ├── Employee.cs
│ └── Reserve.cs
│ └── Room.cs
|
└── Services/
├── ClienteService.cs
├── EmplyeeService.cs
└── HotelService.cs
└── Menu.cs
└── ReserveService.cs
└── RoomService.cs


### Models

A pasta `Models` contém as classes que representam os dados da aplicação. Cada classe define a estrutura dos objetos que são gerenciados pela aplicação.

- **Cliente.cs**: Define a estrutura dos dados de um cliente, incluindo propriedades como `id`, `name`, `email`, etc.
- **Employee.cs**: Define a estrutura dos dados de um funcionário, incluindo propriedades como `id`, `name`, `spot`, etc.
- **Room.cs**: Define a estrutura dos dados de um quarto, incluindo propriedades como `number`, `type`, `price`, etc.

### Services

A pasta `Services` contém a lógica de negócio da aplicação. Cada serviço é responsável por gerenciar um tipo específico de dado.

- **ClientService.cs**: Contém métodos para gerenciar os dados dos clientes, como adicionar, e buscar clientes.
- **EmployeeService.cs**: Contém métodos para gerenciar os dados dos funcionários, como adicionar e buscar funcionários.
- **RoomService.cs**: Contém métodos para gerenciar os dados dos quartos, como cadastrar e buscar quartos.

## Configuração

1. **Clonar o repositório**:
   ```bash
   [git clone https://github.com/seu-usuario/seu-repositorio.git](https://github.com/guihh98/TrabalhoFundamentos.git)

dotnet restore

dotnet build

dotnet run

