using System;
using net_laba2.Enums;
using net_laba2.Models;

namespace net_laba2.ConsoleServices
{
    internal class ConsoleReader
    {
        public Author ReadAuthor()
        {
            Console.WriteLine("Enter Id: ");
            var author = new Author { Id = int.Parse(Console.ReadLine()) };

            Console.WriteLine("Enter Name: ");
            author.Name = Console.ReadLine();

            return author;
        }

        public Book ReadBook()
        {
            Console.WriteLine("Enter Id: ");
            var book = new Book() { Id = int.Parse(Console.ReadLine()) };

            Console.WriteLine("Enter Name: ");
            book.Name = Console.ReadLine();

            Console.WriteLine("Enter Author Id: ");
            book.AuthorId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Genre Id: ");
            book.GenreId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Deposit: ");
            book.Deposit = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Enter Rent Price: ");
            book.RentPrice = decimal.Parse(Console.ReadLine());

            return book;
        }

        public Genre ReadGenre()
        {
            Console.WriteLine("Enter Id: ");
            var genre = new Genre { Id = int.Parse(Console.ReadLine()) };

            Console.WriteLine("Enter Name: ");
            genre.Name = Console.ReadLine();

            return genre;
        }

        public Reader ReadReader()
        {
            Console.WriteLine("Enter Id: ");
            var reader = new Reader() { Id = int.Parse(Console.ReadLine()) };

            Console.WriteLine("Enter Lastname: ");
            reader.LastName = Console.ReadLine();

            Console.WriteLine("Enter Name: ");
            reader.Name = Console.ReadLine();

            Console.WriteLine("Enter Patronymic: ");
            reader.Patronymic = Console.ReadLine();

            Console.WriteLine("Enter Address: ");
            reader.Address = Console.ReadLine();

            Console.WriteLine("Enter PhoneNumber: ");
            reader.PhoneNumber = Console.ReadLine();

            Console.WriteLine("Enter Category: ");
            reader.Category = (Category)Enum.Parse(typeof(Category), Console.ReadLine());

            return reader;
        }

        public RentedBook ReadRentedBook()
        {
            Console.WriteLine("Enter Reader Id: ");
            var rented = new RentedBook() { ReaderId = int.Parse(Console.ReadLine()) };

            Console.WriteLine("Enter Book Id: ");
            rented.BookId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Issue Date Id (dd.mm.yyyy): ");
            rented.IssueDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter Return Date Id (dd.mm.yyyy): ");
            rented.ReturnDate = DateTime.Parse(Console.ReadLine());

            return rented;
        }
    }
}
