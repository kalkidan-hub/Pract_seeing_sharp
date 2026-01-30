// a program that masks credit card number

namespace Project4
{
    internal class Program2
    {
        public static void Main(string[] args)
        {
            string ccNum;
            do
            {
                Console.WriteLine("Please enter your credit card");
                ccNum = Console.ReadLine();

            } while (string.IsNullOrEmpty(ccNum));

            Console.WriteLine(Masker(ccNum));
        }

        public static string Masker(string creditCard)
        {
            string maskedCard = "";
            for (int i = 0;  i < creditCard.Length; i++)
            {
                if (creditCard[i] == '-' || char.IsWhiteSpace(creditCard[i]) || i >= creditCard.Length - 4)
                {
                    maskedCard += creditCard[i];
                }
                else
                {
                    maskedCard += "X";
                }

            }
            return maskedCard;

        }
    }
}
