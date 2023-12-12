namespace InsuranceProject.DTO
{
    public class DocumentsDto
    {
        public int Id { get; set; }
        public string DocumentType { get; set; }
        public string DocumentName { get; set; }

        public byte[]? ViewDocument {  get; set; }
        public bool? IsApproved { get; set; }
        public IFormFile? File { get; set; }
        //public string DocumentInformation { get; set; }
        public int CustomerId { get; set; }
    }
}
