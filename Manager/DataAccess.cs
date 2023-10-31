using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;

namespace Manager;

class DataAccess
{
    public int InsertProduct(string connectionString)
    {
        string name, description, image, category, price;
        Console.WriteLine("enter name");
        name = Console.ReadLine();
        Console.WriteLine("enter description");
        description = Console.ReadLine();
        Console.WriteLine("enter image");
        image = Console.ReadLine();
        Console.WriteLine("enter category");
        category = Console.ReadLine();
        Console.WriteLine("enter price");
        price = Console.ReadLine();
        string query = "INSERT INTO Products (product_name, description, image, category_id, price)" +
            "VALUES (@product_name, @description, @image, @category_id, @price)";
        using (SqlConnection cn = new SqlConnection(connectionString))
        using (SqlCommand cmd = new SqlCommand(query, cn))
        {
            cmd.Parameters.Add("@product_name", SqlDbType.VarChar, 20).Value = name;
            cmd.Parameters.Add("@description", SqlDbType.VarChar, 50).Value = description;
            cmd.Parameters.Add("@image", SqlDbType.VarChar, 50).Value = image;
            cmd.Parameters.Add("@category_id", SqlDbType.Int).Value = category;
            cmd.Parameters.Add("@price", SqlDbType.Int).Value = price;

            cn.Open();
            int rowsAffevted = cmd.ExecuteNonQuery();
            cn.Close();

            return rowsAffevted;
        }
    }

    internal void GetAllProducts(string connectionString)
    {
        string queryString = "SELECT * FROM Products";
        using (SqlConnection cn = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand(queryString, cn);
            try
            {
                cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", reader[0], reader[1], reader[2], reader[3], reader[4], reader[5]);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine();
        }
    }
    public int InsertCategory(string connectionString)
    {
        string name;
        Console.WriteLine("enter name");
        name = Console.ReadLine();
    

        string query = "insert into Category(category_name)" +
            "values(@category_name)";
        using (SqlConnection cn = new SqlConnection(connectionString))
        using (SqlCommand cmd = new SqlCommand(query, cn))
        {
            cmd.Parameters.Add("@category_name", SqlDbType.VarChar, 20).Value = name;


            cn.Open();
            int rowsAffevted = cmd.ExecuteNonQuery();
            cn.Close();

            return rowsAffevted;
        }


    }
    internal void GetAllCategory(string connectionString)
    {
        string queryString = "SELECT * FROM Category";
        using (SqlConnection cn = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand(queryString, cn);
            try
            {
                cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine("{0}\t{1}", reader[0], reader[1]);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine();
        }
    }
}