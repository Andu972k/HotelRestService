using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ModelLibrary.Model;

namespace HotelRestService.DBUtil
{
    public class ManageRoom
    {

        private const string connectionString = @"";

        private const string Get_All = "Select * from DemoRoom";
        private const string Get_One = "Select * from DemoRoom Where Room_No =@Room_ID and Hotel_No = @Hotel_ID";
        private const string Insert = "Insert into DemoRoom values(@Room_ID, @Hotel_ID, @Type, @Price)";
        private const string Update = "Update DemoRoom \n Set Room_No = @Room_ID, Hotel_No = @Hotel_ID, Types = @Type, Price = @Pri Where Hotel_No = @HID and Room_No = @RID";
        private const string DELETE = "Delete from DemoRoom Where Hotel_No = @Hotel_ID and Room_No = @Room_ID";

        public IEnumerable<Room> Get()
        {
            List<Room> rooms = new List<Room>();

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command = new SqlCommand(Get_All, connection);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Room room = ReadRoom(reader);
                rooms.Add(room);
            }

            connection.Close();

            return rooms;

        }

        private Room ReadRoom(SqlDataReader reader)
        {
            Room room = new Room();
            room.RoomNumber = reader.GetInt32(0);
            room.HotelNumber = reader.GetInt32(1);
            room.RoomType = reader.GetString(2);
            room.Price = reader.GetDouble(3);

            return room;

        }

        public Room Get(int hotel_ID, int room_ID)
        {
            Room room = new Room();

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command = new SqlCommand(Get_One, connection);
            command.Parameters.AddWithValue("@Hotel_ID", hotel_ID);
            command.Parameters.AddWithValue("@Room_ID", room_ID);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                room = ReadRoom(reader);
            }

            connection.Close();

            return room;

        }

        public bool Post(Room room)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command = new SqlCommand(Insert, connection);
            command.Parameters.AddWithValue("@Room_ID", room.RoomNumber);
            command.Parameters.AddWithValue("@Hotel_ID", room.HotelNumber);
            command.Parameters.AddWithValue("@Type", room.RoomType);
            command.Parameters.AddWithValue("@Price", room.Price);

            int rowsAffected = command.ExecuteNonQuery();

            connection.Close();

            return rowsAffected == 1;

        }

        public bool Put(int hotel_id, int room_id, Room room)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command = new SqlCommand(Update, connection);
            command.Parameters.AddWithValue("@Room_ID", room.RoomNumber);
            command.Parameters.AddWithValue("@Hotel_ID", room.HotelNumber);
            command.Parameters.AddWithValue("@Type", room.RoomType);
            command.Parameters.AddWithValue("@Pri", room.Price);
            command.Parameters.AddWithValue("@HID", hotel_id);
            command.Parameters.AddWithValue("@RID", room_id);

            int rowsAffected = command.ExecuteNonQuery();

            connection.Close();

            return rowsAffected == 1;
        }

        public bool Delete(int hotel_id, int room_id)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command = new SqlCommand(DELETE, connection);
            command.Parameters.AddWithValue("@Hotel_ID", hotel_id);
            command.Parameters.AddWithValue("@Room_ID", room_id);

            int rowsAffected = command.ExecuteNonQuery();

            connection.Close();

            return rowsAffected == 1;

        }
    }
}