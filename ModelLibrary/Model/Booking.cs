using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.Model
{
    public class Booking
    {

        private int _bookingID;
        private Room _room;
        private Guest _guest;
        private DateTime _dateFrom;
        private DateTime _dateTo;


        public Booking()
        {
            
        }

        public Booking(int bookingId, Room room, Guest guest, DateTime dateFrom, DateTime dateTo)
        {
            _bookingID = bookingId;
            _room = room;
            _guest = guest;
            _dateFrom = dateFrom;
            _dateTo = dateTo;
        }

        public int BookingId
        {
            get => _bookingID;
            set => _bookingID = value;
        }

        public Room Room
        {
            get => _room;
            set => _room = value;
        }

        public Guest Guest
        {
            get => _guest;
            set => _guest = value;
        }

        public DateTime DateFrom
        {
            get => _dateFrom;
            set => _dateFrom = value;
        }

        public DateTime DateTo
        {
            get => _dateTo;
            set => _dateTo = value;
        }

        public override string ToString()
        {
            return $"{nameof(BookingId)}: {BookingId}, {nameof(Room)}: {Room}, {nameof(Guest)}: {Guest}, {nameof(DateFrom)}: {DateFrom}, {nameof(DateTo)}: {DateTo}";
        }
    }
}
