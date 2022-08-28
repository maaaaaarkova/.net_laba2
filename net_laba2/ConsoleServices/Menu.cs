using System;
using net_laba2.Constants;
using net_laba2.Queries.Services;
using net_laba2.XmlServices;

namespace net_laba2.ConsoleServices
{
    internal class Menu
    {
        private readonly XmlReaderService _readerService;
        private readonly ConsoleReader _consoleReader;
        private readonly XmlWriterService _writerService;
        private readonly ConsoleWriter _consoleWriter;
        private readonly QueriesService _queriesService;
        public Menu(XmlReaderService readerService, 
            ConsoleReader consoleReader, 
            XmlWriterService writerService,
            ConsoleWriter consoleWriter,
            QueriesService queriesService)
        {
            _readerService = readerService;
            _consoleReader = consoleReader; 
            _writerService = writerService;
            _queriesService = queriesService;
            _consoleWriter = consoleWriter;
        }

        public void Display()
        {
            while (true)
            {
                Console.WriteLine("1. Read from file");
                Console.WriteLine("2. Write into file");
                Console.WriteLine("3. Run queries");
                Console.WriteLine("\n0. Exit\n");
                var key = Console.ReadKey().KeyChar;
                switch (key)
                {
                    case '1':
                        DisplayRead();
                        break;
                    case '2':
                        DisplayWrite();
                        break;
                    case '3':
                        RunQueries();
                        break;
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid key");
                        Console.ReadKey();
                        break;
                }
                Console.Clear();
            }
        }

        private void DisplayRead()
        {
            Console.Clear();
            Console.WriteLine("1. Authors");
            Console.WriteLine("2. Books");
            Console.WriteLine("3. Genres");
            Console.WriteLine("4. Readers");
            Console.WriteLine("5. Rented books");
            Console.WriteLine("\n0. Go back\n");
            var key = Console.ReadKey().KeyChar;
            switch (key)
            {
                case '1':
                    var authors = _readerService.ReadAuthor(FilenameConstants.AuthorsFile);
                    foreach (var author in authors)
                    {
                        Console.WriteLine(author);
                    }
                    break;
                case '2':
                    var books = _readerService.ReadBook(FilenameConstants.BooksFile);
                    foreach (var book in books)
                    {
                        Console.WriteLine(book);
                    }
                    break;
                case '3':
                    var genres = _readerService.ReadGenre(FilenameConstants.GenresFile);
                    foreach (var genre in genres)
                    {
                        Console.WriteLine(genre);
                    }
                    break;
                case '4':
                    var readers = _readerService.ReadReader(FilenameConstants.ReadersFile);
                    foreach (var reader in readers)
                    {
                        Console.WriteLine(reader);
                    }
                    break;
                case '5':
                    var rentedBooks = _readerService.ReadRentedBooks(FilenameConstants.RentedBooksFile);
                    foreach (var rented in rentedBooks)
                    {
                        Console.WriteLine(rented);
                    }
                    break;
                case '0':
                    return;
                default:
                    Console.WriteLine("\nInvalid key");
                    break;
            }
            Console.ReadKey();
        }

        private void DisplayWrite()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("1. Authors");
                Console.WriteLine("2. Books");
                Console.WriteLine("3. Genres");
                Console.WriteLine("4. Readers");
                Console.WriteLine("5. Rented books");
                Console.WriteLine("\n0. Go back\n");
                var key = Console.ReadKey().KeyChar;
                Console.WriteLine();
                switch (key)
                {
                    case '1':
                        var author = _consoleReader.ReadAuthor();
                        _writerService.WriteAuthor(FilenameConstants.AuthorsFile, author);
                        break;
                    case '2':
                        var book = _consoleReader.ReadBook();
                        _writerService.WriteBook(FilenameConstants.BooksFile, book);
                        break;
                    case '3':
                        var genre = _consoleReader.ReadGenre();
                        _writerService.WriteGenre(FilenameConstants.GenresFile, genre);
                        break;
                    case '4':
                        var reader = _consoleReader.ReadReader();
                        _writerService.WriteReader(FilenameConstants.ReadersFile, reader);
                        break;
                    case '5':
                        var rentedBook = _consoleReader.ReadRentedBook();
                        _writerService.WriteRentedBook(FilenameConstants.RentedBooksFile, rentedBook);
                        break;
                    case '0':
                        return;
                    default:
                        Console.WriteLine("\nInvalid key");
                        break;
                }
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.ReadKey();
            }
            
        }

        private void RunQueries()
        {
            Console.WriteLine();

            var readerInfo = _queriesService.ReadersInfo();
            _consoleWriter.GetReadersInfo(readerInfo);

            Console.WriteLine(new string('_', 60));

            var bookInfo = _queriesService.BooksInfo();
            _consoleWriter.GetBooksInfo(bookInfo);

            Console.WriteLine(new string('_', 60));

            var authorSorted = _queriesService.AuthorsSortedInfo();
            _consoleWriter.GetSortedAuthors(authorSorted);

            Console.WriteLine(new string('_', 60));

            var priceOver40 = _queriesService.BooksPriceOver40();
            _consoleWriter.GetBooksPriceOver40(priceOver40);

            Console.WriteLine(new string('_', 60));

            var nameStartsWithO = _queriesService.ReaderNameStartsWithOInfo();
            _consoleWriter.GetReadersNameStartsWithO(nameStartsWithO);

            Console.WriteLine(new string('_', 60));

            var stephensBooks = _queriesService.StephenKingBooks();
            _consoleWriter.GetStephenKingBooks(stephensBooks);

            Console.WriteLine(new string('_', 60));

            var sortedCollege = _queriesService.SortedCollegeStudents();
            _consoleWriter.GetSortedCollegeStudents(sortedCollege);

            Console.WriteLine(new string('_', 60));

            var readersRentedBooks = _queriesService.ReadersRentedBooks();
            _consoleWriter.GetReadersRentedBooks(readersRentedBooks);

            Console.WriteLine(new string('_', 60));

            var genresBooks = _queriesService.GenresGroupBooks();
            _consoleWriter.GetGenresGroupBooks(genresBooks);

            Console.WriteLine(new string('_', 60));

            var rentTime = _queriesService.ReadersRentedTime();
            _consoleWriter.GetReadersRentedTime(rentTime);

            Console.WriteLine(new string('_', 60));

            var horrorAndDetective = _queriesService.HorrorAndDetectiveBooks();
            _consoleWriter.GetHorrorandDetectiveBooks(horrorAndDetective);

            Console.WriteLine(new string('_', 60));

            var booksAuthorWithS = _queriesService.BooksAuthorWithS();
            _consoleWriter.GetBooksAuthorWithS(booksAuthorWithS);

            Console.WriteLine(new string('_', 60));

            var kingsBookPrice = _queriesService.KingsBookPriceLower45();
            _consoleWriter.GetKingsBookPriceLower45(kingsBookPrice);

            Console.WriteLine(new string('_', 60));

            var weekPrice = _queriesService.BookPriceForWeek();
            _consoleWriter.GetBookPriceForWeek(weekPrice);

            Console.WriteLine(new string('_', 60));

            var booksPriceHigher40 = _queriesService.BooksPriceHigher40();
            Console.WriteLine(booksPriceHigher40);

            Console.WriteLine(new string('_', 60));

            var allAuthors = _queriesService.AllAuthors();
            _consoleWriter.GetAllAuthors(allAuthors);

            Console.WriteLine(new string('_', 60));

            var booksByGenre = _queriesService.BooksByGenre();
            _consoleWriter.GetBooksByGenre(booksByGenre);

            Console.WriteLine(new string('_', 60));

            var booksByAuthor = _queriesService.BooksByAuthor();
            _consoleWriter.GetBooksByAuthor(booksByAuthor);

            Console.ReadKey();
        }
    }
}
