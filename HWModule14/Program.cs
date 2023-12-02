using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWModule14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1.
            //Game game = new Game("Islam", "Olzhas");
            //game.Play();

            // Statistic
            // Я перевел текст из приложения 1 на английский, т к русский язык не поддерживается
            string text = "input.txt"; 

            StreamReader streamReader = new StreamReader(text);

            string text1 = streamReader.ReadToEnd();

            var words = GetWords(text1);

            var wordCounts = CountWords(words);

            DisplayStatistics(wordCounts);

            streamReader.Close();

            Console.ReadLine();
        }
        static List<string> GetWords(string text)
        {
            return text.Split(new[] { ' ', '\n', '\r', '.', ',', '!', '?' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(word => word.ToLower())
                .ToList();
        }

        static Dictionary<string, int> CountWords(List<string> words)
        {
            var wordCounts = new Dictionary<string, int>();

            foreach (var word in words)
            {
                if (wordCounts.ContainsKey(word))
                {
                    wordCounts[word]++;
                }
                else
                {
                    wordCounts[word] = 1;
                }
            }

            return wordCounts;
        }

        static void DisplayStatistics(Dictionary<string, int> wordCounts)
        {
            Console.WriteLine("Word\t\tCount");
            foreach (var kvp in wordCounts)
            {
                Console.WriteLine($"{kvp.Key}\t\t{kvp.Value}");
            }
        }
    }
}
