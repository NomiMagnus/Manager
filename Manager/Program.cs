
// See https://aka.ms/new-console-template for more information
using Manager;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace Manager;

class Program
{
    static void Main(string[] args)
    {
        string connectionString = "Data Source = SRV2\\PUPILS; Initial Catalog = theShop; Integrated Security = True";
        DataAccess da = new DataAccess();

        Console.WriteLine("enter category y/n?");
        string ans = Console.ReadLine();
        if (ans == "n")
        {
            da.InsertProduct(connectionString);
            da.GetAllProducts(connectionString);
        }
        else
        {
            da.InsertCategory(connectionString);
            da.GetAllCategory(connectionString);
        }

    }
}