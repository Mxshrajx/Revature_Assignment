using System;
using System.Data;
using MySql.Data.MySqlClient;

class Program
{
    static void Main()
    {
        string connectionString =
            "server=localhost;port=3306;database=StudentDB;user=root;password=Vishal@2211;";

        using var conn = new MySqlConnection(connectionString);

        try
        {
            conn.Open();
            Console.WriteLine("Connected Successfully!\n");

            ExecuteScalarExample(conn);
            ExecuteNonQueryExample(conn);
            ExecuteReaderExample(conn);
            DataAdapterExample(conn);
            SqlInjectionDemo(conn);
            ParameterizedQueryDemo(conn);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    // 1️⃣ ExecuteNonQuery (INSERT)
    static void ExecuteNonQueryExample(MySqlConnection connection)
    {
        string query = "INSERT INTO students (Name, Age) VALUES (@name, @age);";

        using var cmd = new MySqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@name", "Suresh");
        cmd.Parameters.AddWithValue("@age", 25);

        int rowsAffected = cmd.ExecuteNonQuery();
        Console.WriteLine($"ExecuteNonQuery: {rowsAffected} row(s) inserted.\n");
    }

    // 2️⃣ ExecuteScalar (Single Value)
    static void ExecuteScalarExample(MySqlConnection connection)
    {
        string query = "SELECT COUNT(*) FROM students;";

        using var cmd = new MySqlCommand(query, connection);
        int total = Convert.ToInt32(cmd.ExecuteScalar());

        Console.WriteLine($"ExecuteScalar: Total Students = {total}\n");
    }

    // 3️⃣ ExecuteReader (Read Multiple Rows)
    static void ExecuteReaderExample(MySqlConnection connection)
    {
        string query = "SELECT Id, Name, Age FROM students;";

        using var cmd = new MySqlCommand(query, connection);
        using var reader = cmd.ExecuteReader();

        Console.WriteLine("ExecuteReader: Students Table Data");

        while (reader.Read())
        {
            int id = reader.GetInt32("Id");
            string name = reader.GetString("Name");
            int age = reader.GetInt32("Age");

            Console.WriteLine($"{id} - {name} - Age: {age}");
        }

        Console.WriteLine();
    }

    // 4️⃣ DataAdapter Example (Disconnected Mode)
    static void DataAdapterExample(MySqlConnection connection)
    {
        string query = "SELECT * FROM students";

        using var adapter = new MySqlDataAdapter(query, connection);
        DataTable table = new DataTable();

        adapter.Fill(table);

        Console.WriteLine("DataAdapter Example:");
        foreach (DataRow row in table.Rows)
        {
            Console.WriteLine($"{row["Id"]} - {row["Name"]} - Age: {row["Age"]}");
        }
        Console.WriteLine();
    }

    // 5️⃣ SQL Injection Demo (Unsafe)
    static void SqlInjectionDemo(MySqlConnection connection)
    {
        string userInput = "1 OR 1=1";
        string query = $"SELECT * FROM students WHERE Id = {userInput}";

        using var cmd = new MySqlCommand(query, connection);

        try
        {
            using var reader = cmd.ExecuteReader();

            Console.WriteLine("SQL Injection Demo (Unsafe Query):");

            while (reader.Read())
            {
                Console.WriteLine($"{reader["Id"]} - {reader["Name"]}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("SQL Injection Error: " + ex.Message);
        }

        Console.WriteLine();
    }

    // 6️⃣ Parameterized Query (Safe)
    static void ParameterizedQueryDemo(MySqlConnection connection)
    {
        string nameInput = "Ramesh";
        string query = "SELECT * FROM students WHERE Name = @name";

        using var cmd = new MySqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@name", nameInput);

        using var reader = cmd.ExecuteReader();

        Console.WriteLine("Parameterized Query (Safe):");

        while (reader.Read())
        {
            Console.WriteLine($"{reader["Id"]} - {reader["Name"]}");
        }

        Console.WriteLine();
    }
}