using System;
using net_laba2.Models;

namespace net_laba2.Queries.ViewModels
{
    internal class ReaderBookInfoViewModel
    {
        public Reader Reader { get; set; }
        public Book Book { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
