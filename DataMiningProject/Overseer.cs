/*OVERSEER.CS
 * MAINTAINS COMMUNICATIONS WITH PYTHON OVERSEER
 */

using DataMining_Project1;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;


namespace DataMiningProject
{
    
    class Overseer
    {
     

        static void Main(string[] args)
        {
            Console.WriteLine("Overseer active");

            //strip files of HTML tags
            HTMLStripper h = new HTMLStripper();
            h.RemoveHTML();
            
            //communicate with python program
            Communicator c = new Communicator();
            c.communicate();

            
            Console.ReadLine();

        }

   
    }
   
}
