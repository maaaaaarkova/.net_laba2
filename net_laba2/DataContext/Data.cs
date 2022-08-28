using System.Xml.Linq;
using net_laba2.Constants;

namespace net_laba2.DataContext
{
    internal class Data
    {
        public XDocument Authors { get; set; }
        public XDocument Books { get; set; }
        public XDocument Genres { get; set; }
        public XDocument Readers { get; set; }
        public XDocument RentedBooks { get; set; }
        public XDocument UkrainianAuthors { get; set; }

        public Data()
        {
            Authors = XDocument.Load(FilenameConstants.AuthorsFile);
            Books = XDocument.Load(FilenameConstants.BooksFile);
            Genres = XDocument.Load(FilenameConstants.GenresFile);
            Readers = XDocument.Load(FilenameConstants.ReadersFile);
            RentedBooks = XDocument.Load(FilenameConstants.RentedBooksFile);
            UkrainianAuthors = XDocument.Load(FilenameConstants.UkrainianAuthorsFile);
        }
    }
}
