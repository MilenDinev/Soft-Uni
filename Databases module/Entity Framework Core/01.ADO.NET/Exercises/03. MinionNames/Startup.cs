namespace _03._MinionNames
{
    using Microsoft.Data.SqlClient;
    using System;

    class Startup
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection("Server=.;Integrated Security=true;Database=MinionsDB");

            using (connection)
            {
                connection.Open();

                int id = int.Parse(Console.ReadLine());

                string villainNameQuery = "SELECT Name FROM Villains WHERE Id = @Id";
                using SqlCommand command = new SqlCommand(villainNameQuery, connection);
                command.Parameters.AddWithValue("@Id", id);
                var result = command.ExecuteScalar();

                string minnionsQuery = @"SELECT ROW_NUMBER() OVER (ORDER BY m.Name) AS RowNum, m.Name, m.Age 
                                            FROM MinionsVillains AS mv 
                                            JOIN Minions AS m ON mv.MinionId = m.Id
                                            WHERE mv.VillainId = @Id
                                        ORDER BY m.Name";

                if (result == null)
                {
                    Console.WriteLine($"No villain with ID {id} exists in the database.");
                }
                else
                {
                    Console.WriteLine($"Villain: {result}");
                    using (var minionsCommnad = new SqlCommand(minnionsQuery, connection))
                    {
                        minionsCommnad.Parameters.AddWithValue("@Id", id);
                        using (var reader = minionsCommnad.ExecuteReader())
                        {
                            if (!reader.HasRows)
                            {
                                Console.WriteLine("(no minions)");
                            }
                            while (reader.Read())
                            {
                                Console.WriteLine($"{reader[0]}. {reader[1]} {reader[2]}");
                            }
                        }

                    }
                }
            }
        }
    }
}
