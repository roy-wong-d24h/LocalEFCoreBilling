using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreConsoleApp.Models
{
    public class Contract
    {
        [Key]
        public int id { get; set; }
        //The company is the distributor or Channel Partner.
        [StringLength(36)]
        public string partnerToken { get; set; } = null!;
        [StringLength(90)]
        public string subscriptionPlanId { get; set; } = null!;
        public DateTime contractStartDate { get; set; }
        public DateTime contractEndDate { get; set; }
        [StringLength(255)]
        public string? createdBy { get; set; }
        public DateTime createdAt { get; set; }
        [StringLength(255)]
        public string? updatedBy { get; set; }
        public DateTime updatedAt { get; set; }

        //Downpayment
        //Each contract has a downpayment
        [Column(TypeName = "decimal(18, 2)")]
        public decimal downpayment { get; set; }
        public DateTime downpaymentDueDate { get; set; }
        public string contractStatus { get; set; } = null!;

    }
}
