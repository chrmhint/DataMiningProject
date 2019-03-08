using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.IO;
using DataMining_Project1;
using System.Collections.Specialized;

namespace DataMiningProject
{
    class FileProcessor
    {
        string[] files = new string[9000];

        public void processFiles(ref Dictionary<string, int>[] terms) {

           /* wbkd
            * -> folders with different school roles
            * -> folders for each school, associated with its role
            */

            HTMLStripper h = new HTMLStripper();
            StopWordRemover t = new StopWordRemover();

            //dictionary array
            //each index corresponds to file number
            //<string> is the term itself
            //<int> is the frequency
            


            int num = 0;
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
                        terms[num] = new Dictionary<string, int>();
                        string fileName = h.RemoveHTML(f, num, ref terms);

                        num++;

                    }
                    


                }
                
            }


            Console.WriteLine("Files Processed");

        }
    }
}
