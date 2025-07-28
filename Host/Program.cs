using App;
using Contracts;
using Domain;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

internal class Program
{
    private static void Main(string[] args)
    {
        //var config = new ConfigurationBuilder().AddJsonFile("appSettings.json").Build();
        //IDbConnection db = new SqlConnection(config.GetSection("Constr").Value);
        //try
        //{
        //    db.Open();

        //    string query = "SELECT * FROM foods";

        //    using (IDbCommand cmd = db.CreateCommand())
        //    {
        //        cmd.CommandText = query;

        //        using (IDataReader reader = cmd.ExecuteReader())
        //        {
        //            Console.WriteLine(" ID | Name | Category | Price | isDeleted ");
        //            Console.WriteLine("***********************");

        //            while (reader.Read())
        //            {
        //                int id = reader.GetInt32(0);
        //                string name = reader.GetString(1);
        //                string category = reader.GetString(2);
        //                decimal price = reader.GetDecimal(3);
        //                bool isDeleted = reader.GetBoolean(4);

        //                Console.WriteLine($"{id,-2} | {name,-15} | {category,-14} | {price} | {isDeleted}");
        //            }
        //        }
        //    }

        //    db.Close();
        //}
        //catch (Exception ex)
        //{
        //    Console.WriteLine($" Error: {ex.Message}");
        //}


        FoodService fl = new FoodService();
        ////FoodDTO fd1 = new FoodDTO("pizza", "italian", 50);
        //FoodDTO fd2 = new FoodDTO("burger", "junk food", 35);
        //FoodDTO fd3 = new FoodDTO("pasta", "italian", 45);
        ////fl.Add(fd1);
        //fl.Add(fd2);
        //fl.Add(fd3);
        var foods = fl.GetAll();
        foreach (var n in foods)
        {
            Console.Write($"{n.Id}){n.Name} ,");
        }
        //Console.WriteLine();
        //Console.WriteLine();
        //fl.Remove(8);
        //var foo = fl.GetAll();
        //foreach (var n in foo)
        //{
        //    Console.Write($"{n.Id}:{n.Name} ,");
        //}
        //Console.WriteLine();
        //FoodDTO fd4 = new FoodDTO("sandwich", "junk food", 35);
        //FoodDTO fd5 = new FoodDTO("mansaf", "arabic food", 45);
        //fl.Add(fd4);
        //fl.Add(fd5);
        //var fo = fl.GetAll();
        //foreach (var n in fo)
        //{
        //    Console.Write($"{n.Id}:{n.Name} ,");
        // }
        //Console.WriteLine();
        //Console.WriteLine();
        //FoodDTO fd6 = new FoodDTO("pesto pasta", "italian", 45);
        //fl.Update(9, fd6);
        //var f = fl.GetAll();
        //foreach (var n in f)
        //{
        //    Console.Write($"{n.Id}:{n.Name} ,");
        //}

        //Console.WriteLine();
        //Console.WriteLine();
        //FoodDTO fd6 = new FoodDTO("Sushi Roll", "italian", 45);
        //fl.Update(2, fd6);
        //var f = fl.GetAll();
        //foreach (var n in f)
        //{
        //    Console.Write($"{n.Id}:{n.Name} ,");
        //}
        Console.ReadKey();
    }
}
