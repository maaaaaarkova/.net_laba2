namespace net_laba2.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return $"\nId: {Id} - Name: {Name}";
        }
    }
}
