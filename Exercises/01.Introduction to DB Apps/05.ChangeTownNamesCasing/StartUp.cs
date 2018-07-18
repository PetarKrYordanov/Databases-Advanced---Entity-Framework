using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace _05.ChangeTownNamesCasing
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string countryName = Console.ReadLine();

            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(countryName, connection))
                {
                    int CountryCode = GetCountryCode(connection, countryName);

                    if (CountryCode == 0)
                    {
                        Console.WriteLine($"No town names were affected.");
                    }

                    int rowsAffected = GetCountAndUpdate(CountryCode, connection);
                    var townList = GetTownList(CountryCode, connection);

                    Console.WriteLine($"{rowsAffected} town names were affected.");
                    Console.WriteLine($"[{string.Join(", ", townList)}]");
                }
            }
        }

        private static List<String> GetTownList(int countryCode, SqlConnection connection)
        {
            List<string> towns = new List<string>();
            string townNames = "Select Name from Towns where CountryCode = @CountryCode";
            using (SqlCommand command = new SqlCommand(townNames, connection))
            {
                command.Parameters.AddWithValue("@CountryCode", countryCode);
                using (SqlDataReader reader = command.ExecuteReader())
                    while (reader.Read())
                    {
                        towns.Add((string)reader[0]);
                    }
                return towns;
            }
        }

        private static int GetCountAndUpdate(int countryCode, SqlConnection connection)
        {
            string updateQuery = "update Towns set Name = UPPER(name) where CountryCode = @Id";

            using (SqlCommand command = new SqlCommand(updateQuery, connection))
            {
                command.Parameters.AddWithValue("@Id", countryCode);
                return (int)command.ExecuteNonQuery();
            }
        }

        private static int GetCountryCode(SqlConnection connection, string countryName)
        {
            var countryInfo = "select top 1 * from Countries as c join Towns as t on t.CountryCode = c.Id where c.Name =@countryName";

            using (SqlCommand command = new SqlCommand(countryInfo, connection))
            {
                command.Parameters.AddWithValue("@countryName", countryName);

                if (command.ExecuteScalar() == null)
                {
                    return 0;
                }
                return (int)command.ExecuteScalar();
            }
        }
    }
}
