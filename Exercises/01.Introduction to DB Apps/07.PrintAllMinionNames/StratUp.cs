using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace _07.PrintAllMinionNames
{
    class StratUp
    {
        static void Main(string[] args)
        {
            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                var minionNames = "Select Name from Minions";
                var minions = new List<string>();

                using (SqlCommand command = new SqlCommand(minionNames, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            minions.Add((string)reader[0]);
                        }
                    }
                }
                int count = 1;
                Console.WriteLine(string.Join(", ", minions));
                while (minions.Count>=1)
                {
                    if (count%2 ==1)
                    {
                    Console.WriteLine(minions.First());
                        minions.RemoveAt(0);
                    }
                    else
                    {
                        Console.WriteLine(minions.Last());
                        minions.RemoveAt(minions.Count - 1);
                    }
                    count++;
                }
            }
        }
    }
}
