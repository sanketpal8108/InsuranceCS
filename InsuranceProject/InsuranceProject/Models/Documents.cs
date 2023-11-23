﻿using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceDay1.Models
{
    public class Documents
    {
        public int Id { get; set; }
        public string DocumentType { get; set; } 
        //Document Upload Attribute
        //public string DocumentInformation { get; set; } //If upload option is not available
        public byte[] DocumentData { get; set; }
        public Customer? Customer { get; set; }
        [ForeignKey("Customer")]

        public int CustomerId { get; set; }

        public bool IsActive { get; set; }
    }
}
