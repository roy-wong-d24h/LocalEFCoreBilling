using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreConsoleApp.Models
{
    public class BillingTransaction
    {
        [Key]
        public int id { get; set; }
        public int year { get; set; }
        public int month { get; set; }
        public int day { get; set; }
        [StringLength(255)]
        public string transactionId { get; set; } = null!;

        //userToken is the patient token.
        [StringLength(36)]
        public string userToken { get; set; } = null!;
        [StringLength(36)]
        public string doctorToken { get; set; } = null!;
        [StringLength(36)]
        public string customerToken { get; set; } = null!;
        [StringLength(36)]
        public string partnerToken { get; set; } = null!;
        public int successClassificationAPICount { get; set; }
        public int failureClassificationAPICount { get; set; }
        public int successBPMAPICount { get; set; }
        public int failureBPMAPICount { get; set; }
        public int failureRecognitionAPICount { get; set; }
        public int billingTimestamp { get; set; }
    }
}
