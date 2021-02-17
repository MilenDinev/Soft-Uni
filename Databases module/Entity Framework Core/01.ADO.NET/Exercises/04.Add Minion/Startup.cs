namespace _04.Add_Minion
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
                string[] input = Console.ReadLine().Split();
                string minionName = input[1];
                int age = int.Parse(input[2]);
                string town = input[3];

                if (input[3] == "Stara")
                {
                    town = input[3] + ' ' + input[4];
                }

                string townIdQuery = "SELECT Id FROM Towns WHERE Name = @town";
                using SqlCommand command = new SqlCommand(townIdQuery, connection);
                command.Parameters.AddWithValue("@town", town);
                var result = command.ExecuteScalar();
                Console.WriteLine(result);


            }
        }
    }
}
