namespace InsuranceProject.DTO
{
    public class DocumentsDto
    {
        public int Id { get; set; }
        public string DocumentType { get; set; }

        public byte[] DocumentData { get; set; }
        //public string DocumentInformation { get; set; }
        public int CustomerId { get; set; }
    }
}
