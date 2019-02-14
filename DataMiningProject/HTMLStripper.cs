//TODO: capability to loop over 10k times to remove all tags from every document in the set


using System;
using System.IO;


namespace DataMining_Project1
{
    class HTMLStripper
    {
        public void RemoveHTML(string fileName)
        {


            StreamReader reader = new StreamReader(fileName);
            //output file
            StreamWriter outFile = new StreamWriter("test.txt");



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
                    outFile.WriteLine(line);

                }
                outFile.Flush();

            }
            

          
            //let the user know conversion is complete
            Console.WriteLine("Conversion complete.");
            

        }
    }
}
