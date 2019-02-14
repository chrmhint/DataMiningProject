using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using DataMining_Project1;

namespace DataMiningProject
{
    class FileProcessor
    {

        public void processFiles() {

           /* wbkd
            * -> folders with different school roles
            * -> folders for each school, associated with its role
            */

            HTMLStripper h = new HTMLStripper();
            Communicator c = new Communicator();

            //get each directory in the file webkb
            string[] directoryNames = Directory.GetDirectories(@"webkb");

            //find each directory in the current directory
            foreach (string i in directoryNames){
                
                //folders in each class
                string[] schoolNames = Directory.GetDirectories(i);

                //for each school folder, remove html and send to communicator
                foreach (string s in schoolNames)
                {
                    //every file in the current directory
                    string[] fileNames = Directory.GetFiles(s);

                    foreach (string f in fileNames)
                    {
                        //remove html
                        h.RemoveHTML(f);

                        //c.communicate(proj1.py);
                    }
                    


                }
                
            }

        }
    }
}
