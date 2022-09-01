using net_laba2.Enums;
using net_laba2.Models;
using System;
using System.Collections.Generic;
using System.Xml;

namespace net_laba2.XmlServices
{
    internal class XmlReaderService
    {
        public IEnumerable<Author> ReadAuthor(string filename)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(filename);

            var authors = new List<Author>();

            foreach (XmlElement item in xmlDoc.DocumentElement)
            {
                var author = new Author
                {
                    Id = int.Parse(item["Id"].InnerText),
                    Name = item["Name"].InnerText
                };

                authors.Add(author);
            }
            return authors;
        }
        public IEnumerable<Book> ReadBook(string filename)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(filename);

            var books = new List<Book>();

            foreach (XmlElement item in xmlDoc.DocumentElement)
            {
                var book = new Book
                {
                    Id = int.Parse(item["Id"].InnerText),
                    Name = item["Name"].InnerText,
                    AuthorId = int.Parse(item["AuthorId"].InnerText),
                    GenreId = int.Parse(item["GenreId"].InnerText),
                    Deposit = decimal.Parse(item["Deposit"].InnerText),
                    RentPrice = decimal.Parse(item["RentPrice"].InnerText)
                };

                books.Add(book);
            }
            return books;
        }
        public IEnumerable<Genre> ReadGenre(string filename)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(filename);

            var genres = new List<Genre>();

            foreach (XmlElement item in xmlDoc.DocumentElement)
            {
                var genre = new Genre
                {
                    Id = int.Parse(item["Id"].InnerText),
                    Name = item["Name"].InnerText
                };

                genres.Add(genre);
            }
            return genres;
        }
        public IEnumerable<Reader> ReadReader(string filename)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(filename);

            var users = new List<Reader>();

            foreach (XmlElement item in xmlDoc.DocumentElement)
            {
                var user = new Reader
                {
                    Id = int.Parse(item["Id"].InnerText),
                    LastName = item["LastName"].InnerText,
                    Name = item["Name"].InnerText,
                    Patronymic = item["Patronymic"].InnerText,
                    Address = item["Address"].InnerText,
                    PhoneNumber = item["PhoneNumber"].InnerText,
                    Category = (Category)Enum.Parse(typeof(Category), item["Category"].InnerText)
                };

                users.Add(user);
            }
            return users;
        }

        public IEnumerable<RentedBook> ReadRentedBooks(string filename)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(filename);

            var rentedBooks = new List<RentedBook>();

            foreach (XmlElement item in xmlDoc.DocumentElement)
            {
                var rentedBook = new RentedBook
                {
                    ReaderId = int.Parse(item["ReaderId"].InnerText),
                    BookId = int.Parse(item["BookId"].InnerText),
                    IssueDate = DateTime.Parse(item["IssueDate"].InnerText),
                    ReturnDate = DateTime.Parse(item["ReturnDate"].InnerText)
                };

                rentedBooks.Add(rentedBook);
            }
            return rentedBooks;
        }
    }
}
