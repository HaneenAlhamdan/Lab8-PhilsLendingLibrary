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
            LoadBooks();
            UserInterface();
        }
        static void AllBooks(IEnumerable<Book> books)
        {
            int count = 1;
            foreach (Book book in library)
            {
                Console.WriteLine($" {count++}. {book.Title} BY {book.FirstName} {book.LastName} ");
            }
        }
        static void LoadBooks()
        {
            library.Add("Ulysses", "James", "Joyce", 200);
            library.Add("Moby Dick", "Herman", "Melville", 150);
            library.Add("War and Peace", "Leo", "Tolstoy", 200);
            library.Add("Hamlet", "William", "Shakespeare", 400);
        }
        static void AddBook()
        {
            Console.WriteLine("Enter the following details:");
            Console.WriteLine("Book title");
            string title = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Author First Name");
            string firstName = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Author Last Name");
            string lastName = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Number of pages");
            string numberOfPages = Console.ReadLine();
            int.TryParse(numberOfPages, out int result);
            library.Add(title, firstName, lastName, result);
        }
        static void BorrowBook()
        {
            int count = 1;
            foreach (Book book in library)
            {
                Console.WriteLine($" {count++}. {book.Title} BY {book.FirstName} {book.LastName} ");
            }
            Console.WriteLine();
            Console.WriteLine("Name a book would you like to borrow");
            string selection = Console.ReadLine();
            Book Borrowed = library.Borrow(selection);
            backpack.Pack(Borrowed);
        }
        static void ReturnBook()
        {
            BackPack();
            Console.WriteLine();
            Console.WriteLine("Which book would you like to return");
            int  selection = Convert.ToInt32(Console.ReadLine());
            Book Returned =backpack.Unpack(selection - 1); // zero based
            library.Return(Returned);
        }
        static void BackPack()
        {
            int count = 1;
            foreach (Book book in backpack)
            {
                Console.WriteLine($"{count++}. {book.Title}");
            }
        }
        public static void UserInterface()
        {
            int num = 0;
            while (true)
            {
                Console.WriteLine("choose an option:");
                Console.WriteLine("1. View all Books");
                Console.WriteLine("2. Add a Book");
                Console.WriteLine("3. Borrow a book");
                Console.WriteLine("4. Return a book");
                Console.WriteLine("5. View book bag");
                Console.WriteLine("6. EXIT");
                Console.WriteLine();
                Int32.TryParse(Console.ReadLine(), out num);  // parse uer choice to decimal, and store it in num variable 
                if (num < 0 || num > 6)
                {
                    Console.WriteLine("please select number from the list");
                }
                else
                {
                    switch (num)
                    {
                        case 1:
                            {
                                Console.WriteLine("Books inside libary are");
                                Console.WriteLine();
                                AllBooks(library);
                                Console.WriteLine();
                                break;
                            }
                        case 2:
                            {
                                AddBook();
                                Console.WriteLine();
                                Console.WriteLine("Book Added");
                                Console.WriteLine();
                                break;
                            }
                        case 3:
                            {
                                BorrowBook();
                                Console.WriteLine();
                                break;
                            }
                        case 4:
                            {
                                ReturnBook();
                                Console.WriteLine();
                                break;
                            }
                        case 5:
                            {
                                Console.WriteLine("Book bag:");
                                BackPack();
                                Console.WriteLine();
                                break;
                            }
                        case 6:
                            {
                                return;
                            }
                            default:
                            Console.WriteLine("Invalid option");
                            Console.WriteLine();
                            break;
                    }
                }
            }
        }
    }
}
