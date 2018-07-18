using System;
using System.Data.SqlClient;

namespace _02.VillainNames
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();
                string villainNames = @"select v.Name, count(mv.MinionId) from Villains as v
                                        join MinionsVillains as mv on mv.VillainId = v.Id
                                        group by v.Name
                                        having COUNT(*) > 3
                                        order by count(*) desc";

                using (SqlCommand command = new SqlCommand(villainNames, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader[0]} - {reader[1]}");
                        }
                    }
                }
                connection.Close();
            }
        }
    }
}
