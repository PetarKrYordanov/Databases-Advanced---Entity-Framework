using System;
using System.Data.SqlClient;

namespace _04.AddMinion
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var minionInfo = Console.ReadLine().Split();
            var villianInfo = Console.ReadLine().Split();

            var minionName = minionInfo[1];
            var minionAge = int.Parse(minionInfo[2]);
            var townName = minionInfo[3];

            var villianName = villianInfo[1];


            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();
                int townId = GetTownId(townName, connection);
                int VillainId = GetVillainId(villianName, connection);
                int minionId = InserMinionAndGetId(minionName,minionAge,townId,connection);

                AssignMinionToVillain(minionId, VillainId, connection);

                Console.WriteLine($"Successfully added {minionName} to be minion of {villianName}.");
                connection.Close();

            }
        }

        private static void AssignMinionToVillain(int minionId, int villainId, SqlConnection connection)
        {
            var minionsVillains = "insert into MinionsVillains (MinionId,VillainId) Values(@minionId ,@villainId)";

            using (SqlCommand command = new SqlCommand(minionsVillains, connection))
            {
                command.Parameters.AddWithValue("@minionId", minionId);
                command.Parameters.AddWithValue("@villainId", villainId);
     
            }
        }

        private static int InserMinionAndGetId(string minionName, int minionAge, int townId, SqlConnection connection)
        {
            string insertMinion = "Insert into Minions (Name, Age, TownId) " +
                "                   VALUES(@name,@age,@townId)";

            using (SqlCommand command = new SqlCommand(insertMinion, connection))
            {
                command.Parameters.AddWithValue("@name", minionName);
                command.Parameters.AddWithValue("@age", minionAge);
                command.Parameters.AddWithValue("@townId", townId);
                command.ExecuteNonQuery();
            }

            var minionId = "select id from  Minions where Name = @Name";
            using (SqlCommand comand = new SqlCommand(minionId, connection))
            {
                comand.Parameters.AddWithValue("@Name", minionName);

                return (int)comand.ExecuteScalar();
            }
        }

        private static int GetVillainId(string villianName, SqlConnection connection)
        {
            string villainSql = "Select id from Villains WHERE Name = @Name";
            using (SqlCommand villainComand = new SqlCommand(villainSql, connection))
            {
                villainComand.Parameters.AddWithValue("@Name", villianName);

                if (villainComand.ExecuteScalar() == null && DBNull.Value != villainComand.ExecuteScalar())
                {
                    InsertIntoVillains(villianName, connection);
                }

                return (int)villainComand.ExecuteScalar();
            }
        }

        private static void InsertIntoVillains(string villianName, SqlConnection connection)
        {
            string insertVillainsString = "insert into Villains(Name) Values(@Name)";
            using (SqlCommand insertTown = new SqlCommand(insertVillainsString, connection))
            {

                insertTown.Parameters.AddWithValue("@Name", villianName);
                insertTown.ExecuteNonQuery();
                Console.WriteLine($"Villain {villianName} was added to the database.");
            }
        }

        private static int GetTownId(string townName, SqlConnection connection)
        {
            string townSql = "Select id from Towns WHERE Name = @Name";
            using (SqlCommand townComand = new SqlCommand(townSql, connection))
            {
                townComand.Parameters.AddWithValue("@Name", townName);

                if (townComand.ExecuteScalar() == null && DBNull.Value != townComand.ExecuteScalar())
                {
                    InsertIntoTowns(townName, connection);
                }
                return (int)townComand.ExecuteScalar();
            }
        }

        private static void InsertIntoTowns(string townName, SqlConnection connection)
        {
            string insertTownString = "insert into Towns(Name) Values(@TownName)";
            using (SqlCommand insertTown = new SqlCommand(insertTownString, connection))
            {

                insertTown.Parameters.AddWithValue("@TownName", townName);
                insertTown.ExecuteNonQuery();

                Console.WriteLine($"Town {townName} was added to the database.");
            }
        }
    }
}
