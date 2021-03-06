﻿/*
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
        
        public int processFiles(ref Dictionary<string, double>[] terms, ref Dictionary<string, int> w, ref Dictionary<string, int> a) {

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
                        
                        //ceate new element for each new class
                        terms[num] = new Dictionary<string, double>();

                        //remove html
                        string fileName = h.RemoveHTML(f, num, ref terms, ref w, ref a);
                       
                        num++;
                        
                    }


                }
               
                
            }

            Console.WriteLine(num + " files processed");
            return num;

        }
    }
}
