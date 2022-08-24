using System;
using static System.Console;

namespace Bookstore
{
	public class Book
	{
		private string bookId;
		private string categoryNameOfBook;
		public static string[] categoryCodes = { "CS", "IS", "SE", "SO","MI" };
		public static string[] categoryNames = { "Computer Science", "Information System", "Security", "Society", "Miscellaneous"};

		public string BookId
		{ 
            get { return bookId; }
			set
			{				
				string misc = "MI";
				if ((value.Substring(0, 2) == "CS") || (value.Substring(0, 2) == "IS") || (value.Substring(0, 2) == "SE") || (value.Substring(0, 2) == "SO") || (value.Substring(0, 2) == "MI"))
				{
					bookId = value;
					categoryNameOfBook = value.Substring(0, 2);
				}
                else
                {
					bookId = misc + value.Substring(2, 3);
					categoryNameOfBook = misc;
				}
			}
		}
		public string CategoryNameOfBook
		{
			get { return categoryNameOfBook; }
		}
		public string BookTitle { get; set; }
		public int NumOfPages { get; set; }
		public double Price { get; set; }

		public Book()
		{
		}

		public Book(string bookId, string bookTitle, int numPages, double price)
		{
			BookId = bookId;
			BookTitle = bookTitle;
			NumOfPages = numPages;
			Price = price;
		}

        public override string ToString()
        {
			return bookId + "   " + BookTitle + "        " + NumOfPages + "   "+ Price.ToString("C");
        }
    }
}

