using System;
using System.IO;
using System.Linq;
using System.Threading.Channels;
using Humanizer;

namespace SpeedType
{
    public class SentenceProvider
    {
        private readonly string[] sentences;
        private readonly Random random;

        /// <summary>
        /// Initializes a new instance of the <see cref="SentenceProvider"/> 
        /// class. Reads sentences from a file and stores them in an array. 
        /// If the file is not found, a default sentence is used.
        /// </summary>
        /// <remarks>
        /// This constructor attempts to read a file named "sentences.txt" 
        /// located in the directory two levels above the application's base 
        /// directory. Each line of the file is processed using the 
        /// <see cref="Humanizer"/> library's <c>Humanize()</c> method before 
        /// being added to the array. If the file does not exist, the array 
        /// will contain a single default sentence: "No Sentences Found! Please 
        /// Provide a File."
        /// </remarks>
        public SentenceProvider()
        {
            random = new Random();// ////////// => TO IMPLEMENT <= //////////// //
            
            string directoryPath = Path.GetFullPath(
                Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\"
                )
            );
            string filePath = Path.Combine(directoryPath, "sentences.txt");

            if (File.Exists(filePath))
            {
                sentences = File.ReadAllLines(filePath);
                // ////////// => TO IMPLEMENT <= //////////// //
            }
            else
            {
                sentences = new[] { "No Sentences Found! Please Provide a"
                    + " File." };
            }
        }

        /// <summary>
        /// Retrieves a random sentence from the array of sentences.
        /// </summary>
        /// <returns>
        /// A <see cref="string"/> representing a randomly selected sentence 
        /// from the array of sentences.
        /// </returns>
        public string GetRandomSentence()
        {
            string result = sentences[random.Next(sentences.Length)];
            string newResult = "";
            for (int i = 0; i < result.Length; i++)
            {
                if (i > 0 && char.IsUpper(result[i]))
                    newResult += " ";
                newResult += result[i];
            }
            return newResult;
        }
        
    }
}