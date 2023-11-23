namespace InsuranceDay1.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public bool IsActive { get; set; }
        public List<Customer>? Customers { get; set;}
    }
}
