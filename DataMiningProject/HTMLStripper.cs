//TODO: capability to loop over 10k times to remove all tags from every document in the set


using DataMiningProject;
using System;
using System.Collections.Generic;
using System.IO;


namespace DataMining_Project1
{
    class HTMLStripper
    {
        

        public string RemoveHTML(string fileName, int fileNumber, ref Dictionary<string, int>[] d)
        {

            //input file
            StreamReader reader = new StreamReader(fileName);

            //output file
            string test = "files\file" + fileNumber.ToString() + ".txt";
           

            StreamWriter outFile = new StreamWriter(@"files\file" + fileNumber.ToString() + ".txt");
            
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

                if (line != "")
                {
                    
                    contents = contents + " " + line;
                }
                

            }
            
            //stem contents of file
            contents = t.CleanText(contents, ref d, fileNumber);
            
            
            outFile.Write(contents);
            outFile.Close();

            return contents;

  

        }
    }
}
