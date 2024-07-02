using Newtonsoft.Json;
using TrabalhoFundamentos.Model;

namespace TrabalhoFundamentos.Service;

public class ReserveService
{
    private static readonly string quartosFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "/Users/guilhermehenrique/Documents/data/rooms.json");
    private static readonly string checkinFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "/Users/guilhermehenrique/Documents/data/reserves.json");

    public static void checkIn(int clienteId, int quartoId)
    {
        if (!File.Exists(quartosFilePath))
        {
            Console.WriteLine("Nenhum quarto cadastrado.");
            return;
        }

        string json = File.ReadAllText(quartosFilePath);
        List<Room> quartos = JsonConvert.DeserializeObject<List<Room>>(json);

        Room quarto = quartos?.Find(q => q.id == quartoId);
        if (quarto == null)
        {
            Console.WriteLine("Quarto não encontrado.");
            return;
        }

        if (!quarto.available)
        {
            Console.WriteLine("Quarto não está disponível.");
            return;
        }

        quarto.available = false;

        string jsonNovo = JsonConvert.SerializeObject(quartos, Formatting.Indented);
        File.WriteAllText(quartosFilePath, jsonNovo);

        Reserve checkin = new Reserve()
        {
            clientId = clienteId,
            roomId = quartoId,
            checkinDate = DateTime.Now
        };

        List<Reserve> checkins = new List<Reserve>();
        if (File.Exists(checkinFilePath))
        {
            string checkinJson = File.ReadAllText(checkinFilePath);
            checkins = JsonConvert.DeserializeObject<List<Reserve>>(checkinJson) ?? new List<Reserve>();
        }

        checkins.Add(checkin);
        string novoCheckinJson = JsonConvert.SerializeObject(checkins, Formatting.Indented);
        File.WriteAllText(checkinFilePath, novoCheckinJson);

        Console.WriteLine("Check-in realizado com sucesso!");
    }

    public static void checkout(int quartoId)
    {
        if (!File.Exists(quartosFilePath))
        {
            Console.WriteLine("Nenhum quarto cadastrado.");
            return;
        }

        string json = File.ReadAllText(quartosFilePath);
        List<Room> quartos = JsonConvert.DeserializeObject<List<Room>>(json);

        Room quarto = quartos?.Find(q => q.id == quartoId);
        if (quarto == null)
        {
            Console.WriteLine("Quarto não encontrado.");
            return;
        }

        if (quarto.available)
        {
            Console.WriteLine("Quarto já está disponível.");
            return;
        }

        quarto.available = true;

        string novoJson = JsonConvert.SerializeObject(quartos, Formatting.Indented);
        File.WriteAllText(quartosFilePath, novoJson);

        if (!File.Exists(checkinFilePath))
        {
            Console.WriteLine("Nenhum check-in registrado.");
            return;
        }

        string checkinJson = File.ReadAllText(checkinFilePath);
        List<Reserve> checkins = JsonConvert.DeserializeObject<List<Reserve>>(checkinJson);
        Reserve checkin = checkins?.Find(c => c.roomId == quartoId && c.checkoutDate == null);

        if (checkin == null)
        {
            Console.WriteLine("Nenhum check-in ativo encontrado para este quarto.");
            return;
        }

        checkin.checkoutDate = DateTime.Now;
        string novoCheckinJson = JsonConvert.SerializeObject(checkins, Formatting.Indented);
        File.WriteAllText(checkinFilePath, novoCheckinJson);

        Console.WriteLine("Check-out realizado com sucesso!");
    }
    public static void getAllReserves()
    {
        if (!File.Exists(checkinFilePath))
        {
            Console.WriteLine("Nenhuma reserva encontrada.");
            return;
        }

        string checkinJson = File.ReadAllText(checkinFilePath);
        List<Reserve> reserves = JsonConvert.DeserializeObject<List<Reserve>>(checkinJson);

        Console.WriteLine("Reservas:");
        foreach (var reserve in reserves)
        { 
            Console.WriteLine($"Cliente ID: {reserve.clientId}, Quarto ID: {reserve.roomId}" +
                              $", Data de Check-in: {reserve.checkinDate}, Data de Check-out: {reserve.checkoutDate}");
        }
    }
}