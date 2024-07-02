using Newtonsoft.Json;
using TrabalhoFundamentos.Model;

namespace TrabalhoFundamentos.Service;

public class EmployeeService
{
    private static readonly string filePath = "/Users/guilhermehenrique/Documents/data/employee.json";

    public static void registerEmployee(Employee novoFuncionario)
    {
        List<Employee> funcionarios = new List<Employee>();

        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            funcionarios = JsonConvert.DeserializeObject<List<Employee>>(json) ?? new List<Employee>();
        }

        novoFuncionario.id = funcionarios.Count > 0 ? funcionarios[^1].id + 1 : 1;
        funcionarios.Add(novoFuncionario);

        string novoJson = JsonConvert.SerializeObject(funcionarios, Formatting.Indented);
        File.WriteAllText(filePath, novoJson);

        Console.WriteLine("Funcionário cadastrado com sucesso!");
    }

    public static Employee searchEmployeeById(int id)
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("Nenhum funcionário cadastrado.");
            return null;
        }

        string json = File.ReadAllText(filePath);
        List<Employee> funcionarios = JsonConvert.DeserializeObject<List<Employee>>(json);

        Employee funcionarioEncontrado = funcionarios?.Find(f => f.id == id);

        if (funcionarioEncontrado != null)
        {
            Console.WriteLine($"Funcionário encontrado: {funcionarioEncontrado.name}, Cargo: {funcionarioEncontrado.spot}, Email: {funcionarioEncontrado.email}");
        }
        else
        {
            Console.WriteLine("Funcionário não encontrado.");
        }

        return funcionarioEncontrado;
    }

    public static List<Employee> getAllEmployees()
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("Nenhum funcionário cadastrado.");
            return new List<Employee>();
        }

        string json = File.ReadAllText(filePath);
        List<Employee> employees = JsonConvert.DeserializeObject<List<Employee>>(json);

        Console.WriteLine("Funcionários cadastrados:");
        foreach (var employee in employees)
        {
            Console.WriteLine($"ID: {employee.id}, Nome: {employee.name}, Cargo: {employee.spot}, Email: {employee.email}");
        }

        return employees;
    }
}