// Reverse String

Console.WriteLine("Enter a value you want to see reversed");
string inputString = Console.ReadLine();
string reversedString = "";

for (int i = inputString.Length - 1; i >= 0; i--)
{
    reversedString += inputString[i];
}
Console.WriteLine(reversedString);