namespace _01.InitialSetup
{
    using Microsoft.Data.SqlClient;
    using System;
    using System.Collections.Generic;

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

                //---------------------------------------------


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
