using System;
using System.Collections.Generic;
using System.IO;
//Create a way to store items
//Features:
//1. Adding Items
//2. Completing Items
//3. Remove Items
//------------------
//How to solve:
//1. Create a list and append each Item to that list
//2&3. Remove item from list

namespace todo_list_app
{
    class Program
    {
        static void Main(string[] args)
        {
            Todo new_list = (Todo)CreateNewTodo(); //Creating a new Todo object
            string date = DateTime.Now.ToShortDateString(); //Setting up date string so I can display date on main menu
            string time = DateTime.Now.ToString("hh:mm:ss tt"); //Setting up time string so I can display time on main menu
            bool keep_running = true;
            while (keep_running) //Main loop for main menu
            {
                Console.WriteLine("##########################");
                Console.WriteLine("#    Date: " +  date + "      #");
                Console.WriteLine("# Created At: " +  time + "#");
                Console.WriteLine("##########################");
                Console.WriteLine("#        Todo List       #");
                Console.WriteLine("##########################");
                Console.WriteLine("#    1: Add Item         #");         //MAIN MENU
                Console.WriteLine("#    2: Remove Item      #");
                Console.WriteLine("#    3: Export List      #");
                Console.WriteLine("#    4: Display Items    #");
                Console.WriteLine("#    5: Exit             #");
                Console.WriteLine("##########################");
                Console.Write("> ");
                string user_option = Console.ReadLine();  //Capturing User Input

                if (user_option == "1")
                {
                    new_list.Todo_Items(); //Running class method to add items to a list
                    Console.Clear();
                } else if (user_option == "2")
                {
                    for (int i = 1; i <= new_list.items.Count; i++) //Looping through list items so user knows what they are deleting 
                    {
                        Console.WriteLine("(" + i + ")" + "- " + new_list.items[i - 1]);
                    }
                    new_list.DeleteItems(); //Running class method to delete items to a list
                    Console.Clear();
                } else if (user_option == "3")
                {
                    try
                    {
                        if (new_list.items.Count != 0)
                        {
                            StreamWriter sw = new StreamWriter("ENTER PATH TO FOLDER TO EXPORT" + new_list.title + ".txt");
                            sw.WriteLine("List Name: " + new_list.title);
                            for (int i = 1; i <= new_list.items.Count; i++)
                            {
                                sw.WriteLine("- " + new_list.items[i - 1]);

                            }
                            sw.Close();
                            Console.WriteLine("Successfully saved document."); //This block of code is for exporting current list to a folder for later user
                            Console.ReadLine();
                            Console.Clear();
                        } else
                        {
                            Console.WriteLine("Please Add an Item to the List");
                            Console.ReadLine();
                            Console.Clear(); 
                        }

                    } catch
                    {
                        Console.WriteLine("Unable to Write to file.");
                        Console.ReadLine();
                    }
                }
                else if (user_option == "4")
                {
                    Console.Clear();
                    for (int i = 1; i <= new_list.items.Count; i++)
                    {
                        Console.WriteLine("(" + i + ")" + "- " + new_list.items[i - 1]);   //Looping through list items to display to the user
                    }
                    Console.Write("Press Enter to Return to Main Menu...");
                    Console.ReadLine();
                    Console.Clear();
                }
                else if (user_option == "5")
                {
                    Environment.Exit(0); //Exiting the  application when user picks "Exit"
                }
                else
                {
                    Console.WriteLine("Unknown Input Please Try Again."); //Catching error on input
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }

        public static Object CreateNewTodo() //Method to create initial object and run constructor
        {
            Console.Write("Title for your todo list: ");
            string titleForTodo = Console.ReadLine();

            return new Todo(titleForTodo);

        }
        
    }
}
