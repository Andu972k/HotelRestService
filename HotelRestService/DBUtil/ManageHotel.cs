using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;
using ModelLibrary.Model;

namespace HotelRestService.DBUtil
{
    public class ManageHotel : IManage<Hotel>
    {
        private const string connectionString = @"";

        private const string Get_All = "Select * from DemoHotel";
        private const string Get_one = "Select * from DemoHotel Where Hotel_No = @ID";
        private const string Insert = "Insert into DemoHotel values(@ID, @Name, @Address)";
        private const string DELETE = "delete from DemoHotel Where Hotel_No = @ID";
        //private const string Update = "Update DemoHotel" + 
        //                              "SET Hotel_No = @HotelID, Name = @Name, Address = @Address" + 
        //                              "Where Hotel_No = @ID";
        private const string Update =
            "Update DemoHotel \n SET Hotel_No = @HotelID, Name = @Name, Address = @Address \n Where Hotel_No = @ID";


        // GET: api/Hotels
        public IEnumerable<Hotel> Get()
        {
            List<Hotel> liste = new List<Hotel>();

            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            SqlCommand command = new SqlCommand(Get_All, connection);
            
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Hotel hotel = ReadHotel(reader);
                liste.Add(hotel);
            }

            connection.Close();

            return liste;
        }

        private Hotel ReadHotel(SqlDataReader reader)
        {
            Hotel hotel = new Hotel();

            hotel.Id = reader.GetInt32(0);
            hotel.Name = reader.GetString(1);
            hotel.Address = reader.GetString(2);

            return hotel;
        }

        // GET: api/Hotels/5
        public Hotel Get(int id)
        {
            Hotel hotel = null;

            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            SqlCommand command = new SqlCommand(Get_one, connection);

            command.Parameters.AddWithValue("@ID", id);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                hotel = ReadHotel(reader);
                
            }

            connection.Close();

            return hotel;
        }

        // POST: api/Hotels
        public bool Post(Hotel value)
        {
            bool retValue = false;

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command = new SqlCommand(Insert, connection);
            command.Parameters.AddWithValue("@ID", value.Id);
            command.Parameters.AddWithValue("@Name", value.Name);
            command.Parameters.AddWithValue("@Address", value.Address);

            int rowsAffected = command.ExecuteNonQuery();

            if (rowsAffected == 1)
            {
                retValue = true;
            }

            connection.Close();

            return retValue;
        }

        // PUT: api/Hotels/5
        public bool Put(int id, Hotel hotel)
        {
            bool retValue;

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command = new SqlCommand(Update, connection);

            command.Parameters.AddWithValue("@ID", id);
            command.Parameters.AddWithValue("@HotelID", hotel.Id);
            command.Parameters.AddWithValue("@Name", hotel.Name);
            command.Parameters.AddWithValue("@Address", hotel.Address);

            int rowsAffected = command.ExecuteNonQuery();


            retValue = rowsAffected == 1 ? true : false;

            connection.Close();

            return retValue;
        }

        // DELETE: api/Hotels/5
        public bool Delete(int id)
        {
            bool retValue;

            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            SqlCommand command = new SqlCommand(DELETE, connection);
            command.Parameters.AddWithValue("@ID", id);
            

            int rowsAffected = command.ExecuteNonQuery();

            retValue = rowsAffected == 1 /*? true : false*/;

            connection.Close();

            return retValue;

        }

    }
}