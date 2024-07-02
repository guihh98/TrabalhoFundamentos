using JetBrains.Annotations;
using TrabalhoFundamentos.Model;
using TrabalhoFundamentos.Service;
using Xunit;

namespace TrabalhoFundamentos.Tests.Service;

[TestSubject(typeof(ClienteServices))]
public class ClienteServicesTest
{

    [Fact]
    public void TestReGisterClient()
    {
        Cliente cliente = new Cliente()
        {
            name = "João da Silva",
            email = "joao.silva@example.com"
        };
        
        ClienteServices.registerClient(cliente);
        
        var clienteCadastrado = ClienteServices.searchClientById(cliente.id);
        Assert.NotNull(clienteCadastrado);
        Assert.Equal(cliente.name, clienteCadastrado.name);
        Assert.Equal(cliente.email, clienteCadastrado.email);
    }
    [Fact]
    public void TestSearchClient()
    {
        Cliente cliente = new Cliente()
        {
            name = "Maria Souza",
            email = "maria.souza@example.com"
        };

        ClienteServices.registerClient(cliente);

        var clienteEncontrado = ClienteServices.searchClientById(cliente.id);

        Assert.NotNull(clienteEncontrado);
        Assert.Equal(cliente.name, clienteEncontrado.name);
        Assert.Equal(cliente.email, clienteEncontrado.email);
    }
    [Fact]
    public void TestUnkowClinet()
    {
        var clienteNaoEncontrado = ClienteServices.searchClientById(999); 

        Assert.Null(clienteNaoEncontrado);
    }
}