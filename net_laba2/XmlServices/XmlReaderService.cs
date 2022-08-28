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
            var authors = new List<Author>();
            using (XmlReader reader = XmlReader.Create(filename))
            {
                while (reader.ReadToFollowing("Author"))
                {
                    reader.ReadToFollowing("Id");
                    var author = new Author { Id = int.Parse(reader.ReadElementContentAsString()) };

                    reader.ReadToFollowing("Name");
                    author.Name = reader.ReadElementContentAsString();

                    authors.Add(author);
                }
            }
            return authors;
        }
        public IEnumerable<Book> ReadBook(string filename)
        {
            var books = new List<Book>();
            using (XmlReader reader = XmlReader.Create(filename))
            {
                while (reader.ReadToFollowing("Book"))
                {
                    reader.ReadToFollowing("Id");
                    var book = new Book { Id = int.Parse(reader.ReadElementContentAsString()) };

                    reader.ReadToFollowing("Name");
                    book.Name = reader.ReadElementContentAsString();

                    reader.ReadToFollowing("AuthorId");
                    book.AuthorId = int.Parse(reader.ReadElementContentAsString());

                    reader.ReadToFollowing("GenreId");
                    book.GenreId = int.Parse(reader.ReadElementContentAsString());

                    reader.ReadToFollowing("Deposit");
                    book.Deposit = decimal.Parse(reader.ReadElementContentAsString());

                    reader.ReadToFollowing("RentPrice");
                    book.RentPrice = decimal.Parse(reader.ReadElementContentAsString());

                    books.Add(book);
                }
            }
            return books;
        }
        public IEnumerable<Genre> ReadGenre(string filename)
        {
            var genres = new List<Genre>();
            using (XmlReader reader = XmlReader.Create(filename))
            {
                while (reader.ReadToFollowing("Genre"))
                {
                    reader.ReadToFollowing("Id");
                    var genre = new Genre { Id = int.Parse(reader.ReadElementContentAsString()) };

                    reader.ReadToFollowing("Name");
                    genre.Name = reader.ReadElementContentAsString();

                    genres.Add(genre);
                }
            }
            return genres;
        }
        public IEnumerable<Reader> ReadReader(string filename)
        {
            var users = new List<Reader>();
            using (XmlReader reader = XmlReader.Create(filename))
            {
                while (reader.ReadToFollowing("Reader"))
                {
                    reader.ReadToFollowing("Id");
                    var user = new Reader { Id = int.Parse(reader.ReadElementContentAsString()) };

                    reader.ReadToFollowing("LastName");
                    user.LastName = reader.ReadElementContentAsString();

                    reader.ReadToFollowing("Name");
                    user.Name = reader.ReadElementContentAsString();
                    
                    reader.ReadToFollowing("Patronymic");
                    user.Patronymic = reader.ReadElementContentAsString();

                    reader.ReadToFollowing("Address");
                    user.Address = reader.ReadElementContentAsString();

                    reader.ReadToFollowing("PhoneNumber");
                    user.PhoneNumber = reader.ReadElementContentAsString();

                    reader.ReadToFollowing("Category");
                    user.Category = (Category)Enum.Parse(typeof(Category), reader.ReadElementContentAsString());

                    users.Add(user);
                }
            }
            return users;
        }

        public IEnumerable<RentedBook> ReadRentedBooks(string filename)
        {
            var rentedBooks = new List<RentedBook>();
            using (XmlReader reader = XmlReader.Create(filename))
            {
                while (reader.ReadToFollowing("RentedBook"))
                {
                    reader.ReadToFollowing("ReaderId");
                    var rentedBook = new RentedBook{ ReaderId = int.Parse(reader.ReadElementContentAsString()) };

                    reader.ReadToFollowing("BookId");
                    rentedBook.BookId = int.Parse(reader.ReadElementContentAsString());

                    reader.ReadToFollowing("IssueDate");
                    rentedBook.IssueDate = DateTime.Parse(reader.ReadElementContentAsString());

                    reader.ReadToFollowing("ReturnDate");
                    rentedBook.ReturnDate = DateTime.Parse(reader.ReadElementContentAsString());

                    rentedBooks.Add(rentedBook);
                } ;
            }
            return rentedBooks;
        }
    }
}
