using System;
using Xunit;
using LendingLibrary;

namespace TestProject1
{
    public class UnitTest1
    {
       
        [Fact]
        public void TestAddBook()
        {
            Library<Book> library = new Library<Book>();
            Book book = new Book("Fear of Flying", "Erica", "Jong", 400);
            Assert.Equal("Fear of Flying", book.Title);
        }

        [Fact]
        public void TestBorrowingNotExisting()
        {
            Library<Book> library = new Library<Book>();
            Book book = new Book("Fear of Flying", "Erica", "Jong", 400);
            library.Return(book);
            library.Borrow("Fear of Flying");
            Assert.DoesNotContain(book, library);
        }
        [Fact]
        public void TestBorrowingExisting()
        {
            Library<Book> library = new Library<Book>();
            Book book = new Book("Fear of Flying", "Erica", "Jong", 400);
            library.Return(book);
            Assert.Equal(book, library.Borrow("Fear of Flying"));
        }
        [Fact]
        public void TestBorrowing()
        {
            Library<Book> library = new Library<Book>();
            Book book = new Book("Fear of Flying", "Erica", "Jong", 400);
            library.Return(book);
            Assert.Contains(book, library);
        }
        [Fact]
        public void TestpackBackpack()
        {
            Backpack<string> backpack = new Backpack<string>();
            string str = "Erica";
            backpack.Pack(str);
            Assert.Contains(str, backpack);
        }
        [Fact]
        
         public void TestUnpackBackpack()
         {
            Backpack<Book> backpack = new Backpack<Book>();
            Book book = new Book("Fear of Flying", "Erica", "Jong", 400);
            backpack.Pack(book);
            backpack.Unpack(0);
            Assert.DoesNotContain(book, backpack);
         }
    }
}
