namespace ConsoleApplication1
{
    interface IFizzBuzz
    {
        void Write(string text);
    }

    class FizzBuzz
    {
        public readonly IFizzBuzz _output;
        public FizzBuzz(IFizzBuzz output)
        {
            _output = output;
        }

        public void Run(int from, int counter)
        {
            for (int i = from; i < from + counter; i++)
            {
                bool div3 = (i % 3 == 0);
                bool div5 = (i % 5 == 0);
                if (div3 && div5)
                {
                    _output.Write("Fizz Buzz");
                }
                else if (div3)
                {
                    _output.Write("Fizz");
                }
                else if (div5)
                {
                    _output.Write("Buzz");
                }
                else
                {
                    _output.Write(i.ToString());
                }
            }
        }
    }

    class ConsoleFizzOutput : IFizzBuzz
    {
        public void Write(string output)
        {
            Console.WriteLine(output);
        }
    }

    public delegate void FizzBuzzOutput (string output);
    public class Program
    {
        static void WriteFizzBuzz(string output)
        {
            Console.WriteLine(output);
        }
        public static void Run(FizzBuzzOutput output, int from, int counter)
        {
            for (int i = from; i < from + counter; i++)
            {
                bool div3 = (i % 3 == 0);
                bool div5 = (i % 5 == 0);
                if (div3 && div5)
                {
                    output("Fizz Buzz");
                }
                else if (div3)
                {
                    output("Fizz");
                }
                else if (div5)
                {
                    output("Buzz");
                }
                else
                {
                    output(i.ToString());
                }
            }
        }
        public static void Main(string[] args)
        {
            /*
            for (int i = 1; i < 100; i++) 
            {
                bool div3 = (i % 3 == 0);
                bool div5 = (i % 5 == 0);
                if (div3 && div5)
                {
                    Console.WriteLine("Fizz Buzz");
                }
                else if (div3)
                {
                    Console.WriteLine("Fizz");
                }
                else if (div5)
                {
                    Console.WriteLine("Buzz");
                }
                else
                {
                    Console.WriteLine(i);
                }

            }
            */

            //var fizzBuzz = new FizzBuzz(new  ConsoleFizzOutput());
            //fizzBuzz.Run(1, 100);

            //Run(WriteFizzBuzz, 1, 100);

            Run(Console.WriteLine, 1, 100);

        }
    }
}