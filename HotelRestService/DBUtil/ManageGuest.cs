using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ModelLibrary.Model;

namespace HotelRestService.DBUtil
{
    public class ManageGuest : IManageGuest
    {

        private const string connectionString = @"";

        private const string Get_All = "Select * from DemoGuest";
        private const string Get_One = "select * from DemoGuest Where Guest_No = @ID";
        private const string Insert = "Insert into DemoGuest values(@ID, @Name, @Address)";
        private const string Update = "Update DemoGuest \n SET Guest_No = @GuestID, Name = @Name, Address = @Address \n Where Guest_No = @ID";
        private const string DELETE = "Delete from DemoGuest Where Guest_No = @ID";

        public List<Guest> GetAllGuest()
        {
            List<Guest> guestList = new List<Guest>();

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command = new SqlCommand(Get_All, connection);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Guest guest = ReadGuest(reader);
                guestList.Add(guest);
            }

            connection.Close();

            return guestList;

        }

        private Guest ReadGuest(SqlDataReader reader)
        {
            Guest guest = new Guest();
            guest.GuestNumber = reader.GetInt32(0);
            guest.Name = reader.GetString(1);
            guest.Address = reader.GetString(2);

            return guest;
        }

        public Guest GetGuestFromId(int guestNr)
        {
            Guest guest = null;

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command = new SqlCommand(Get_One, connection);
            command.Parameters.AddWithValue("@ID", guestNr);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                guest = ReadGuest(reader);
            }

            return guest;

        }

        public bool CreateGuest(Guest guest)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command = new SqlCommand(Insert, connection);
            command.Parameters.AddWithValue("@ID", guest.GuestNumber);
            command.Parameters.AddWithValue("@Name", guest.Name);
            command.Parameters.AddWithValue("@Address", guest.Address);

            int rowsAffected = command.ExecuteNonQuery();

            connection.Close();

            return rowsAffected == 1;


        }

        public bool UpdateGuest(Guest guest, int guestNr)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command = new SqlCommand(Update, connection);
            command.Parameters.AddWithValue("@GuestID", guest.GuestNumber);
            command.Parameters.AddWithValue("@Name", guest.Name);
            command.Parameters.AddWithValue("@Address", guest.Address);
            command.Parameters.AddWithValue("@ID", guestNr);

            int rowsAffected = command.ExecuteNonQuery();

            connection.Close();

            return rowsAffected == 1;
        }

        public bool DeleteGuest(int guestNr)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command = new SqlCommand(DELETE, connection);
            command.Parameters.AddWithValue("@ID", guestNr);

            int rowsAffected = command.ExecuteNonQuery();

            connection.Close();

            return rowsAffected == 1;


        }
    }
}