//TODO: capability to loop over 10k times to remove all tags from every document in the set

using System;
using System.IO;
using System.Text;
using HtmlAgilityPack;

namespace DataMining_Project1
{
    class Program
    {
        static void Main(string[] args)
        {
            //HTML document to read
            var htmlDoc = new HtmlDocument();

            //get all text from file
            string text = System.IO.File.ReadAllText("assignment1.html");

            //load text in context of HTML
            htmlDoc.LoadHtml(text);

            //find all instances of the given tag type -> <html> because it surrounds every other tag
            var htmlNodes = htmlDoc.DocumentNode.SelectNodes("//html");

            //output file
            StreamWriter outFile = new StreamWriter("test.txt");

            //write all inner text to the output file
            foreach (var node in htmlNodes)
            {
                outFile.WriteLine(node.InnerText);

            }

            //let the user know conversion is complete
            Console.WriteLine("Conversion complete.");
            Console.ReadLine();

        }
    }
}
