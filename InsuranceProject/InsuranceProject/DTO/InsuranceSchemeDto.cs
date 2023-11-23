namespace InsuranceProject.DTO
{
    public class InsuranceSchemeDto
    {
        public int Id { get; set; }
        public string InsuranceSchemeName { get; set; }
        
        public double NewRegistrastionCommision { get; set; }
        public double InstallmentPaymentCommision { get; set; }
        //public byte[]? InsuranceSchemeImage { get; set; }
        public string Details { get; set; }
        public int InsuranceTypeId { get; set; }

    }
}
