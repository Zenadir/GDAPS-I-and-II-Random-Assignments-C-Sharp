using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Net;
using System.Net.Sockets;

namespace PEO_13_Networking
{
    class Program
    {
        static void Main(string[] args)
        {


            bool A = false;

            TcpClient TCP = new TcpClient("129.21.29.188", 14623);
            StreamWriter writer = new StreamWriter(TCP.GetStream());

            while(A == false)
            {
               
                writer.WriteLine("Color");
                writer.Flush();
            }
                
          
        }
    }
}
