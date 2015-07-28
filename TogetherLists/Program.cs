using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TogetherLists
{

    class Item : IComparable<Item>, IEquatable<Item>
    {
        public Item(int _id, string _title) { id = _id; title = _title; }
        public int id { get; set; }
        public string title { get; set; }
        
        public int CompareTo(Item _item)
        {
            if (this.id < _item.id) return -1;
            else if (this.id > _item.id) return 1;
            else return 0;
        }



        public bool Equals(Item other)
        {

            //Check whether the compared object is null. 
            if (Object.ReferenceEquals(other, null)) return false;

            //Check whether the compared object references the same data. 
            if (Object.ReferenceEquals(this, other)) return true;

            //Check whether the products' properties are equal. 
            return id.Equals(other.id) && title.Equals(other.title);
        }

        public override int GetHashCode()
        {

            //Get hash code for the Name field if it is not null. 
            int hashClipTitle = title == null ? 0 : title.GetHashCode();

            //Get hash code for the Code field. 
            int hashClipId = id.GetHashCode();

            //Calculate the hash code for the product. 
            return hashClipTitle ^ hashClipId;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Item> items1 = new List<Item>
            {
                new Item(1,"saasdfdf"),
                new Item(2,"gfhdghfghfghfghf"),//change1
                new Item(3,"sdfg"),
                new Item(4,"erty")
            };
            List<Item> items2 = new List<Item>
            {
                new Item(5,"rtyuafsadfasfddfsd"),//change2
                new Item(6,"vbnm"),
                new Item(3,"sdfg"),
                new Item(4,"erty")
            };
            
            List<Item> itog = new List<Item>();
            
            //itog = items1.Concat(items2).Distinct().ToList(); //надо для уникальности добавить Distinct()
            itog = items1.Union(items2).ToList(); //уже уникальны

            int i = 0;
            foreach (var item in itog)
            {
                i++;
                Console.WriteLine(i.ToString()+ ": " + item.id.ToString() + " " + item.title +"\n");
            }
            /*
            int i = 0;
            itog = items2.OrderBy(item => item).Distinct().ToList();
            foreach (var item in itog)
            {
                i++;
                Console.WriteLine(i.ToString() + ": " + item.id.ToString() + " " + item.title + "\n");
            }*/

            Console.ReadLine();
        }
    }
}
