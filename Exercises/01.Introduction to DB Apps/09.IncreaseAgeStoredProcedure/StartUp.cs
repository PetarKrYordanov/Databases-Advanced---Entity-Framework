using System;
using System.Data;
using System.Data.SqlClient;

namespace _09.IncreaseAgeStoredProcedure
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int minionId = int.Parse(Console.ReadLine());

            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();
              
                using (SqlCommand command = new SqlCommand("usp_GetOlder", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int, 0, "Id"));

                    command.Parameters[0].Value = minionId;

                    int i = command.ExecuteNonQuery();
                    if (i != 1)
                    {
                        Console.WriteLine($"There is no Minion with giver id : {minionId}");
                        return;
                    }

                }
                PrintResult(minionId, connection);

            }
        }

        private static void PrintResult(int minionId, SqlConnection connection)
        {
            string resultQuery = "Select Name,Age from Minions Where Id = @Id";
            using (SqlCommand command = new SqlCommand(resultQuery, connection))
            {
                command.Parameters.AddWithValue("@Id", minionId);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader[0]} - {reader[1]} years old");
                    }
                }
            }
        }
    }
}
