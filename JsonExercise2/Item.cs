using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonExercise2
{
    class Item : IEquatable<Item>
    {
        public string name;
        public int price;

        public Item(string name, int price = 0)
        {
            this.name = name;
            this.price = price;
        }
        public bool Equals(Item other)
        {
            if (other == null) return false;
            return (this.name.Equals(other.name));
        }
    }
}
