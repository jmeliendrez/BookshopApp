using System;
using static System.Console;

namespace Bookstore
{
    class Program
    {
        static void Main()
        {
            const int MIN = 1;
            const int MAX = 30;
            int i;
            WriteLine("        WELCOME TO THE BOOKSTORE");
            WriteLine("|||>>>>>>>>>>>>>>>-*-<<<<<<<<<<<<<<<|||");

            int bookCount = InputValue(MIN, MAX);

            WriteLine("\n|||>>>>>>>>>>>>>>>-*-<<<<<<<<<<<<<<<|||");
            Book[] book = new Book[bookCount];
           
            for (i = 0; i < book.Length; i++)
                book[i] = new Book();
            
            for (i = 0; i < book.Length; i++)
                GetBookData(i, book);

            WriteLine("\n|||>>>>>>>>>>>>>>>-*-<<<<<<<<<<<<<<<|||");
            WriteLine("\nInformation of All Books\n");
            DisplayAllBooks(book);

            WriteLine("\n|||>>>>>>>>>>>>>>>-*-<<<<<<<<<<<<<<<|||");
            GetLists(0, book);


        }

        public static int InputValue (int min, int max)
        {
            int input;
            do
            {
                WriteLine("\nEnter a number which is in the range of {0} and {1}>> ", min, max);
                input = Convert.ToInt32(ReadLine());
            } while ((input < min) || (input > max));

            return input;
        }

        public static bool IsValid(string id)
        {
            bool validity;
            char lowL = Char.Parse("A");
            char highL = Char.Parse("Z");
            char lowN = Char.Parse("0");
            char highN = Char.Parse("9");
            char one = Char.Parse(id.Substring(0, 1));
            char two = Char.Parse(id.Substring(1, 1));
            char three = Char.Parse(id.Substring(2, 1));
            char four = Char.Parse(id.Substring(3, 1));
            char five = Char.Parse(id.Substring(4, 1));

            if (!((id.Length == 5) && (one >= lowL) && (one <= highL) && (two >= lowL) && (two <= highL) && (three >= lowN) && (three <= highN) && (four >= lowN) && (four <= highN) && (five >= lowN) && (five <= highN)))
                validity = false;
            else
                validity = true;
            return validity;
        }

        private static void GetBookData (int num, Book[] books)
        {
            WriteLine("\nEnter book name >> ");
            string name = ReadLine();
            WriteLine("Category codes are: \nCS   Computer Science\nIS   Information System\nSE   Security\nSO  Society\nMI   Miscellaneous");
                
            bool validity = false;
            string code;
            do
            {
                WriteLine("Please enter book ID which starts with a category code and ends with a 3-digit number >>");
                code = ReadLine(); 
                validity = IsValid(code);
            } while (validity == false);

                WriteLine("Enter book price >> ");
                double price = Convert.ToDouble(ReadLine());
                WriteLine("Enter number of pages >> ");
                int pages = Convert.ToInt32(ReadLine());

                books[num].BookId = code;
                books[num].BookTitle = name;
                books[num].Price = price;
                books[num].NumOfPages = pages;
        }

        public static void DisplayAllBooks (Book[] books)
        {
            int x;
            for (x = 0; x < books.Length; x++)

                WriteLine("Book {0}:     {1}", x + 1, books[x].ToString());
        }

        private static void GetLists(int num, Book[] books)
        {
            const string QUIT = "Q";
            string input;
            int count;
            int x, y, z;
            bool check1, check2;

            WriteLine("\nThe codes of categories are:\n CS   Computer Science\n IS   Information System\n SE   Security\n SO   Society\n MI   Miscellaneous");
            do
            {
                WriteLine("\nEnter a category code or Q to quit >> ");
                input = ReadLine();
                count = 0;
                check1 = false;
                check2 = false;

                for (x = 0; x < Book.categoryCodes.Length; x++)
                {
                    if (input == Book.categoryCodes[x])
                    {
                        check1 = true;                
                    } 
                }
                for (y = 0; y < books.Length; y++)
                {
                    if (input == books[y].CategoryNameOfBook)
                    {
                        check2 = true;
                        y = books.Length;
                    }
                }

                if (check1 == false && check2 == false && input != QUIT)
                    WriteLine("Invalid code!");

                else if (check1 == true && check2 == false && input != QUIT)
                        WriteLine("No books in the {0} category.", input);

                else if (check1 == true && check2 == true && input != QUIT)
                {                    
                    WriteLine("\nBooks with category code {0} are:", input);
                    for (y = 0; y < books.Length; y++)
                    {
                        if (input == books[y].CategoryNameOfBook)
                        {                                    
                            WriteLine("{0}", books[y].ToString());                           
                            count++;
                        }                                                                        
                    }
                    WriteLine("Number of books in {0}: {1}", input, count);
                }
                
            } while (input != QUIT);

            WriteLine("\nGoodbye!");
        }
    }
}