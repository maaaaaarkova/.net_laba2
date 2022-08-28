using net_laba2.Enums;

namespace net_laba2.Models
{
    public class Reader
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public Category Category { get; set; }
        public override string ToString()
        {
            return $"\nId: {Id} - Lastname: {LastName} - Name: {Name} - Patronymic: {Patronymic}" +
                   $"\n\tAddress: {Address} - Phone number: {PhoneNumber} - Category: {Category}";
        }
    }
}
