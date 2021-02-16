namespace _01.InitialSetup
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
                //var createTables = CreateTables();

                //foreach (var table in createTables)
                //{
                //    ExecuteNonQuery(connection, table);
                //}

                //var insertData = InserDataToTables();
                //foreach (var record in insertData)
                //{
                //    ExecuteNonQuery(connection, record);
                //}

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

        private static string[] InserDataToTables()
        {
            var result = new string[]
            {
                "INSERT INTO Countries ([Name]) VALUES ('Bulgaria'), ('Norway'), ('Cyprus'), ('Greece'), ('UK')",
                "INSERT INTO Towns ([Name], CountryCode) VALUES ('Stara Zagora', 1), ('Athens', 4), ('London', 5), ('Oslo', 2), ('Larnaca', 3)",
                "INSERT INTO Minions ([Name], Age, TownId) VALUES ('Milen', 25, 1), ('George', 20, 5), ('John', 18, 4), ('Kevin', 28, 2), ('Jimm', 17, 3)",
                "INSERT INTO EvilnessFactors ([Name]) VALUES ('bad'), ('good'), ('evil'), ('super evil'), (' super good')",
                "INSERT INTO Villains ([Name], EvilnessFactorId) VALUES ('Ivan', 1), ('Mitko', 5), ('Pesho', 3), ('Toshko', 2), ('Anton', 4)",
                "INSERT INTO MinionsVillains VALUES (1,2), (2,4), (3,1), (5,3), (4,5)"
            };

            return result;
        }    
        private static string[] CreateTables()
        {
            var result = new string[]
            {
                "CREATE TABLE EvilnessFactors (Id INT PRIMARY KEY IDENTITY, Name VARCHAR(30) NOT NULL)",
                "CREATE TABLE Villains (Id INT PRIMARY KEY IDENTITY, Name VARCHAR(30) NOT NULL, EvilnessFactorId INT FOREIGN KEY REFERENCES EvilnessFactors(Id) NOT NULL)",
                "CREATE TABLE Countries (Id INT PRIMARY KEY IDENTITY, Name VARCHAR(30) NOT NULL)",
                "CREATE TABLE Towns (Id INT PRIMARY KEY IDENTITY, Name VARCHAR(30) NOT NULL, CountryCode INT FOREIGN KEY REFERENCES Countries(Id) NOT NULL)",
                "CREATE TABLE Minions ( Id INT PRIMARY KEY IDENTITY, Name VARCHAR(30) NOT NULL, Age INT NOT NULL, TownId INT FOREIGN KEY REFERENCES Towns(Id) NOT NULL)",
                "CREATE TABLE MinionsVillains ( MinionId INT, VillainId INT CONSTRAINT PK_Minions_Villains PRIMARY KEY (MinionId, VillainId), CONSTRAINT FK_Villains FOREIGN KEY (VillainId) REFERENCES VIllains(Id) )"
            };

            return result;
        }

        private static void ExecuteNonQuery(SqlConnection connection, string query)
        {
            using SqlCommand sqlCommand = new SqlCommand(query, connection);
            sqlCommand.ExecuteNonQuery();
        }
    }
}
