/*OVERSEER.CS
 * STARTS FILE PROCESSING
 * CALCULATES TF-IDF
 * 
 * Authors: Christina Hinton & Brayden Faulkner
 */

 //TODO: only include top used words

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
            Dictionary<string, double>[] terms = new Dictionary<string, double>[10000]; //10,000 documents

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
                if(fileNum == null)
                {
                    Console.WriteLine("Calculation complete.");
                    break;
                }

                //write heading for each file, for readability
                results.WriteLine();
                results.WriteLine("Document " + fileNumber);
                results.Flush();

                //write to console
                Console.WriteLine();
                Console.WriteLine("Document " + fileNumber);

                //number of words in each document
                int numWords = fileNum.Count;
                int count = 0;
                    foreach (KeyValuePair<string, double> kvp in terms[fileNumber].OrderByDescending(key => key.Value))
                    {
                        if(count > 1000)
                        {
                            break;
                        }
                        //change key to term frequency of each word
                        double x = kvp.Value / numWords;
                        
                        //get number of appearances of the given word
                        words.TryGetValue(kvp.Key, out int k);

                        //calculate IDF for each word
                        terms[fileNumber][kvp.Key] = (Math.Log10(7/ k) / Math.Log10(2)) * x;

                        //write results to file
                        results.Write(terms[fileNumber][kvp.Key] + " ");
    
                        results.Flush();
                    
                        if(terms[fileNumber][kvp.Key] > 0)
                            {
                                Console.WriteLine(kvp);
                            }
                    
                        count++;
                    }
                
                //move to next file
                fileNumber++;
            }
            
            results.Close();

            Console.WriteLine();
            Console.WriteLine("Complete");

            Console.ReadLine();

        }


    }
}
