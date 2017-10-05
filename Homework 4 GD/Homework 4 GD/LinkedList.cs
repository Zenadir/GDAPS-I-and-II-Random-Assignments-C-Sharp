using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_4_GD
{
    class LinkedList : IList
    {
        #region Attributes

        public string UserInput { get; set; }

        //The node at the beginning of the list
        public Node Head = null;

        //The node at the end of the list.
        public Node Tail = null;
       
        //The number of nodes currently in the list
        int count;

        //A property for count
        public int Count
        {
            get
            {
                return count;
            }
        }

        //A random object for the scramble function
        public Random r = new Random();

        #endregion Attributes

        public void Add(string data)
        {
            //Create a new placeholder node.
            Node newNode = new Node(data);

            //If there are no nodes in the list:
           
            if(count == 0)
            {
                //Set the node as the front and back of the list.
                Head = newNode;
                Tail = newNode;

                //Increment the count and exit
                ++count;
                return;
            }

            //If there are entries on the list:
            else
            {
                //Set the preivous of newnode to be the previous tail
                newNode.Previous = Tail;

                //Set the tail's next to be the newnode
                Tail.Next = newNode;
            
                
                //Set the node as the tail of the list.
                Tail = newNode;


                //Increment the count
                ++count;

                return;
            }

          

        }

        //Clear out the entire list.
        //set the count to 0.
        public void Clear()
        {
            Head = null;
            Tail = null;
            count = 0;
        }

        public string GetElement(int index)
        {
            //If an invalid index is given, return null
            if(index < 0 || index > count-1)
            {
                return null;
            }

            //Otherwise, cycle through the list until the index has been found.
            //Then return the data of that index/
            else
            {
                Node placeholderNode = Head;

                for (int i = 0; i < index; i++)
                {
                    placeholderNode = placeholderNode.Next;
                }

                return placeholderNode.Data;
            }
        }

        //Insert a Node object (with the specified data) at the specified index
        //in the list. The index is zero based, of course.
        public void Insert(string data, int index)
        {
            //Create a new placeholder node at the begining of the list.         
            Node newNode = new Node(data);

            //If the list is empty:
            //Set the node as the new head and tail.
            //Increment the count and exit the function
            if ( count == 0)
            {
                Head = newNode;
                Tail = newNode;
                ++count;
                return;
            }

            //If the index given is negative or equal to 0:
            if( index <= 0)
            { 
                //Set the head's previous as newnode
                Head.Previous = newNode;
                
                //Set newnode's head as the next
                newNode.Next = Head;

                //Make newnode the new head
                Head = newNode;

                //Increment the count
                ++count;
                return;
            }

            //If the index is greater than the number of elements in the list:
            //Put the newnode at the end of the list and increment the count
            if(index >= count)
            {
                Add(data);
                return;
            }
                

            //Create a node to cycle through the list
            Node cycleNode = Head;

            //Cycle through the list
            for (int i = 0; i < index; i++)
            {
                //The node becomes its next node
                cycleNode = cycleNode.Next;
            }

            //If there is a node after cyclenode

            newNode.Next = cycleNode;
            newNode.Previous = cycleNode.Previous;
            newNode.Previous.Next = newNode;
            cycleNode.Previous = newNode;

            //if(cycleNode.Next!= null)
            //{
            //    newNode.Next = cycleNode.Next;
            //    cycleNode.Next.Previous = newNode;
            //}

            //if(cycleNode.Previous!= null)
            //{
            //    cycleNode.Next = newNode;
            //    newNode.Previous = cycleNode;
            //}
 
           
            //Increment the count
            ++count;
        }

        public string Remove(int index)
        {
            //create a temporary string to store
            //the data of the removed node.
            string tempstring = null;

            //If an invalid index is given or the list is empty:
            //just exit and return null.
            if (index < 0 || index >= count || count == 0)
            {
                return tempstring;
            }

            //If the index is equal to the count-1 (i.e. its looking at
            //the last entry of the list).
            if(index == count-1)
            {
                //Set the tempstring = to the tail data
                tempstring = Tail.Data;

                //Set the tail to be the data before the tail.
                Tail = Tail.Previous;

                //Set the new tail's next reference to null.
                Tail.Next = null;

                //Subtract one from the count.
                --count;

                return tempstring;
            }

            //If there is one element of the list
            if(count == 1 && index == 0)
            {
                //Store the head's data in tempstring
                tempstring = Head.Data;

                //Set the head and the tail to null.
                Head = null;
                Tail = null;

                //subtract one from the count
                --count;

                return tempstring;
            }

            //WORKING
            //If the index is 0 and there is more than one
            //entry in the list:
            if(index == 0)
            {
                //store the data of the head in tempstring
                tempstring = Head.Data;

                //set the head to the next entry of the list
                Head = Head.Next;

                //Set the previous reference of the new head to 
                //null, deleting the old head.
                Head.Previous = null;

                //Subtract one from the count
                --count;

                return tempstring;
            }

           //Create a node to cycle through the list of nodes
           Node holderNode = Head;

            //cycle through the list of node 
            for (int i = 0; i < index; i++)
            {
                holderNode = holderNode.Next;
            }

            //Store holdernode's data in tempstring
            tempstring = holderNode.Data;           
            

            //Make it so that the nodes before and after 
            //holdernode refrence eachother instead of holdernode

            if(holderNode.Next != null)
            holderNode.Next.Previous = holderNode.Previous;
       

            if(holderNode.Previous!= null)
            holderNode.Previous.Next = holderNode.Next;

            //Subtract one from the count
            --count;

            return tempstring;

        }

        public void Scramble()
        {
            //Using the random object:
            //remove a string from a random position and insert it in a random position

            //Remove a node from the list at random and store its data.
            string tempRemove = Remove(r.Next(0, count));

            //If the removed data isnt null (which it could be by 
            //the user just pressing enter or something)
            //Put it back into the list
            if (tempRemove != null)
            {
                int random = r.Next(0, count + 1);
                Insert(tempRemove, random);
            }
            

            Print();                    
           
        }

        //Display every element of the list 
        public void Print()
        {
            if(count == 0)
            {
                Console.WriteLine("The list is empty");
            }
           else
            {
                Node placeholderNode = Head;
                Console.WriteLine(placeholderNode.Data + " [0]");
                for (int i = 0; i < count; i++)
                {                    
                    if(placeholderNode.Next!= null)
                    {
                        placeholderNode = placeholderNode.Next;
                        Console.WriteLine(placeholderNode.Data +" ["+ (i+1) +"]");
                    }
                    else
                    {
                        break;
                    }
                    
                }
            }
        }

        //Its just the print method but starting with the tail 
        //and traversing backwards
        public void PrintBackwards()
        {
            if (count == 0)
            {
                Console.WriteLine("The list is empty");
            }
            else
            {
                Node placeholderNode = Tail;
                Console.WriteLine(placeholderNode.Data + "["+ (count-1) +"]");
                for (int i = 0; i < count; i++)
                {
                    if (placeholderNode.Previous != null)
                    {
                        placeholderNode = placeholderNode.Previous;
                        Console.WriteLine(placeholderNode.Data + "[" + (count - i - 2) + "]");
                    }
                    else
                    {
                        break;
                    }

                }
            }
        }



    }
}
