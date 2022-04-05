using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LendingLibrary
{
    internal class Library: ILibrary
    {
        private Dictionary<string, Book> keyValuePairs = new Dictionary<string, Book>();

        int count = 0;

        public int Count => throw new NotImplementedException();

        public void Add(string title, string firstName, string lastName, int numberOfPages)
        {
            Book book = new Book();
            book.Title = title;
            book.Author = firstName + lastName;
            book.NumberOfPages = numberOfPages;
            keyValuePairs.Add(title, book);
            count++;
        }
        public bool Remove(string title)
        {
            if (keyValuePairs.ContainsKey(title))
            {
                keyValuePairs.Remove(title);
                count--;
                return true;

            } else
            {
                return false;
            }

        }
        public Book Borrow(string title)
        {
            // checking book dictionary and return it  
            if (keyValuePairs.ContainsKey(title))
            {
                count--;
                return keyValuePairs[title];
            } else
            {
                return null;
            }

        }
        public int Return(Book book)
        {
            if (keyValuePairs.TryGetValue(book.Title, out Book book1))
            {
                keyValuePairs[book.Title] = book1;
                count++;
                return count;
            } else
            {
                return 0;
            }
        }

        public IEnumerator<Book> GetEnumerator()
        {
            foreach (Book book in keyValuePairs.Values)
                yield return book;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
