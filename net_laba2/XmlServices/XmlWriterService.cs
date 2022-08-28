using System;
using System.IO;
using System.Xml;
using net_laba2.Models;

namespace net_laba2.XmlServices
{
    internal class XmlWriterService
    {
        private readonly string _directoryPath = Environment.CurrentDirectory;
        private readonly XmlWriterSettings _settings = new XmlWriterSettings {Indent = true};

        public void WriteAuthor(string filename, Author author)
        {
            using (var writer = XmlWriter.Create($"{_directoryPath}/{filename}", _settings))
            {
                writer.WriteStartElement("Authors");
                writer.WriteStartElement("Author");

                var properties = author.GetType().GetProperties();

                foreach (var property in properties)
                {
                    writer.WriteElementString(property.Name, property.GetValue(author)!.ToString());
                }

                writer.WriteEndElement();
                writer.WriteEndElement();
            }
        }

        public void WriteBook(string filename, Book book)
        {
            using (var writer = XmlWriter.Create($"{_directoryPath}/{filename}", _settings))
            {
                writer.WriteStartElement("Books");
                writer.WriteStartElement("Book");

                var properties = book.GetType().GetProperties();

                foreach (var property in properties)
                {
                    writer.WriteElementString(property.Name, property.GetValue(book)!.ToString());
                }

                writer.WriteEndElement();
                writer.WriteEndElement();
            }
        }

        public void WriteGenre(string filename, Genre genre)
        {
            using (var writer = XmlWriter.Create($"{_directoryPath}/{filename}", _settings))
            {
                writer.WriteStartElement("Genres");
                writer.WriteStartElement("Genre");

                var properties = genre.GetType().GetProperties();

                foreach (var property in properties)
                {
                    writer.WriteElementString(property.Name, property.GetValue(genre)!.ToString());
                }

                writer.WriteEndElement();
                writer.WriteEndElement();
            }
        }

        public void WriteReader(string filename, Reader reader)
        {
            using (var writer = XmlWriter.Create($"{_directoryPath}/{filename}", _settings))
            {
                writer.WriteStartElement("Reader");
                writer.WriteStartElement("Readers");

                var properties = reader.GetType().GetProperties();

                foreach (var property in properties)
                {
                    writer.WriteElementString(property.Name, property.GetValue(reader)!.ToString());
                }

                writer.WriteEndElement();
                writer.WriteEndElement();
            }
        }

        public void WriteRentedBook(string filename, RentedBook rentedBook)
        {
            using (var writer = XmlWriter.Create($"{_directoryPath}/{filename}", _settings))
            {
                writer.WriteStartElement("RentedBooks");
                writer.WriteStartElement("RentedBook");

                var properties = rentedBook.GetType().GetProperties();

                foreach (var property in properties)
                {
                    writer.WriteElementString(property.Name, 
                        property.GetValue(rentedBook) is DateTime 
                            ? $"{property.GetValue(rentedBook):dd.MM.yyyy}"
                            : property.GetValue(rentedBook)!.ToString());
                }

                writer.WriteEndElement();
                writer.WriteEndElement();
            }
        }
    }
}
