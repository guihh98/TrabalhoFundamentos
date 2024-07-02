using JetBrains.Annotations;
using TrabalhoFundamentos.Model;
using TrabalhoFundamentos.Service;
using Xunit;

namespace TrabalhoFundamentos.Tests.Service;

[TestSubject(typeof(EmployeeService))]
public class EmployeeServiceTest
{

    [Fact]
    public void TestRegisterNewEmployee()
    {
        Employee employee = new Employee
        {
            name = "Pedro Silva",
            spot = "Gerente",
            email = "pedro.silva@example.com"
        };

        EmployeeService.registerEmployee(employee);

        var employeeFounded = EmployeeService.searchEmployeeById(employee.id);
        Assert.NotNull(employeeFounded);
        Assert.Equal(employee.name, employeeFounded.name);
        Assert.Equal(employee.spot, employeeFounded.spot);
        Assert.Equal(employee.email, employeeFounded.email);
    }
    [Fact]
    public void TestSearchEmployee()
    {
        Employee employee = new Employee
        {
            name = "Ana Souza",
            spot = "Recepcionista",
            email = "ana.souza@example.com"
        };

        EmployeeService.registerEmployee(employee);

        var employeeFounded = EmployeeService.searchEmployeeById(employee.id);
        Assert.NotNull(employeeFounded);
        Assert.Equal(employee.name, employeeFounded.name);
        Assert.Equal(employee.spot, employeeFounded.spot);
        Assert.Equal(employee.email, employeeFounded.email);
    }
    [Fact]
    public void TestUnkowEmployee()
    {
        var employeeFounded = EmployeeService.searchEmployeeById(123213213); 

        Assert.Null(employeeFounded);
    }

    [Fact]
    public void TesteBuscarTodosFuncionarios()
    {
        // Arrange
        Employee employee1 = new Employee
        {
            name = "Carlos Oliveira",
            spot = "Administrador",
            email = "carlos.oliveira@example.com"
        };

        Employee employee2 = new Employee
        {
            name = "Fernanda Lima",
            spot = "Serviços Gerais",
            email = "fernanda.lima@example.com"
        };

        EmployeeService.registerEmployee(employee1);
        EmployeeService.registerEmployee(employee2);

        var allEmployees = EmployeeService.getAllEmployees();

        Assert.NotNull(allEmployees);
        Assert.Equal(2, allEmployees.Count);
        Assert.Contains(allEmployees, f => f.name == employee1.name && f.email == employee1.email);
        Assert.Contains(allEmployees, f => f.name == employee2.name && f.email == employee2.email);
    }
}