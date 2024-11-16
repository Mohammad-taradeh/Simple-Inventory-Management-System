using Microsoft.Data.SqlClient;
using InventorySystem.AppSettings;
using InventorySystem.Products;

namespace Inventory_System.DB;

public sealed class DataSource
{
    private string _connectionString;

    public DataSource()
    {
        _connectionString = AppSettingsInitializer.Instance.ConnectionString;
    }

    public async Task<bool> ProductExist(string name)
    {
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            SqlCommand command = new SqlCommand(@"SELECT * FROM Products " + $"WHERE Name = '{name}'", connection);
            command.Connection.Open();
            var result = command.ExecuteNonQuery();
            if (result == -1)
                return false;
            return true;
        }
    }
    public async Task<List<Product>> GetProducts (string? name = null)
    {
        var products = new List<Product>();
        using (SqlConnection connection = new(_connectionString))
        {
        string query = @"SELECT * FROM Products" + (!string.IsNullOrEmpty(name) ? $"WHERE Name = {name}" : "");
            SqlCommand command = new SqlCommand(query, connection);
            command.Connection.Open();
            SqlDataReader reader = command.ExecuteReader(); 
            if(reader.HasRows)
            {
                while(reader.Read())
                {
                    var price = new Price(double.Parse(reader["Price"].ToString()),
                        Enum.Parse<CurrencyType>(reader["Currency"].ToString()));
                    var product = new Product(reader["Name"].ToString(),
                        price,
                        int.Parse(reader["Quantity"].ToString())
                        );
                    products.Add(product);
                }
            }
            else
            {
                Console.WriteLine("No data found.");
            }
            reader.Close();
        }
        return products;
    }

    public async Task<bool> AddProduct(Product product)
    {
        using (SqlConnection connection = new(_connectionString))
        {
            SqlCommand command = new(
                $"INSERT INTO Products (Name, Quantity, Price, Currency)" +
                $"Values ('{product.Name}', {product.Quantity}, {product.Price.Value}, '{product.Price.Type.ToString()}')", connection);
            connection.Open();
            await command.ExecuteScalarAsync();
            connection.Close();
            return true;
        }
    }

    public async Task DeleteProduct(string name)
    {
        using (SqlConnection connection = new(_connectionString))
        {
            SqlCommand command = new($"DELETE FROM Products WHERE Name='{name}'", connection);
            connection.Open();
            int rowsAffected = await command.ExecuteNonQueryAsync();
        }
    }
    public async Task<Product> UpdateProduct(string name, Product product)
    {
        using (SqlConnection connection = new(_connectionString))
        {
            string query = @$"UPDATE Products
                            SET Name='{product.Name}', Quantity='{product.Quantity}', Price='{product.Price.Value}', Currency='{product.Price.Type.ToString()}'
                            WHERE Name='{name}'
                            SELECT * FROM Products WHERE Name='{product.Name}'";
            SqlCommand command = new(query, connection);
            connection.Open();
            using(SqlDataReader reader = await command.ExecuteReaderAsync())
            {
                if(reader.Read())
                {
                    var updatedProduct = new Product()
                    {
                        Name = reader.GetString(reader.GetOrdinal("Name")),
                        Quantity = reader.GetInt32(reader.GetOrdinal("Quantity")),
                        Price = new Price()
                        {
                            Value = reader.GetDouble(reader.GetOrdinal("Price")),
                            Type = Enum.Parse<CurrencyType>(reader.GetString(reader.GetOrdinal("Currency")))
                        }
                    };
                    connection.Close();
                    return updatedProduct;
                }
                return null;
            }

        }
    }
}

