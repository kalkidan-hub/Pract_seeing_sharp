using System;
using System.Collections.Generic;

namespace Project5
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var exit = false;
            var DataBase = new Dictionary<string, string>();

            do
            {
                bool isValid;
                int value;
                do
                {
                    Console.Write(
                        """
                    Here are options for you to choose from
                    1. Add Contact
                    2. View Contact
                    3. Update Contact
                    4. Delete Contact
                    5. List All Contacts
                    6. Exit

                    Enter your choice: 
                    """
                    );

                    isValid = int.TryParse(Console.ReadLine(), out value);
                    isValid = isValid && value > 0 && value < 7;

                } while (!isValid);

                switch (value)
                {
                    case 1:
                        Console.WriteLine("Please enter the name of the contact");
                        string key = Console.ReadLine();
                        Console.WriteLine("Please enter the value of the contact");
                        string dictValue = Console.ReadLine();

                        DataBase.Add(key, dictValue);

                      
                        break;
                    case 2:
                        Console.WriteLine("Please enter the name you want to see contact of");
                        string key1 = Console.ReadLine();
                        string dicValue1;
                        DataBase.TryGetValue(key1, out dicValue1);
                        Console.WriteLine(dicValue1);
                        break;
                    case 3:
                        Console.WriteLine("Please enter the name of contact you want to update");
                        string key2 = Console.ReadLine();
                        if (DataBase.ContainsKey(key2))
                        {
                            Console.WriteLine(DataBase[key2]);
                        }
                        else
                        {
                            Console.WriteLine("Contact with such name doesn't exist");
                        }
                        break;
                    case 4:
                        Console.WriteLine("Please enter the name of the contact you want to see deleted");
                        string key3 = Console.ReadLine();
                        if (DataBase.ContainsKey(key3))
                        {
                            DataBase.Remove(key3);
                        }
                        else
                        {
                            Console.WriteLine("Contact with such name doesn't exist to begin with");
                        }
                        break;
                    case 5:
                        foreach (var kv in DataBase)
                        {
                            Console.WriteLine($" ------------------------------- \n Name: {kv.Key} Contact: {kv.Value} " +
                                $"\n --------------------------------------");
                        }
                        break;
                    default:
                        Console.WriteLine("Have a good day");
                        exit = true;
                        break;
                }

            } while (!exit);
        }
    }
}