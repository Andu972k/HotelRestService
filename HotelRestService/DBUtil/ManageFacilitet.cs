using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ModelLibrary.Model;

namespace HotelRestService.DBUtil
{
    public class ManageFacilitet : IManage<Facilitet>
    {

        private const string connectionString = @"";

        private const string Get_All = "Select * from DemoFacilitet";
        private const string Get_One = "Select * from DemoFacilitet Where Facilitet_ID = @ID";
        private const string Insert = "Insert into DemoFacilitet values(@Name, @Price)";
        private const string Update = "Update DemoFacilitet \n SET Name = @Name, Price = @Price \n Where Facilitet_ID = @ID";
        private const string DELETE = "Delete from DemoFacilitet Where Facilitet_ID = @ID";

        public IEnumerable<Facilitet> Get()
        {
            List<Facilitet> listFacilitets = new List<Facilitet>();

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command = new SqlCommand(Get_All, connection);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Facilitet facilitet = ReadFacilitet(reader);
                listFacilitets.Add(facilitet);
            }

            connection.Close();

            return listFacilitets;

        }

        private Facilitet ReadFacilitet(SqlDataReader reader)
        {
            Facilitet facilitet = new Facilitet();
            facilitet.Id = reader.GetInt32(0);
            facilitet.Name = reader.GetString(1);
            facilitet.Price = reader.GetInt32(2);

            return facilitet;

        }

        public Facilitet Get(int id)
        {
            Facilitet facilitet = new Facilitet();

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command = new SqlCommand(Get_One, connection);
            command.Parameters.AddWithValue("@ID", id);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                facilitet = ReadFacilitet(reader);
                
            }

            connection.Close();

            return facilitet;

        }

        public bool Post(Facilitet facilitet)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command = new SqlCommand(Insert, connection);
            command.Parameters.AddWithValue("@Name", facilitet.Name);
            command.Parameters.AddWithValue("@Price", facilitet.Price);

            int rowsAffected = command.ExecuteNonQuery();

            connection.Close();

            return rowsAffected == 1;

        }

        public bool Put(int id, Facilitet facilitet)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command = new SqlCommand(Update, connection);
            command.Parameters.AddWithValue("@Name", facilitet.Name);
            command.Parameters.AddWithValue("@Price", facilitet.Price);
            command.Parameters.AddWithValue("@ID", id);

            int rowsAffected = command.ExecuteNonQuery();

            connection.Close();

            return rowsAffected == 1;

        }

        public bool Delete(int id)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command = new SqlCommand(DELETE, connection);
            command.Parameters.AddWithValue("@ID", id);

            int rowsAffected = command.ExecuteNonQuery();

            connection.Close();

            return rowsAffected == 1;
        }
    }
}