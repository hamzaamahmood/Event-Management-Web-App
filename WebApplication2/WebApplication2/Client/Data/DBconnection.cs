using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Client.Data
{
    public class DBconnection
    {
        string connectionString = @"Host=localhost;Port=5432;Username=postgres;Password=pa25444;Database=EventManagementDB";

        public string Register(RegisterModel registerModel)
        {
            try
            {
                var connection = new NpgsqlConnection(connectionString);
                connection.Open();
                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "INSERT INTO public.\"Users\"( \"UserName\", \"UserEmail\", \"UserPassword\") VALUES(@UserName,@Email,@Password); ";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new NpgsqlParameter("@UserName", registerModel.fullName));
                cmd.Parameters.Add(new NpgsqlParameter("@Email",registerModel.email));
                cmd.Parameters.Add(new NpgsqlParameter("@Password", registerModel.password));
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                return "User Added";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
           
        }
    }
}
