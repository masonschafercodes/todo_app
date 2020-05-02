using System;
using System.Collections.Generic;
namespace todo_list_app
{
    public class Todo //Class for creating a new list with specefic methods for adding and deleting items from that list
    {
        public string title;
        public int numberOfItemsOnList;
        public List<string> items = new List<string>();

        public Todo(string aTitle)
        {
            title = aTitle;
        }

        public List<string> Todo_Items()
        {
            Console.Write("Add an item to the list: ");
            string new_item = Console.ReadLine();
            if (new_item != "")
            {
                items.Add(new_item);
            } else
            {
                Console.WriteLine("Please enter an item to add to the list");
                Console.ReadLine();
            }

            return items;
        }

        public List<string> DeleteItems()
        {
            Console.Write("Which Item to Delete: ");
            try
            {
                int item_to_delete = Convert.ToInt32(Console.ReadLine());
                items.Remove(items[item_to_delete - 1]);
            }
            catch
            {
                Console.WriteLine("Unable to Parse that Number");
            }
            return items;
        }
    }
}
