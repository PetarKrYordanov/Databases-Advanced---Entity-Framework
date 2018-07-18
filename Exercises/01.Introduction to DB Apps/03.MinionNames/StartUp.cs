using System;
using System.Data.SqlClient;

namespace _03.MinionNames
{
    class StartUp
    {
        static void Main(string[] args)
        {
            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {

                var villianId = int.Parse(Console.ReadLine());

                var vilianNameQuery = "select Name from Villains where id = @Id";

                SqlCommand villians = new SqlCommand(vilianNameQuery, connection);
                villians.Parameters.AddWithValue("@Id", villianId);
                connection.Open();

                using (SqlDataReader reader = villians.ExecuteReader())
                {

                    if (reader.Read())
                    {
                        Console.WriteLine($"Villain: {reader[0]}");
                    }
                    else
                    {
                        Console.WriteLine($"No villain with ID {villianId} exists in the database.");
                        connection.Close();
                        return;
                    }                 
                }
                string minionNames = $"select  m.Name, m.Age from Minions as m " +
                                        $"join MinionsVillains as mv on mv.MinionId = m.Id " +
                                        $"join Villains as v on v.Id = mv.VillainId " +
                                      $"where v.Id = @Id" +
                                      $" order by m.Name";
                SqlCommand minions = new SqlCommand(minionNames, connection);
                minions.Parameters.AddWithValue("@Id", villianId);

                using (SqlDataReader minionReader = minions.ExecuteReader())
                {
                    if (!minionReader.HasRows)
                    {
                        Console.WriteLine("(no minions)");
                    }
                    int row = 1;
                    while (minionReader.Read())
                    {
                        Console.WriteLine($"{row++}. {minionReader[0]} {minionReader[1]}");
                    }
                }


                connection.Close();
            }
        }
    }
}
