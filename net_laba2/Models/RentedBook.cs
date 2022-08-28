using System;

namespace net_laba2.Models
{
    public class RentedBook
    {
        public int ReaderId { get; set; }
        public int BookId { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public override string ToString()
        {
            return $"\nReader Id: {ReaderId} - Book Id: {BookId} - Issue Date: {IssueDate:d} - Return Date: {ReturnDate:d}";
        }
    }
}
