using System;
using System.Collections.Generic;
using System.Linq;
using net_laba2.DataContext;
using net_laba2.Enums;
using net_laba2.Models;
using net_laba2.Queries.ViewModels;
using net_laba2.XmlServices;

namespace net_laba2.Queries.Services
{
    internal class QueriesService
    {
        private readonly Data _data;

        public QueriesService(Data data)
        {
            _data = data;
        }

        public IEnumerable<Reader> ReadersInfo()
        {
            var readerInfo =
                from Reader in _data.Readers.Root.Elements()
                select Reader.ToReader();

            return readerInfo;
        }

        public IEnumerable<BooksInfoViewModel> BooksInfo()
        {
            var booksInfo =
                from Book in _data.Books.Root.Elements()
                join Author in _data.Authors.Root.Elements()
                    on (int) Book.Element("AuthorId")
                    equals (int) Author.Element("Id")
                join Genre in _data.Genres.Root.Elements()
                    on (int) Book.Element("GenreId")
                    equals (int) Genre.Element("Id")
                select new BooksInfoViewModel() { Book = Book.ToBook(), Author = Author.ToAuthor(), Genre = Genre.ToGenre() };

            return booksInfo;
        }

        public IEnumerable<Author> AuthorsSortedInfo()
        {
            var authorsSortedInfo =
                from Author in _data.Authors.Root.Elements()
                orderby Author.Element("Name").Value
                select Author.ToAuthor();

            return authorsSortedInfo;
        }

        public IEnumerable<BooksInfoViewModel> BooksPriceOver40()
        {
            var bookPriceOver =
                from Book in _data.Books.Root.Elements()
                join Author in _data.Authors.Root.Elements() 
                    on (int)Book.Element("AuthorId") 
                    equals (int)Author.Element("Id")
                join Genre in _data.Genres.Root.Elements() 
                    on (int)Book.Element("GenreId") 
                    equals (int)Genre.Element("Id")
                where (decimal)Book.Element("Deposit") >= 40
                select new BooksInfoViewModel() { Book = Book.ToBook(), Author = Author.ToAuthor(), Genre = Genre.ToGenre() };

            return bookPriceOver;

        }

        public IEnumerable<Reader> ReaderNameStartsWithOInfo()
        {
            var nameStartsWithO = _data.Readers.Root.Elements()
                .Where(i => i.Element("Name").Value.StartsWith("O"))
                .Select(x => x.ToReader());

            return nameStartsWithO;
        }

        public IEnumerable<AuthorBookViewModel> StephenKingBooks()
        {
            var kingsBooks =
                from Book in _data.Books.Root.Elements()
                join Author in _data.Authors.Root.Elements() 
                    on (int)Book.Element("AuthorId") 
                    equals (int)Author.Element("Id")
                where Author.Element("Name").Value.Equals("Stephen King", StringComparison.OrdinalIgnoreCase)
                select new AuthorBookViewModel() { Book = Book.ToBook(), Author = Author.ToAuthor() };

            return kingsBooks;
        }


        public IEnumerable<Reader> SortedCollegeStudents()
        {
            var sortedCollegeStudent = _data.Readers.Root.Elements()
                .Where(i => (Category)Enum.Parse(typeof(Category), i.Element("Category").Value) 
                            == Category.CollegeStudent)
                .OrderBy(i => i.Element("LastName").Value)
                .Select(x => x.ToReader());

            return sortedCollegeStudent;
        }

        public IEnumerable<ReaderBookViewModel> ReadersRentedBooks()
        {
            var readersBooks =
                from Reader in _data.Readers.Root.Elements()
                join RentedBook in _data.RentedBooks.Root.Elements() 
                    on (int)Reader.Element("Id") 
                    equals (int)RentedBook.Element("ReaderId")
                join Book in _data.Books.Root.Elements() 
                    on (int)RentedBook.Element("BookId") 
                    equals (int)Book.Element("Id")
                select new ReaderBookViewModel() { Reader = Reader.ToReader(), Book = Book.ToBook() };

            return readersBooks;
        }

        public IEnumerable<GenreBookViewModel> GenresGroupBooks()
        {
            var genresBooks =
                from Book in _data.Books.Root.Elements()
                join Genre in _data.Genres.Root.Elements()
                    on (int) Book.Element("GenreId")
                    equals (int) Genre.Element("Id")
                orderby Genre.Element("Name").Value
                select new GenreBookViewModel() { Genre = Genre.ToGenre(), Book = Book.ToBook() };

            return genresBooks;
        }

        public IEnumerable<ReaderBookInfoViewModel> ReadersRentedTime()
        {
            var readersTime =
                from Reader in _data.Readers.Root.Elements()
                join RentedBook in _data.RentedBooks.Root.Elements() 
                    on (int)Reader.Element("Id") 
                    equals (int)RentedBook.Element("ReaderId")
                join Book in _data.Books.Root.Elements() 
                    on (int)RentedBook.Element("BookId") 
                    equals (int)Book.Element("Id")
                orderby Convert.ToDateTime(RentedBook.Element("ReturnDate").Value)
                    .Subtract(Convert.ToDateTime(RentedBook.Element("IssueDate").Value))
                select new ReaderBookInfoViewModel()
                {
                    Reader = Reader.ToReader(),
                    Book = Book.ToBook(),
                    IssueDate = Convert.ToDateTime(RentedBook.Element("IssueDate").Value),
                    ReturnDate = Convert.ToDateTime(RentedBook.Element("ReturnDate").Value),
                };

            return readersTime;
        }

        public IEnumerable<GenreBookViewModel> HorrorAndDetectiveBooks()
        {
            var horrorAndDetective =
                from Book in _data.Books.Root.Elements()
                join Genre in _data.Genres.Root.Elements() 
                    on (int)Book.Element("GenreId") 
                    equals (int)Genre.Element("Id")
                where (Genre.Element("Name").Value.Equals("Horror", StringComparison.OrdinalIgnoreCase) ||
                       Genre.Element("Name").Value.Equals("Detective", StringComparison.OrdinalIgnoreCase))
                orderby Genre.Element("Name").Value
                select new GenreBookViewModel() { Book = Book.ToBook(), Genre = Genre.ToGenre() };

            return horrorAndDetective;
        }

        public IEnumerable<AuthorBookViewModel> BooksAuthorWithS()
        {
            var booksAuthorWithS =
                from Book in _data.Books.Root.Elements()
                join Author in _data.Authors.Root.Elements()
                    on (int) Book.Element("AuthorId")
                    equals (int)Author.Element("Id")
                where Author.Element("Name").Value.StartsWith("S")
                orderby Author.Element("Name").Value
                select new AuthorBookViewModel() { Book = Book.ToBook(), Author = Author.ToAuthor() };

            return booksAuthorWithS;
        }

        public IEnumerable<AuthorBookViewModel> KingsBookPriceLower45()
        {
            var kingsBookPriceLower = _data.Books.Root.Elements()
                .Join(_data.Authors.Root.Elements(),
                          Book => (int)Book.Element("AuthorId"),
                          Author => (int)Author.Element("Id"),
                          (Book, Author) => new { Book, Author })
                .Where(Book => Book.Author.Element("Name").Value
                    .Equals("Stephen King", StringComparison.OrdinalIgnoreCase) 
                               && (decimal)Book.Book.Element("Deposit") < 45)
                .Select(i => new AuthorBookViewModel() { Author = i.Author.ToAuthor(), Book = i.Book.ToBook() });

            return kingsBookPriceLower;
        }

        public IEnumerable<Book> BookPriceForWeek()
        {
            var priceForWeek =
                from Book in _data.Books.Root.Elements()
                orderby ((decimal)Book.Element("RentPrice") * 7)
                select Book.ToBook();

            return priceForWeek;
        }

        public int BooksPriceHigher40()
        {
            var booksPriceHigher40 =
                (from Book in _data.Books.Root.Elements()
                 join Author in _data.Authors.Root.Elements() 
                     on (int)Book.Element("AuthorId") 
                     equals (int)Author.Element("Id")
                 where !Author.Element("Name").Value.Equals("Stephen King", StringComparison.OrdinalIgnoreCase) 
                       && (decimal)Book.Element("Deposit") > 40
                 orderby (decimal)Book.Element("Deposit")
                 select new { Book, Author })
                .Count();

            return booksPriceHigher40;
        }

        public IEnumerable<Author> AllAuthors()
        {
            var all = _data.Authors.Root.Elements()
                .Concat(_data.UkrainianAuthors.Root.Elements())
                .Select(x => x.ToAuthor());

            return all;
        }

        public Dictionary<string, IEnumerable<Book>> BooksByGenre()
        {
            var booksGenres =
                from Book in _data.Books.Root.Elements()
                join Genre in _data.Genres.Root.Elements() 
                    on (int)Book.Element("GenreId") 
                    equals (int)Genre.Element("Id")
                group Book by Genre.Element("Name").Value into models
                select models;

            return booksGenres
                .ToDictionary(i => i.Key, 
                    j => j.Select(b => b.ToBook()));
        }

        public Dictionary<string, IEnumerable<Book>> BooksByAuthor()
        {
            var booksAuthor = _data.Books.Root.Elements()
                .Join(_data.Authors.Root.Elements(), 
                    i => (int)i.Element("AuthorId"), 
                    a => (int)a.Element("Id"), 
                    (Book, Author) => new { Book, Author })
                        .GroupBy(i => i.Author.Element("Name").Value);


            return booksAuthor
                .ToDictionary(i => i.Key, 
                    j => j.Select(a => a.Book.ToBook()));

        }
    }
}
