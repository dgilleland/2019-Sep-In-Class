using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetSharp
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public interface IPrompt<T>
    {
        T Prompt(string message);
    }

    public class TextInput : IPrompt<string>
    {
        public string Prompt(string message)
        {
            Console.Write(message);
            return Console.ReadLine();
        }
    }

    public class WholeNumberInput : IPrompt<int>
    {
        public int Prompt(string message)
        {
            int result;
            Console.Write(message);
            string input = Console.ReadLine();
            while(!int.TryParse(input, out result))
            {
                Console.WriteLine("\tThat is not a whole number. Try again.");
                Console.Write(message);
                input = Console.ReadLine();
            }
            return result;
        }
    }
}
