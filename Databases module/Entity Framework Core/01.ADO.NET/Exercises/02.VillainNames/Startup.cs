namespace _02.VillainNames
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

                GetVillianCounter(connection);
            }    

        }

        private static void GetVillianCounter(SqlConnection connection)
        {
            string query = @"SELECT v.[Name], COUNT(mv.MinionId) AS Count
                                FROM Villains AS v
                                JOIN MinionsVillains AS mv ON v.Id = mv.VillainId
                                JOIN Minions AS m ON mv.MinionId = m.Id
                                GROUP BY v.[Name]
                                --HAVING COUNT(mv.MinionId) > 3";
            using (var command = new SqlCommand(query, connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var name = reader["Name"];
                        var count = reader["Count"];
                        Console.WriteLine($"{name} - {count}");

                    }
                }
            }
        }
    }
}
