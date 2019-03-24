/*
 * FILEPROCESSOR.CS
 * GOES THROUGH EACH FILE IN THE DIRECTORY, AND CALLS HTMLSTRIPPER TO REMOVE HTML TAGS
 * 
 * Authors: Christina Hinton & Brayden Faulkner
 */


using System;
using System.Collections.Generic;
using System.IO;
using DataMining_Project1;


namespace DataMiningProject
{
    class FileProcessor
    {
        string[] files = new string[9000];
        
        public void processFiles(ref Dictionary<string, double>[] terms, ref Dictionary<string, int> w) {

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
            

            //total number of files
            int num = 0;

            //total number of classes (should be 7)
            int classNum = 0;

            //get each directory in the file webkb
            string[] directoryNames = Directory.GetDirectories(@"webkb");

            //find each directory in the current directory
            foreach (string i in directoryNames){
                
                //ceate new element for each new class
                terms[classNum] = new Dictionary<string, double>();

                //number of files in each class
                int n = 0;
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
                        string fileName = h.RemoveHTML(f, classNum, n, ref terms, ref w);
                        n++;

                        num++;
                        
                    }


                }
                classNum++;
                
            }

            Console.WriteLine(num + " files processed");
           

        }
    }
}
