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
                var createTables = CreateTables();

                foreach (var table in createTables)
                {
                    ExecuteNonQuery(connection, table);
                }

            }

        }



        private static void ExecuteNonQuery(SqlConnection connection, string query)
        {
            using SqlCommand sqlCommand = new SqlCommand(query, connection);
            sqlCommand.ExecuteNonQuery();
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
    }
}
