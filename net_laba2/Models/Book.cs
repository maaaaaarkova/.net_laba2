namespace net_laba2.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
        public decimal Deposit { get; set; }
        public decimal RentPrice { get; set; }
        public override string ToString()
        {
            return $"\nId: {Id} - Name: {Name} - Author Id: {AuthorId} - Genre Id: {GenreId}" +
                   $"\n\tDeposit: {Deposit} UAH - Rent price: {RentPrice} UAH";
        }
    }
}
