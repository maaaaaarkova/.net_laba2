using System;
using System.Xml.Linq;
using net_laba2.Enums;
using net_laba2.Models;

namespace net_laba2.XmlServices
{
    internal static class XmlExtensions
    {
        public static Author ToAuthor(this XElement element)
        {
            return new Author()
            {
                Id = Convert.ToInt32(element.Element("Id")?.Value),
                Name = element.Element("Name")?.Value,
            };
        }
        public static Book ToBook(this XElement element)
        {
            return new Book()
            {
                Id = Convert.ToInt32(element.Element("Id")?.Value),
                Name = element.Element("Name")?.Value,
                AuthorId = Convert.ToInt32(element.Element("AuthorId")?.Value),
                GenreId = Convert.ToInt32(element.Element("GenreId")?.Value),
                Deposit = decimal.Parse(element.Element("Deposit")?.Value),
                RentPrice = decimal.Parse(element.Element("RentPrice")?.Value),
            };
        }

        public static Genre ToGenre(this XElement element)
        {
            return new Genre()
            {
                Id = Convert.ToInt32(element.Element("Id")?.Value),
                Name = element.Element("Name")?.Value,
            };
        }

        public static Reader ToReader(this XElement element)
        {
            return new Reader()
            {
                Id = int.Parse(element.Element("Id")?.Value),
                LastName = element.Element("LastName")?.Value,
                Name = element.Element("Name")?.Value,
                Patronymic = element.Element("Patronymic")?.Value,
                Address = element.Element("Address")?.Value,
                PhoneNumber = element.Element("PhoneNumber")?.Value,
                Category = (Category) Enum.Parse(typeof(Category), element.Element("Category")?.Value),
            };
        }

        public static RentedBook ToRentedBook(this XElement element)
        {
            return new RentedBook()
            {
                ReaderId = Convert.ToInt32(element.Element("ReaderId")?.Value),
                BookId = Convert.ToInt32(element.Element("BookId")?.Value),
                IssueDate = Convert.ToDateTime(element.Element("IssueDate")?.Value),
                ReturnDate = Convert.ToDateTime(element.Element("ReturnDate")?.Value),
            };
        }
    }
}
