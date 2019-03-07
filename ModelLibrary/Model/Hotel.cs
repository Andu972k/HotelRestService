using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.Model
{
    public class Hotel
    {

        private int _id;
        private string _name;
        private string _address;

        public int Id
        {
            get => _id;
            set => _id = value;
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

        //Husk Altid Default konstruktør for json

        public Hotel()
        {
            
        }

        public Hotel(int id, string name, string address)
        {
            _id = id;
            _name = name;
            _address = address;
        }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Name)}: {Name}, {nameof(Address)}: {Address}";
        }
    }
}
