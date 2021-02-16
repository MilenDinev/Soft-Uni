namespace _01.InitialSetup
{
    using System;
    using Microsoft.Data.SqlClient;

    class Startup
    {
        static void Main(string[] args)
        {
            using (var connection = new SqlConnection("Server=.;Integrated Security=true;Database=SoftUni"))
            {
                connection.Open();
                string query = "Use MinionsDB" +
                    " " +
                   "CREATE TABLE EvilnessFactors " +
                    "(Id INT PRIMARY KEY IDENTITY, " +
                    "Name VARCHAR(30) NOT NULL)" +
                    " " +
                    "CREATE TABLE Villains " +
                    "(Id INT PRIMARY KEY IDENTITY, " +
                    "Name VARCHAR(30) NOT NULL, " +
                    "EvilnessFactorId INT FOREIGN KEY REFERENCES EvilnessFactors(Id) NOT NULL)" +
                    " " +
                  "CREATE TABLE Countries " +
                    "(Id INT PRIMARY KEY IDENTITY, " +
                    "Name VARCHAR(30) NOT NULL)" +
                    " " +
                    "CREATE TABLE Towns " +
                    "(Id INT PRIMARY KEY IDENTITY, " +
                    "Name VARCHAR(30) NOT NULL, " +
                    "CountryCode INT FOREIGN KEY REFERENCES Countries(Id) NOT NULL)" +
                    " " +
                    "CREATE TABLE Minions" +
                    "( Id INT PRIMARY KEY IDENTITY, " +
                    "Name VARCHAR(30) NOT NULL, " +
                    "Age INT NOT NULL, " +
                    "TownId INT FOREIGN KEY REFERENCES Towns(Id) NOT NULL) " +
                    " " +
                  "CREATE TABLE MinionsVillains " +
                    "( MinionId INT, " +
                    "VillainId INT " +
                    "CONSTRAINT PK_Minions_Villains PRIMARY KEY (MinionId, VillainId), " +
                    "CONSTRAINT FK_Minions FOREIGN KEY (MinionId) REFERENCES Minions(Id), " +
                    "CONSTRAINT FK_Villains FOREIGN KEY (VillainId) REFERENCES VIllains(Id) )";

                SqlCommand sqlCommand = new SqlCommand(query, connection);
                var rowsAffected = sqlCommand.ExecuteNonQuery();
                Console.WriteLine(rowsAffected);
            }
        }
    }
}
