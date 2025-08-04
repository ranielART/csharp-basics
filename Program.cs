using csharp_basics.Models.Entities;

class Program
{
    static void Main(string[] args)
    {
        EmployeeEntity employee = new EmployeeEntity(1, "John Doe", "john.doe@company.com.ph", "IT Department" );

        Console.WriteLine(employee.DisplayInfo());


    }
}