using System;
using System.Linq;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Globalization;

namespace _08.IncreaseMinionAge
{
    class StartUp
    {
        public static List<int> currentId = new List<int>();
        static void Main(string[] args)
        {
            var indexToUpdate = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var currentIdNames = new Dictionary<int,string>();

            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                ReadCurrentIDs(connection, currentIdNames);

                UpdateMinions(connection, currentIdNames, indexToUpdate);

                PrintAllMinions(connection);
            }

        }

        private static void PrintAllMinions(SqlConnection connection)
        {
            var printQuery = "select Name,Age from Minions ";
            using (SqlCommand command = new SqlCommand(printQuery, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader[0]} {reader[1]}");
                    }
                }
            }

        }

        private static void UpdateMinions(SqlConnection connection, Dictionary<int, string> currentIdNames, int[] indexToUpdate)
        {
            for (int i = 0; i < indexToUpdate.Length; i++)
            {
                int Id = indexToUpdate[i];
                if (currentId.Contains(Id))
                {
                    var currentName = currentIdNames[Id];
                    var titleName = UpdateName(currentName);
                    UpdateDatabase(Id, titleName, connection);
                }
            }
        }

        private static void UpdateDatabase(int id, string titleName, SqlConnection connection)
        {
            string updateQuery = "update Minions set age+=1,Name = @Name WHERE Id = @Id";
            using (SqlCommand commmand = new SqlCommand(updateQuery,connection))
            {
                commmand.Parameters.AddWithValue("@Id", id);
                commmand.Parameters.AddWithValue("@Name", titleName);

                commmand.ExecuteNonQuery();
            }
        }

        private static string UpdateName(string currentName)
        {
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            var nameAsTittle = textInfo.ToTitleCase(currentName.ToLower());
            return nameAsTittle;
        }

        private static void ReadCurrentIDs(SqlConnection connection,  Dictionary<int, string> currentIDs)
        {
            var currentMinionsQuery = "select Id, Name from Minions";

            using (SqlCommand command = new SqlCommand(currentMinionsQuery, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        currentId.Add((int)reader[0]);
                        currentIDs.Add((int)reader[0],(string)reader[1]);
                    }
                }
            }
        }
    }
}
