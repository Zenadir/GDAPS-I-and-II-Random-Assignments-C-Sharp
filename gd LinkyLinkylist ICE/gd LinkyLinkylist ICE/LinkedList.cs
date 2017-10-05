using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gd_LinkyLinkylist_ICE
{
    class LinkedList
    {
        /// <summary>
        /// Variable for saving the first node in the linked list
        /// </summary>
        public Node Head { get; set; } = null;

        //The current number of items in the chain of nodes
        public int Count { get; set; } = 0;

        /// <summary>
        /// Add a new node to the linked list
        /// </summary>
        /// <param name="data"> data to save in th neew node</param>
        public void Add(string data)
        {

            //Create a new node with the data passed in
            Node newNode = new Node(data);
            //Check if list is empty
            if(Count == 0)
            {
                Head = newNode;
                Count++;
                return;
            }

            //Find the end of the list
            Node current = Head;

            //While we have something afterwords, were going to keep going until current.Link = null
            while (current.Link != null)
            {
                current = current.Link;
            }
            current.Link = newNode;
            Count++;
        }

        /// <summary>
        /// Prints out the list
        /// </summary>
        public void Traverse()
        {
            //Find the end of the list
            Node current = Head;

            //While we have something afterwords, were going to keep going until current.Link = null
            while (current != null)
            {
                Console.WriteLine(current);
                current = current.Link;
            }
           
        }

        public string GetData(int index)
        {
            if(index< 0 || index > Count)
            {
                return null;
            }
            else
            {
                Node cNode = Head;
                for (int i = 0; i < index; i++)
                {
                    cNode = cNode.Link;
                }
                return cNode.Data;
            }
        }

        public void Clear()
        {
            Head = null;
            Count = 0;           
        }

        public void Insert(int index, string data)
        {

            Node NewNode = new Node(data);
            Node cNode = Head;
            Node prevNode = null;

            if(index == 0)
            {
                NewNode.Link = Head;
                Head = NewNode;
                Count++;
                return;
            }

            if (index < 0)
            {
                NewNode.Link = Head;
                cNode = Head;
                Count++;
                return;
            }

            if(index > Count)
            {
                while (cNode.Link != null)
                {
                    prevNode = cNode;
                    cNode = cNode.Link;
                }
                cNode.Link = NewNode;
                Count++;
                return;
            }
            else
            {              
                for (int i = 0; i < index; i++)
                {
                    prevNode = cNode;
                    cNode = cNode.Link;
                }
                NewNode.Link = cNode;

                if(prevNode != null)
                {
                    prevNode.Link = NewNode;
                }
                
                Count++;
            }
        }

        public void InsertSorted(string addValue)
        {
            Node newValueNode = new Node(addValue);
            if(Count == 0)
            {
                
                Head = newValueNode;
                Count++;
            }

            else
            {
                Node cNode = Head;
                Node prevNode = null;

                for (int i = 0; i < Count; i++)
                {
                   
                   if(addValue.ToUpper().CompareTo(cNode.Data) == -1)
                    {
                            newValueNode.Link = cNode;

                            if(prevNode != null)
                            {
                                prevNode.Link = newValueNode;
                            }
                            else
                            {
                            Head = newValueNode;
                            
                            }



                        return;
                    }

                    prevNode = cNode;
                    cNode = cNode.Link;

                    if(cNode == null)
                    {
                        Add(addValue);
                        return;
                    }
                }

            }
           

        }

    }
}
