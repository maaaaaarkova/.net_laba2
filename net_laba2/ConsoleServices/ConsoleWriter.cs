using System;
using System.Collections.Generic;
using net_laba2.Models;
using net_laba2.Queries.ViewModels;

namespace net_laba2.ConsoleServices
{
    internal class ConsoleWriter
    {
        public void GetReadersInfo(IEnumerable<Reader> list)
        {
            foreach (var readerInfo in list)
            {
                Console.WriteLine(readerInfo.LastName);
                Console.WriteLine(readerInfo.Name);
                Console.WriteLine(readerInfo.Patronymic);
                Console.WriteLine(readerInfo.PhoneNumber);
                Console.WriteLine(readerInfo.Address);
                Console.WriteLine("\n");
            }
        }

        public void GetBooksInfo(IEnumerable<BooksInfoViewModel> list)
        {
            foreach (var bookInfo in list)
            {
                Console.WriteLine(bookInfo.Book.Name);
                Console.WriteLine(bookInfo.Author.Name);
                Console.WriteLine(bookInfo.Genre.Name);
                Console.WriteLine(bookInfo.Book.Deposit);
                Console.WriteLine(bookInfo.Book.RentPrice);
                Console.WriteLine("\n");
            }
        }

        public void GetSortedAuthors(IEnumerable<Author> list)
        {
            foreach (var authorInfo in list)
            {
                Console.WriteLine(authorInfo.Name);
                Console.WriteLine("\n");
            }
        }

        public void GetBooksPriceOver40(IEnumerable<BooksInfoViewModel> list)
        {
            foreach (var bookPriceOver in list)
            {
                Console.WriteLine(bookPriceOver.Book.Name);
                Console.WriteLine(bookPriceOver.Author.Name);
                Console.WriteLine(bookPriceOver.Genre.Name);
                Console.WriteLine(bookPriceOver.Book.Deposit);
                Console.WriteLine("\n");
            }
        }

        public void GetReadersNameStartsWithO(IEnumerable<Reader> list)
        {
            foreach (var nameStartsWithO in list)
            {
                Console.WriteLine(nameStartsWithO.LastName);
                Console.WriteLine(nameStartsWithO.Name);
                Console.WriteLine(nameStartsWithO.Patronymic);
                Console.WriteLine(nameStartsWithO.PhoneNumber);
                Console.WriteLine(nameStartsWithO.Address);
                Console.WriteLine("\n");
            }
        }

        public void GetStephenKingBooks(IEnumerable<AuthorBookViewModel> list)
        {
            foreach (var kingsBooks in list)
            {
                Console.WriteLine(kingsBooks.Book.Name);
                Console.WriteLine(kingsBooks.Author.Name);
                Console.WriteLine("\n");
            }
        }

        public void GetSortedCollegeStudents(IEnumerable<Reader> list)
        {
            foreach (var sortedCollegeStudent in list)
            {
                Console.WriteLine(sortedCollegeStudent.LastName);
                Console.WriteLine(sortedCollegeStudent.Name);
                Console.WriteLine(sortedCollegeStudent.Patronymic);
                Console.WriteLine(sortedCollegeStudent.PhoneNumber);
                Console.WriteLine(sortedCollegeStudent.Address);
                Console.WriteLine(sortedCollegeStudent.Category);
                Console.WriteLine("\n");
            }
        }

        public void GetReadersRentedBooks(IEnumerable<ReaderBookViewModel> list)
        {
            foreach (var readersBooks in list)
            {
                Console.WriteLine(readersBooks.Reader.LastName);
                Console.WriteLine(readersBooks.Reader.Name);
                Console.WriteLine(readersBooks.Reader.Patronymic);
                Console.WriteLine(readersBooks.Book.Name);
                Console.WriteLine("\n");
            }
        }

        public void GetGenresGroupBooks(IEnumerable<GenreBookViewModel> list)
        {
            foreach (var genresBooks in list)
            {

                Console.WriteLine(genresBooks.Book.Name);
                Console.WriteLine(genresBooks.Genre.Name);
                Console.WriteLine("\n");
            }
        }

        public void GetReadersRentedTime(IEnumerable<ReaderBookInfoViewModel> list)
        {

            foreach (var readersTime in list)
            {
                Console.WriteLine(readersTime.Reader.LastName);
                Console.WriteLine(readersTime.Reader.Name);
                Console.WriteLine(readersTime.Reader.Patronymic);
                Console.WriteLine(readersTime.Book.Name);
                TimeSpan rent = readersTime.ReturnDate.Subtract(readersTime.IssueDate);
                Console.WriteLine(String.Format("{0:dd}", rent));
                Console.WriteLine("\n");
            }
        }

        public void GetHorrorandDetectiveBooks(IEnumerable<GenreBookViewModel> list)
        {
            foreach (var HorrorandDetectiveBooks in list)
            {
                Console.WriteLine(HorrorandDetectiveBooks.Book.Name);
                Console.WriteLine(HorrorandDetectiveBooks.Genre.Name);
                Console.WriteLine("\n");
            }
        }

        public void GetBooksAuthorWithS(IEnumerable<AuthorBookViewModel> list)
        {
            foreach (var booksAuthorWithS in list)
            {
                Console.WriteLine(booksAuthorWithS.Book.Name);
                Console.WriteLine(booksAuthorWithS.Author.Name);
                Console.WriteLine("\n");
            }
        }

        public void GetKingsBookPriceLower45(IEnumerable<AuthorBookViewModel> list)
        {
            foreach (var kingsBookPriceLower in list)
            {
                Console.WriteLine(kingsBookPriceLower.Book.Name);
                Console.WriteLine(kingsBookPriceLower.Author.Name);
                Console.WriteLine(kingsBookPriceLower.Book.Deposit);
                Console.WriteLine("\n");
            }
        }

        public void GetBookPriceForWeek(IEnumerable<Book> list)
        {
            foreach (var priceForWeek in list)
            {
                Console.WriteLine(priceForWeek.Name);
                Console.WriteLine(priceForWeek.RentPrice);
                Console.WriteLine(priceForWeek.RentPrice * 7);
                Console.WriteLine("\n");
            }
        }

        public void GetAllAuthors(IEnumerable<Author> list)
        {
            foreach (var author in list)
            {
                Console.WriteLine(author.Name);
                Console.WriteLine("\n");
            }
        }

        public void GetBooksByGenre(Dictionary<string, IEnumerable<Book>> list)
        {
            foreach (var bookByGenre in list)
            {
                Console.WriteLine(bookByGenre.Key);
                foreach (var book in bookByGenre.Value)
                {
                    Console.WriteLine(book.Name);
                }
                Console.WriteLine("\n");
            }
        }

        public void GetBooksByAuthor(Dictionary<string, IEnumerable<Book>> list)
        {
            foreach (var bookByAuthor in list)
            {
                Console.WriteLine(bookByAuthor.Key);
                foreach (var book in bookByAuthor.Value)
                {
                    Console.WriteLine(book.Name);
                }
                Console.WriteLine("\n");
            }
        }
    }
}
