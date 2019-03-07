using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.Model
{
    public class Facilitet
    {

        private int _id;
        private string _name;
        private int _price;

        public Facilitet()
        {
            
        }

        public Facilitet(string name, int price)
        {
            
            _name = name;
            _price = price;
        }

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

        public int Price
        {
            get => _price;
            set => _price = value;
        }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Name)}: {Name}, {nameof(Price)}: {Price}";
        }
    }
}
