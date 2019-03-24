/*
 * STOPWORDREMOVER.CS
 * REMOVES STOP WORDS, SENDS EACH WORD TO BE STEMMED
 * POPULATES EACH DICTIONARY ELEMENT WITH THE WORDS AND THEIR 
 * NUMBER OF APPEARANCES IN THE DOCUMENT
 * 
 * Authors: Christina Hinton & Brayden Faulkner
 */
namespace DataMiningProject
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Text;
   

    public class StopWordRemover
    {
        //list of common stop words
        private static string[] stopWordsArrary = new string[] { "a", "about", "actually", "after", "also", "am", "an",
                                                                "and", "any", "are", "as", "at", "be", "because", "but", "by",
                                                                 "could", "do", "each", "either", "en", "for", "from", "has",
                                                                "have", "how", "i", "if", "in", "is", "it", "its", "just", "of",
                                                                "or", "so", "some", "such", "that", "the", "their", "these",
                                                                "thing", "this", "to", "too", "very", "was", "we", "well", "what",
                                                                "when", "where", "who", "will", "with", "you", "your", "on", "they",
                                                                "through", "those", "can", "should", "has", "go", "all", "doing", "take",
                                                                "which", "sunday", "monday", "tuesday", "wednesday", "thursday", "friday", 
                                                                "saturday", "##############################################################################"
                                                               };


  
        // Removes stop words from the specified search string.
		public string CleanText(string searchedWords, ref Dictionary<string, double>[] terms, int fileNumber, ref Dictionary<string, int> w)
        {
            Porter2 porter = new Porter2();
            

            searchedWords = searchedWords
                                            .Replace("\\", string.Empty)
                                            .Replace("|", string.Empty)
                                            .Replace("(", string.Empty)
                                            .Replace(")", string.Empty)
                                            .Replace("[", string.Empty)
                                            .Replace("]", string.Empty)
                                            .Replace("*", string.Empty)
                                            .Replace("?", string.Empty)
                                            .Replace("}", string.Empty)
                                            .Replace("{", string.Empty)
                                            .Replace("^", string.Empty)
                                            .Replace("+", string.Empty);

            // transform search string into array of words
            char[] wordSeparators = new char[] { ' ', '\n', '\r', ',', ';', '.', '!', '?', '-', ' ', '"', '\'' };
            string[] words = searchedWords.Split(wordSeparators, StringSplitOptions.RemoveEmptyEntries);

            int index = 0;

            //stem each word
            foreach (string word in words)
            {
                 words[index] = porter.stem(word);

                //next word
                index++;
            }

            // Create and initializes a new StringCollection.
            StringCollection myStopWordsCol = new StringCollection();

            // Add a range of elements from an array to the end of the StringCollection.
            myStopWordsCol.AddRange(stopWordsArrary);

            StringBuilder sb = new StringBuilder();
            
            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i].ToLowerInvariant().Trim();
                if (word.Length > 1 && !myStopWordsCol.Contains(word))
                    sb.Append(word + " ");
            }

            string s = sb.ToString();

            //array of stemmed words
            string[] newWords = s.Split(wordSeparators, StringSplitOptions.RemoveEmptyEntries);

            foreach (string n in newWords){
                
                //if word is already present in list, update word value
                if (terms[fileNumber].ContainsKey(n))
                {
                    terms[fileNumber][n] = terms[fileNumber][n] + 1;
                }

                //else, add a new pair to the list
                else
                {
                    terms[fileNumber].Add(n, 1);

                    //when a new word is added, see if it's in the word-appearance array
                    //increment the value if it already exists in the array
                    if (w.ContainsKey(n))
                    {
                        w[n] = w[n] + 1;
                    }

                    //otherwise, add the word with a value of 1
                    else
                    {
                        w.Add(n, 1);
                    }
                }

                
            }


            return s;
        }
    }
}
