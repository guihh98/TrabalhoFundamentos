using TrabalhoFundamentos.Model;

namespace TrabalhoFundamentos.Service;

public class Menu
{
    public void showMenu()
    {
        int opcao;
        do
        {
            opcao = buildMenu();

            switch (opcao)
            {
                case 1:
                    Console.WriteLine("Novo cliente");
                    registerNewClient();
                    break;
                case 2:
                    Console.WriteLine("Novo funcionário");
                    registerNewEmplye();
                    break;
                case 3:
                    Console.WriteLine("Check in selecionado.");
                    checkin();
                    break;
                case 4:
                    Console.WriteLine("Novo quarto selecionado.");
                    registerRoom();
                    break;
                case 5:
                    Console.WriteLine("Check out selecionado.");
                    checkout();
                    break;
                case 6:
                    Console.WriteLine("Pesquisar Cliente");
                    searchClient();
                    break;
                case 7:
                    Console.WriteLine("Pesquisar funcionári.");
                    searchEmployee();
                    break;
                case 8:
                    Console.WriteLine("Relatório de estadia selecionado.");
                    ReserveService.getAllReserves();
                    break;
                case 0:
                    Console.WriteLine("Saindo...");
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }

        } while (opcao != 0);
    }   
    private int buildMenu()
    {
        Console.WriteLine("\nMenu:");
        Console.WriteLine("1. Novo cliente");
        Console.WriteLine("2. Novo funcionário");
        Console.WriteLine("3. Check in");
        Console.WriteLine("4. Novo quarto");
        Console.WriteLine("5. Check out");
        Console.WriteLine("6. Pesquisar Cliente");
        Console.WriteLine("7. Pesquisar funcionário");
        Console.WriteLine("8. Relatório de estadia");
        Console.WriteLine("0. Sair");
        Console.Write("Digite a opção: ");

        int opcao;
        while (!int.TryParse(Console.ReadLine(), out opcao))
        {
            Console.WriteLine("Opção inválida. Digite um número.");
            Console.Write("Digite a opção: ");
        }

        return opcao;
    }
    
    private void registerNewClient()
    {
        Console.Write("Digite o nome do cliente: ");
        string name = Console.ReadLine();
        Console.Write("Digite o email do cliente: ");
        string email = Console.ReadLine();
        Console.Write("Digite o endereco do cliente: ");
        string adress = Console.ReadLine();
        Console.Write("Digite o cpf do cliente: ");
        string cpf = Console.ReadLine();
        Console.Write("Digite o telefone do cliente: ");
        string phone = Console.ReadLine();

        Cliente novoCliente = new Cliente()
        {
            id = 0,
            name = name,
            email = email,
            adress = adress,
            cpf = cpf,
            phone = phone
            
        };
        ClienteServices.registerClient(novoCliente);
    }
    
    private void registerNewEmplye()
    {
        Console.Write("Digite o nome do funcionário: ");
        string name = Console.ReadLine();
        Console.Write("Digite o cargo do funcionário: ");
        string spot = Console.ReadLine();
        Console.Write("Digite o email do funcionário: ");
        string email = Console.ReadLine();

        Employee novoFuncionario = new Employee
        {
            name = name,
            spot = spot,
            email = email
        };

        EmployeeService.registerEmployee(novoFuncionario);
    }
    private void searchClient()
    {
        Console.Write("Digite o ID do cliente: ");
        int id;
        
        while (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.WriteLine("ID inválido. Digite um número.");
            Console.Write("Digite o ID do cliente: ");
        }

        ClienteServices.searchClientById(id);
    }
    private void searchEmployee()
    {
        Console.Write("Digite o ID do funcionário: ");
        int id;
        while (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.WriteLine("ID inválido. Digite um número.");
            Console.Write("Digite o ID do funcionário: ");
        }

        EmployeeService.searchEmployeeById(id);
    }
    static void registerRoom()
    {
        Console.Write("Digite o número do quarto: ");
        string number = Console.ReadLine();
        Console.Write("Digite o tipo do quarto: ");
        string type = Console.ReadLine();
        Console.Write("Digite o preço do quarto: ");
        double price;
        while (!double.TryParse(Console.ReadLine(), out price))
        {
            Console.WriteLine("Preço inválido. Digite um número.");
            Console.Write("Digite o preço do quarto: ");
        }
        Console.Write("O quarto está disponível? (true/false): ");
        bool avalible;
        while (!bool.TryParse(Console.ReadLine(), out avalible))
        {
            Console.WriteLine("Disponibilidade inválida. Digite 'true' ou 'false'.");
            Console.Write("O quarto está disponível? (true/false): ");
        }

        Room novoQuarto = new Room()
        {
            number = number,
            type = type,
            price = price,
            available = avalible
        };

        RoomServices.registerNewRoom(novoQuarto);
    }
    private void checkin()
    {
        Console.Write("Digite o ID do cliente: ");
        int clientId;
        
        while (!int.TryParse(Console.ReadLine(), out clientId))
        {
            Console.WriteLine("ID inválido. Digite um número.");
            Console.Write("Digite o ID do cliente: ");
        }

        Cliente client = ClienteServices.searchClientById(clientId);
        
        Console.Write("Digite o numero do quarto: ");
        int roomId;
        
        while (!int.TryParse(Console.ReadLine(), out roomId))
        {
            Console.WriteLine("Numero inválido. Digite um número.");
            Console.Write("Digite o numero do quarto: ");
        }

        Room room = RoomServices.getRoomById(roomId);
        
        ReserveService.checkIn(client.id, room.id);
    }
    private void checkout()
    {
        Console.Write("Digite o numero do quarto: ");
        int roomId;
        
        while (!int.TryParse(Console.ReadLine(), out roomId))
        {
            Console.WriteLine("Numero inválido. Digite um número.");
            Console.Write("Digite o numero do quarto: ");
        }

        Room room = RoomServices.getRoomById(roomId);
        
        ReserveService.checkout(room.id);
    }
}