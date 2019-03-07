using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.Model
{
    public class Guest
    {

        private int _guestNumber;
        private string _name;
        private string _address;

        public Guest()
        {
            
        }

        public Guest(int guestNumber, string name, string address)
        {
            _guestNumber = guestNumber;
            _name = name;
            _address = address;
        }

        public int GuestNumber
        {
            get => _guestNumber;
            set => _guestNumber = value;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public string Address
        {
            get => _address;
            set => _address = value;
        }

        public override string ToString()
        {
            return $"{nameof(GuestNumber)}: {GuestNumber}, {nameof(Name)}: {Name}, {nameof(Address)}: {Address}";
        }
    }
}
