using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Homework_4_GD
{
    class Program
    {      
        //Gabe Dworman
        //Homework 4
        //Purpose: Utilize a double linked list in the organization of data.

        static void Main(string[] args)
        {
            //A bool to keep track of whether or not
            //the user is finished using the program.
            bool finished = false;

            //Stores user input.
            string userinput = null;

            LinkedList listyList= new LinkedList();

            while(finished == false)
            {
                Console.WriteLine("To add to the list, type anything that isnt a command");
                Console.WriteLine("For a list of commands, enter 'LC'");
                
                userinput = Console.ReadLine();

                Console.Clear();
                //Wait a moment to make sure that the user knows that their input was read.
                Thread.Sleep(30);

                //Changes depending on what the user entered.
                //Default just adds to the list.
                switch (userinput)
                {
                    //List commands
                    case "LC":
                        Console.Write("Commands: \n");
                        Console.WriteLine("q or quit: End the loop. \n print: Print everything on the list. \n count: print the number of items in the list. \n clear: Clear the entire list. \n printBackwards: self explanatory. \n remove: Randomly remove one element from the list. \n removeSpecific: remove data at a specific index in the list \n insert: insert data at a specific index in the list. \n scramble: Remove a random elemnt from the list and insert it \n back into the list at a random index. \n getElement: Get the data of a specific index of the list. \n scrambleAll: Scramble all emenents of the list.");
                        break;

                    //Exit the program
                    case "q":
                        finished = true;
                        break;
                    case "quit":
                        finished = true;
                        break;

                    //Print out the entire list
                    case "print":
                        listyList.Print();
                        break;
                    
                    //Print out the number of elements of the list.
                    case "count":
                        Console.WriteLine(listyList.Count);
                        break;

                    //Clear the list
                    case "clear":
                        listyList.Clear();
                        break;
                    //Remmove a random element from the list
                    case "remove":
                        listyList.Remove(listyList.r.Next(listyList.Count));
                        break;
                    
                    //Remove a specific element from the list
                    case "removeSpecific":

                        //The index that will be removed from.
                        int removeIndex = -1;

                        Console.WriteLine("At what index number would you like to remove? (Invalid entries become 0)");
                        int.TryParse(Console.ReadLine(), out removeIndex);

                        //Remove the user inputted element from the list.
                        string removed = listyList.Remove(removeIndex);

                        //Clear the screen
                        Console.Clear();
                        
                        //If something was removed, notify the user.
                        if(removed != null)
                        Console.WriteLine(removed + " was removed at index " + removeIndex);

                        //If nothing was removed, patronize the user. 
                        else
                        {
                            Console.WriteLine("There was nothing to remove. Congrats.");
                        }
                        break;
                    
                        //Move an element from the list from one index to another at random.
                    case "scramble":
                        listyList.Scramble();
                        break;

                        //Scramble all elements of the list.
                    case "scrambleAll":
                        for (int i = 0; i < listyList.Count; i++)
                        {
                            listyList.Scramble();
                        }
                        break;
                    
                        //Insert a piece of data at a specific index. 
                    case "insert":
                        string storeData = null;
                        int tempInt = -1;
                        Console.WriteLine("Please enter the data to insert.");
                            storeData = Console.ReadLine();

                        Console.WriteLine("At what index number would you like to insert? (Invalid entries will be inserted at 0)");
                        int.TryParse(Console.ReadLine(), out tempInt);

                        Console.Clear();

                            listyList.Insert(storeData, tempInt);
                        Console.WriteLine(storeData + " was inserted at index " +tempInt);


                        break;

                        //Get the data at a specific index in the list. 
                    case "getElement":
                        int tempElement = -1;

                        
                        Console.WriteLine("At what index number would you like to get data of? (invalid entries become 0)");
                        
                        int.TryParse(Console.ReadLine(), out tempElement);

                        if(tempElement >= 0)
                        {
                            string data = listyList.GetElement(tempElement);
                            
                            if(data!= null)
                            Console.WriteLine("The data at " + tempElement + " is " + listyList.GetElement(tempElement));

                            else
                            {
                                Console.WriteLine("There is no data there.");
                            }
                        }
                        

                        break;

                        //Print the list backwards.
                    case "printBackwards":
                        listyList.PrintBackwards();
                        break;

                    default:
                        if(userinput!= null)
                        {
                            listyList.Add(userinput);
                            Console.WriteLine("Added " + userinput + " to the list.");
                        }
                      
                        break;

                }
                
            }
            
        }
    }
}
