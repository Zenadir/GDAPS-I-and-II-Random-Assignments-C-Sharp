using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gd_LinkyLinkylist_ICE
{
    class Node
    {
        public string Data { get; set; }

        //Data for linked list

        public Node Link { get; set; }
        //Pointer to the next node in the linked list.

            /// <summary>
            /// constructor for the ndoe class that takes the data to save
            /// </summary>
            /// <param name="data"> the data that needs to be saved</param>
            /// <param name="nD"></param>
        public Node(string data)
        {
            Data = data;
            Link = null;

            int? count = null;
            //count.HasValue
            
        }

        /// <summary>
        /// Custom output for the node class
        /// </summary>
        /// <returns>the data that is saved</returns>
        public override string ToString()
        {
            return Data;
        }

        //if true ? 0 ; 0 
        //count ?? 5;
    }
}
