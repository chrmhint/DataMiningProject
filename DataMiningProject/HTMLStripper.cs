/*
 * HTMLSTRIPPER.CS
 * STRIPS A GIVEN DOCUMENT OF ITS HTML TAGS
 * CALLS STOP WORD REMOVER TO REMOVE STOP WORDS AND STEM 
 * SAVES TO A FILE FOR READABILITY
 * 
 * Authors: Christina Hinton & Brayden Faulkner
 */


using DataMiningProject;
using System.Collections.Generic;
using System.IO;


namespace DataMining_Project1
{
    class HTMLStripper
    {
        public string RemoveHTML(string fileName, int fileNumber, ref Dictionary<string, double>[] d, ref Dictionary<string, int> w, ref Dictionary<string, int> a)
        {

            //input file
            StreamReader reader = new StreamReader(fileName);

            //output file
            string test = "files\file" + fileNumber.ToString() + ".txt";

    
            StopWordRemover t = new StopWordRemover();
            string contents = " ";

            string line;

            while((line = reader.ReadLine()) != null)
            {
                //trim whitespace from line
                line = line.TrimStart();

                
                //look for html
                int pos = line.IndexOf("<");

               //while open tags are found
               while(pos > -1)
                {
                    
                    //find closing tag
                    int endPos = line.IndexOf(">");

                    if (endPos > -1)

                    {
                        //if tag is at the end of the line
                        if (endPos == line.Length - 1)
                        {
                            line = line.Substring(0, pos);

                        }

                        //tag-ception
                        else
                        {
                            line = line.Substring(endPos + 1);

                        }
                    }

                    //sucks if you're just trying to show something is less than something lmao
                    else
                    {
                        
                        line = " ";
                    }

                    //find next instance
                    pos = line.IndexOf("<");

                }
               //only add non-empty lines
                if (line != "")
                {
                    
                    contents = contents + " " + line;
                }
                

            }
            
            //stemmed contents of file
            contents = t.CleanText(contents, ref d, fileNumber, ref w, ref a);

          

            //write to file

            StreamWriter outFile = new StreamWriter(@"files\file" + fileNumber.ToString() + ".txt");
                
            outFile.Write(contents);

            outFile.Close();
            

          
            
            return contents;


        }
    }
}
