using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LendingLibrary
{
    public class Book
    {
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int NumberOfPages { get; set; }
        public Book(string title, string firstName, string lastName, int numberOfPages)
        {

            this.Title = title;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.NumberOfPages = numberOfPages;

        }
    }
}
