using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.Model
{
    public class Room
    {

        private int _roomNumber;
        private int _hotelNumber;
        private string _roomType;
        private double _price;

        public Room()
        {
            
        }

        public Room(int roomNumber, int hotelNumber, string roomType, double price)
        {
            _roomNumber = roomNumber;
        
            _roomType = roomType;
            _price = price;
        }


        public int RoomNumber
        {
            get => _roomNumber;
            set => _roomNumber = value;
        }

        public int HotelNumber
        {
            get => _hotelNumber;
            set => _hotelNumber = value;
        }

        public string RoomType
        {
            get => _roomType;
            set => _roomType = value;
        }

        public double Price
        {
            get => _price;
            set => _price = value;
        }

        public override string ToString()
        {
            return $"{nameof(RoomNumber)}: {RoomNumber}, {nameof(HotelNumber)}: {HotelNumber}, {nameof(RoomType)}: {RoomType}, {nameof(Price)}: {Price}";
        }
    }
}
