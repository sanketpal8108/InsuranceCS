namespace InsuranceProject.DTO
{
    public class AgentDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int MobileNumber { get; set; }
        public string Email { get; set; }
        public double Commision { get; set; } = 0;
        public double TotalCommision { get; set; }

        public int CountCustomer { get; set; } = 0;

        public int CountCommision { get; set; } = 0;
        //public int RoleId { get; set; }


    }
}
