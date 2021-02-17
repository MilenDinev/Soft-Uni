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
                string[] minionInfo = Console.ReadLine().Split();
                string minionName = minionInfo[1];
                int minionAge = int.Parse(minionInfo[2]);
                string town = minionInfo[3];
                if (minionInfo[3] == "Stara")
                {
                    town = minionInfo[3] + ' ' + minionInfo[4];
                }

                string[] villianInfo = Console.ReadLine().Split();
                string villianName = villianInfo[1];

                int? townId = GetTownId(connection, town);

                if (townId == null)
                {
                    string createTownQuery = "INSERT INTO Towns (Name, CountryCode) VALUES (@name, 1)";
                    using var command = new SqlCommand(createTownQuery, connection);
                    command.Parameters.AddWithValue("@name", town);
                    command.ExecuteNonQuery();
                    townId = GetTownId(connection, town);
                    Console.WriteLine($"Town {town} was added to the database");
                }

                int? villainId = GetVillainId(connection, villianName);

                if (villainId == null)
                {
                    string addVillainQuery = "INSERT INTO Villains (Name, EvilnessFactorId) VALUES (@Name, 3)";
                    using var command = new SqlCommand(addVillainQuery, connection);
                    command.Parameters.AddWithValue("@Name", villianName);
                    command.ExecuteNonQuery();
                    townId = GetVillainId(connection, villianName);
                    Console.WriteLine($"Villain {villianName} was added to the database");
                }

                CreateMinion(connection, minionName, minionAge, townId);

                int? minionId = GetMinionId(connection, minionName);

                InserVillainMinion(connection, villainId, minionId);

                Console.WriteLine($"Successfully added {minionName} to be minion of {villianName}");
            }
        }

        private static void InserVillainMinion(SqlConnection connection, int? villainId, int? minionId)
        {
            var insertIntoMinVil = "INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@MinionId, @VillainId)";
            using var command = new SqlCommand(insertIntoMinVil, connection);
            command.Parameters.AddWithValue("@MinionId", minionId);
            command.Parameters.AddWithValue("@VillainId", villainId);
            command.ExecuteNonQuery();
        }

        private static int? GetMinionId(SqlConnection connection, string minionName)
        {
            var minionIdQuery = "SELECT Id FROM Minions WHERE Name = @Name";
            var command = new SqlCommand(minionIdQuery, connection);
            command.Parameters.AddWithValue("@Name", minionName);
            var minonId = command.ExecuteScalar();
            return (int?)minonId;
        }

        private static void CreateMinion(SqlConnection connection, string minionName, int minionAge, int? townId)
        {
            string createMinion = "INSERT INTO Minions (Name, Age, TownId) VALUES (@Name,@Age, @TownId)";
            using var command = new SqlCommand(createMinion, connection);
            command.Parameters.AddWithValue("@Name", minionName);
            command.Parameters.AddWithValue("@Age", minionAge);
            command.Parameters.AddWithValue("@TownId", townId);
            command.ExecuteNonQuery();
        }

        private static int? GetVillainId(SqlConnection connection, string villianName)
        {
            string villainQuery = "SELECT Id FROM Villains WHERE Name = @Name";
            using var command = new SqlCommand(villainQuery, connection);
            command.Parameters.AddWithValue("@Name", villianName);
            var villainId = command.ExecuteScalar();
            return (int?)villainId;
        }

        private static int? GetTownId(SqlConnection connection, string town)
        {
            string townIdQuery = "SELECT Id FROM Towns WHERE Name = @town";
            using var command = new SqlCommand(townIdQuery, connection);
            command.Parameters.AddWithValue("@town", town);
            var townId = command.ExecuteScalar();
            return (int?)townId;
        }
    }
}
