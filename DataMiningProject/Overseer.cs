using DataMining_Project1;
using System;
using System.Collections.Generic;
using System.Text;


namespace DataMiningProject
{
    class Overseer
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Overseer active");
            HTMLStripper h = new HTMLStripper();
            h.RemoveHTML();
        }

    }
}
