/*OVERSEER.CS
 * MAINTAINS COMMUNICATIONS WITH PYTHON OVERSEER
 */

using DataMining_Project1;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;



namespace DataMiningProject
{

    class Overseer
    {


        static void Main(string[] args)
        {
            Console.WriteLine("Overseer active");
            Console.WriteLine("Processing files...");

           // Dictionary<string, int> terms = new Dictionary<string, int>();


            //dictionary array
            //index holds file number
            //key is the word
            //value is number of times word appears
            Dictionary<string, int>[] terms = new Dictionary<string, int>[8500];
            
            //process files -> remove HTML tags, stop words, and stem words
            FileProcessor f = new FileProcessor();
            f.processFiles(ref terms);

            //output file for results
            StreamWriter results = new StreamWriter("results.txt");

            int fileNumber = 1;

            //write results to output file
            foreach(Dictionary<string, int> fileNum in terms)
            {
                results.WriteLine("Document " + fileNumber);
                results.Flush();
                fileNumber++;

                    foreach (KeyValuePair<string, int> kvp in terms[0].OrderByDescending(key => key.Value))
                     {
                        
                        results.WriteLine(kvp);
                        results.Flush();
                    }
            }
 
            results.Close();
            Console.WriteLine("Complete");

            Console.ReadLine();

        }



    }
}
