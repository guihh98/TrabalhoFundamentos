using Newtonsoft.Json;

namespace TrabalhoFundamentos.Service;

using Model;

public class ClienteServices
{
    private static readonly string filePath = "/Users/guilhermehenrique/Documents/data/clientes.json";
    
    public static void registerClient(Cliente novoCliente)
    {
        List<Cliente> clientes = new List<Cliente>();

        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            clientes = JsonConvert.DeserializeObject<List<Cliente>>(json) ?? new List<Cliente>();
        }

        novoCliente.id = clientes.Count > 0 ? clientes[^1].id + 1 : 1;
        clientes.Add(novoCliente);

        string novoJson = JsonConvert.SerializeObject(clientes, Formatting.Indented);
        File.WriteAllText(filePath, novoJson);

        Console.WriteLine("Cliente cadastrado com sucesso!");
    }

    public static Cliente searchClientById(int id)
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("Nenhum cliente cadastrado.");
            return null;
        }

        string json = File.ReadAllText(filePath);
        List<Cliente> clientes = JsonConvert.DeserializeObject<List<Cliente>>(json);

        Cliente clienteEncontrado = clientes?.Find(c => c.id == id);

        if (clienteEncontrado != null)
        {
            Console.WriteLine($"Cliente encontrado: {clienteEncontrado.name}, Email: {clienteEncontrado.email}");
        }
        else
        {
            Console.WriteLine("Cliente não encontrado.");
        }

        return clienteEncontrado;
    }

    public static List<Cliente> searchAllClients()
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("Nenhum cliente cadastrado.");
            return new List<Cliente>();
        }

        string json = File.ReadAllText(filePath);
        List<Cliente> clientes = JsonConvert.DeserializeObject<List<Cliente>>(json);

        Console.WriteLine("Clientes cadastrados:");
        foreach (var cliente in clientes)
        {
            Console.WriteLine($"ID: {cliente.id}, Nome: {cliente.name}, Email: {cliente.email}");
        }

        return clientes;
    }
}