using Newtonsoft.Json;
using TrabalhoFundamentos.Model;

namespace TrabalhoFundamentos.Service;

public class RoomServices
{
    private static readonly string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "/Users/guilhermehenrique/Documents/data/rooms.json");

    public static void registerNewRoom(Room novoQuarto)
    {
        List<Room> quartos = new List<Room>();

        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            quartos = JsonConvert.DeserializeObject<List<Room>>(json) ?? new List<Room>();
        }

        novoQuarto.id = quartos.Count > 0 ? quartos[^1].id + 1 : 1;
        quartos.Add(novoQuarto);

        string novoJson = JsonConvert.SerializeObject(quartos, Formatting.Indented);
        File.WriteAllText(filePath, novoJson);

        Console.WriteLine("Quarto cadastrado com sucesso!");
    }

    public static Room getRoomById(int id)
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("Nenhum quarto cadastrado.");
            return null;
        }

        string json = File.ReadAllText(filePath);
        List<Room> quartos = JsonConvert.DeserializeObject<List<Room>>(json);

        Room quartoEncontrado = quartos?.Find(q => q.id == id);

        if (quartoEncontrado != null)
        {
            Console.WriteLine($"Quarto encontrado: Número: {quartoEncontrado.number}, Tipo: {quartoEncontrado.type}, Preço: {quartoEncontrado.price}, Disponível: {quartoEncontrado.available}");
        }
        else
        {
            Console.WriteLine("Quarto não encontrado.");
        }

        return quartoEncontrado;
    }

    public static List<Room> getAllRooms()
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("Nenhum quarto cadastrado.");
            return new List<Room>();
        }

        string json = File.ReadAllText(filePath);
        List<Room> quartos = JsonConvert.DeserializeObject<List<Room>>(json);

        Console.WriteLine("Quartos cadastrados:");
        foreach (var quarto in quartos)
        {
            Console.WriteLine(
                $"ID: {quarto.id}, Número: {quarto.number}, Tipo: {quarto.type}, Preço: {quarto.price}, Disponível: {quarto.available}");
        }

        return quartos;
    }
}