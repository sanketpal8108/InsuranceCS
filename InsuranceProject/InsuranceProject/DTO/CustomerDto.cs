namespace InsuranceProject.DTO
{
    public class CustomerDto
    {
        public int Id { get; set; }

        public DateTime DateOfBirth { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public int MobileNumber { get; set; }
        public string Email { get; set; }
        public string NomineeName { get; set; }
        public string NomineeRelation { get; set; }
        public int LocationId { get; set; }
        public int AgentId { get; set; }

        //public int RoleId { get; set; }
    }
}
