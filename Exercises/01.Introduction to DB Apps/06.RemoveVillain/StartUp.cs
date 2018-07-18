using System;
using System.Data.SqlClient;

namespace _06.RemoveVillain
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var villianIdInput = int.Parse(Console.ReadLine());

            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                int villianId = GetVillianId(villianIdInput, connection,transaction);
                if (villianId == 0)
                {
                    Console.WriteLine("No such villain was found.");
                }
                else
                {
                    try
                    {
                        int rowsAffected = ReleaseMinions(villianId, connection,transaction);
                        string villianName = GetNameAndDeleteVillain(villianId, connection,transaction);

                        Console.WriteLine($"{villianName} was deleted.");
                        Console.WriteLine($"{rowsAffected} minions were released.");

                    }
                    catch (SqlException e)
                    {
                        transaction.Rollback();
                    }
                }
                transaction.Commit();
            }
        }

        private static string GetNameAndDeleteVillain(int villianId, SqlConnection connection,SqlTransaction transaction)
        {
            var villainName = "select Name from Villains where Id = @Id";
            var name = "";
            using (SqlCommand command = new SqlCommand(villainName, connection,transaction))
            {
                command.Parameters.AddWithValue("@Id", villianId);

                name = (string) command.ExecuteScalar();
            }


            string deleteVillainQuery = "delete Villains where Id = @Id";

            using (SqlCommand command = new SqlCommand(deleteVillainQuery, connection,transaction))
            {
                command.Parameters.AddWithValue("@Id", villianId);

                command.ExecuteNonQuery();
            }
            return name;
        }

        private static int ReleaseMinions(int villianId, SqlConnection connection,SqlTransaction transaction)
        {
            string ReleaseQuery = "delete MinionsVillains where VillainId = @Id";

            using (SqlCommand command = new SqlCommand(ReleaseQuery, connection,transaction))
            {
                command.Parameters.AddWithValue("@Id",villianId);

                return (int)command.ExecuteNonQuery();
            }
        }

        private static int GetVillianId(int villianIdInput, SqlConnection connection,SqlTransaction transaction)
        {
            string idQuery = "Select id from Villains where id = @Id";
            using (SqlCommand command = new SqlCommand(idQuery, connection,transaction))
            {
                command.Parameters.AddWithValue("@Id", villianIdInput);

                if (command.ExecuteScalar() == null)
                {
                    return 0;
                }
                return (int)command.ExecuteScalar();
            }
        }
    }
}
