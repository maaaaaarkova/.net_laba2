using net_laba2.ConsoleServices;
using net_laba2.DataContext;
using net_laba2.Queries.Services;
using net_laba2.XmlServices;

namespace net_laba2
{
    class Program
    {
        static void Main()
        {
            var consoleReader = new ConsoleReader();
            var xmlReader = new XmlReaderService();
            var xmlWriter = new XmlWriterService();
            var consoleWriter = new ConsoleWriter();
            var data = new Data();
            var queryService = new QueriesService(data);

            var menu = new Menu(xmlReader, consoleReader, xmlWriter, consoleWriter, queryService);

            menu.Display();
        }
    }
}
