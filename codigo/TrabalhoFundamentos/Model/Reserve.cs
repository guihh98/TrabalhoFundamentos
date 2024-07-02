namespace TrabalhoFundamentos.Model;

public class Reserve
{
    public int clientId { get; set; }
    public int roomId { get; set; }
    public DateTime checkinDate { get; set; }
    public DateTime? checkoutDate { get; set; }
}