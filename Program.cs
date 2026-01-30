// console-based program that prints out a multiplication table
// prompt user for the number of rows
// prompt user for the number of columns
// display a multiplication table for the number 1 .. rows by 1... columns

int rows, columns;
bool isValid;

do
{
    Console.WriteLine("please enter number of rows");
    string userRows = Console.ReadLine();
    isValid = int.TryParse(userRows, out rows);


} while (!isValid);

do
{
    Console.WriteLine("please enter number of columns");
    string userCol = Console.ReadLine();
    isValid = int.TryParse(userCol, out columns);


} while (!isValid);

for (int i = 0; i <= rows; i++)
{
    if (i == 0)
    {
        for (int j = 0; j <= columns; j++)
        {

            Console.Write($"{j,5} |");
        }
        Console.WriteLine();
        Console.Write(new String('-', 8 * (columns + 1)));
        Console.WriteLine();


    }
    else
    {
        Console.Write($"{i,5} |");
        for (int j = 1; j <= columns; j++)
        {
            Console.Write($"{i * j, 5} |");
        }
        Console.WriteLine();
    }
}