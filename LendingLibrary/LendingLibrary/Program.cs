using System;
using System.Collections.Generic;
using System.Collections;

namespace LendingLibrary
{
    internal class Program
    {
        public static Library<Book> library = new Library<Book>();
        public static Backpack<Book> backpack = new Backpack<Book>();

        static void Main(string[] args)
        {
            library.Add("Ulysses", "James", "Joyce",200);
            library.Add("Moby Dick", "Herman", "Melville",150);
            library.Add("War and Peace", "Leo", "Tolstoy", 200);
            library.Add("Hamlet", "William", "Shakespeare", 400);
            Console.WriteLine("Books Inside Library:");
            Console.WriteLine();
            AllBooks();
            Console.WriteLine("****************************************************");
            backpack.Pack(library.Borrow("Hamlet"));
            backpack.Pack(library.Borrow("War and Peace"));
            backpack.Pack(library.Borrow("Ulysses"));
            Console.WriteLine("My Back Pack: ");
            Console.WriteLine();
            BackPack();
            Console.WriteLine("****************************************************");
            Console.WriteLine("Library After Borrow:");
            Console.WriteLine();
            AllBooks();
            Console.WriteLine("****************************************************");
            backpack.Unpack(2);
            Console.WriteLine("BackPack after remove the item from it at the given index");
            Console.WriteLine();
            BackPack();
            Book Newbook = new Book("History", "jhon", "lwies", 500);
            library.Add("Letting Go", "Philip", "Roth",150);
            library.Return(Newbook);
            Console.WriteLine("****************************************************");
            Console.WriteLine("library after return");
            Console.WriteLine();
            AllBooks();

        }
        static void AllBooks()
        {
            foreach (Book book in library)
            {
                Console.WriteLine($"{book.Title} BY {book.FirstName} {book.LastName}");
            }
        }
        static void BackPack()
        {
            foreach (var book in backpack)
            {
                Console.WriteLine(book.Title);
            }
        }

    }
}
