using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Web.Script.Serialization;

namespace JsonExercise2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Reading exerp.json");
            JavaScriptSerializer ser = new JavaScriptSerializer();
            string jsonSTRING = File.ReadAllText("exerp.json");
            List<Item> mylist = JsonConvert.DeserializeObject<List<Item>>(jsonSTRING);

            if (mylist == null)
                mylist = new List<Item>();

            string input = "";
            int inputInt = 0;
            string inputString = "";

            while (input != "q")
            {
                Console.WriteLine("Press 'a' to Add new Item");
                Console.WriteLine("Press 'd' to Delete Item");
                Console.WriteLine("Press 's' to Show Content");
                Console.WriteLine("Press 'q' to Quit Program");
                Console.WriteLine("Press Command");
                input = Console.ReadLine();
                switch (input) //Switch on input string
                {
                    case "a":
                        Console.WriteLine("Adding a new item");
                        Console.WriteLine("Enter item name");
                        inputString = Console.ReadLine();
                        Console.WriteLine("Enter item price(Numeric Values Only)");
                        inputInt = Convert.ToInt32(Console.ReadLine());
                        mylist.Add(new Item(inputString, inputInt));
                        Console.WriteLine("Added Item " + inputString + " with price");
                        break;
                    case "d":
                        Console.WriteLine("Deleting item");
                        Console.WriteLine("Enter item name to delete");
                        inputString = Console.ReadLine();
                        mylist.Remove(new Item(inputString));
                        Console.WriteLine("Deleted item with name" + inputString);
                        break;
                    case "q":
                        Console.WriteLine("Quit Program");
                        break;
                    case "s":
                        Console.WriteLine("\nShowing Contents");
                        foreach (Item item in mylist)
                        {
                            Console.WriteLine("Item " + item.name + " | $" + item.price);
                        }
                        Console.WriteLine("\n");
                        break;
                    default:
                        Console.WriteLine("Incorrect command try again");
                        break;
                }
            }
            Console.WriteLine("Rewriting to exerp.json");
            string data = JsonConvert.SerializeObject(mylist);
            File.WriteAllText("exerp.json", data);
            Console.ReadLine();
        }
    }
}
