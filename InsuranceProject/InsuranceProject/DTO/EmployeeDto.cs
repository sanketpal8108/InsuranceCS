namespace InsuranceProject.DTO
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; } //LoginID
        public string Password { get; set; }

        //public int RoleId { get; set; }
    }
}
