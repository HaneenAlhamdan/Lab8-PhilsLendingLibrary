using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LendingLibrary
{
    public class Library: ILibrary
    {
        private Dictionary<string, Book> Dictionary = new Dictionary<string, Book>();

        public int Count { set; get; }

        public void Add(string title, string firstName, string lastName, int numberOfPages)
        {
            Dictionary.Add(title, new Book(title, firstName, lastName, numberOfPages));
            Count++;
        }
        public Book Borrow(string title)
        {
            // checking book dictionary and return it  
            if (Dictionary.ContainsKey(title))
            {
                Book book = Dictionary[title];
                Dictionary.Remove(title);
                Count--;
                return book;
            } else
            {
                return null;
            }

        }
        public void Return(Book book)
        {
            Dictionary.Add(book.Title, book);
            Count++;
        }

        public IEnumerator<Book> GetEnumerator()
        {
            foreach (Book book in Dictionary.Values)
                yield return book;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
