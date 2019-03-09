/*OVERSEER.CS
 * STARTS FILE PROCESSING
 * CALCULATES TF-IDF
 */


using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;



namespace DataMiningProject
{

    class Overseer
    {


        static void Main(string[] args)
        {
            Console.WriteLine("Overseer active");
            Console.WriteLine("Processing files...");

   
            //dictionary array
            //index holds file number
            //key is the word
            //value is number of times word appears
            Dictionary<string, double>[] terms = new Dictionary<string, double>[8282]; //TODO: dyanamic sizing

            //list of words and number of document appearances
            Dictionary<string, int> words = new Dictionary<string, int>();

            //process files -> remove HTML tags, stop words, and stem words
            FileProcessor f = new FileProcessor();
            f.processFiles(ref terms, ref words);

            //output file for results
            StreamWriter results = new StreamWriter("results.txt");

            //file to be be examined
            int fileNumber = 0;
            Console.WriteLine("Calculating Results");

            //write results to output file
            foreach(Dictionary<string, double> fileNum in terms)
            {
                //write heading for each file, for readability
                results.WriteLine();
                results.WriteLine("Document " + fileNumber);
                results.Flush();

                //number of words in each document
                int numWords = fileNum.Count;
                
                    foreach (KeyValuePair<string, double> kvp in terms[fileNumber].OrderBy(key => key.Value))
                    {
                        //change key to term frequency of each word
                        terms[fileNumber][kvp.Key] = kvp.Value / numWords;

                    
                        //get number of appearances of the given word
                        words.TryGetValue(kvp.Key, out int k);

                        //calculate IDF for each word
                        terms[fileNumber][kvp.Key] = (Math.Log10(8282 / k) / Math.Log10(2)) * terms[fileNumber][kvp.Key];

                        //write results to file
                        results.Write(terms[fileNumber][kvp.Key] + " ");
                        
                        results.Flush();
                    }
                
                //move to next file
                fileNumber++;
            }
 
            results.Close();
            Console.WriteLine("Complete");

            Console.ReadLine();

        }



    }
}
