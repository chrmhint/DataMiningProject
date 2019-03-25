/*OVERSEER.CS
 * STARTS FILE PROCESSING
 * CALCULATES TF-IDF
 * 
 * Authors: Christina Hinton & Brayden Faulkner
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
            Dictionary<string, double>[] terms = new Dictionary<string, double>[10000]; //10,000 documents

            //list of words and number of document appearances
            Dictionary<string, int> words = new Dictionary<string, int>();

            //all words with their frequency
            Dictionary<string, int> allWords = new Dictionary<string, int>();

            //process files -> remove HTML tags, stop words, and stem words
            FileProcessor f = new FileProcessor();
            int totalDocs = f.processFiles(ref terms, ref words, ref allWords);

            //output file for results
            StreamWriter results = new StreamWriter("results.txt");

            //file to be be examined
            int fileNumber = 0;
            Console.WriteLine("Calculating Results");

            

                //write results to output file
                foreach (Dictionary<string, double> fileNum in terms)
                {
                    if(fileNum == null)
                    {
                    Console.WriteLine("Calculation complete.");
                    break;
                    }

                    //write heading for each file, for readability
                    results.WriteLine();
                    results.WriteLine("D" + fileNumber);
                    results.Flush();

                
                    //number of words in each document
                    int numWords = fileNum.Count;
                    int count = 0;

                    //for each word in the overall word list...
                    foreach (KeyValuePair<string, int> kvp in allWords.OrderByDescending(key => key.Value))
                    {

                        //only calculate the top 1000 words in the document
                        if (count > 1000)
                        {
                            break;
                        }

                      
                        //if term is in the file, compute tf-IDF
                        if (terms[fileNumber].ContainsKey(kvp.Key))
                        {
                            //change key to term frequency of each word
                            double x = terms[fileNumber][kvp.Key] / numWords;

                        

                            //get number of appearances of the given word
                            words.TryGetValue(kvp.Key, out int k);

                        
                            //calculate tf-IDF for each word
                            terms[fileNumber][kvp.Key] = (Math.Log(totalDocs / k)) * x;

                            //write results to file
                            results.Write(terms[fileNumber][kvp.Key] + " ");
                            
                        }

                        //otherwise, it is 0 b/c if tf = 0, then the entire product will be 0
                        else
                        {
                            results.Write("0 ");
                        }

                        results.Flush();

                    

                        count++;
                    
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
