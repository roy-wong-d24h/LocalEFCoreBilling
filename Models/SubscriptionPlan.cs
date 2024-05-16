using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreConsoleApp.Models
{
    public class SubscriptionPlan
    {
        [Key]
        public int id { get; set; }
        [StringLength(90)]
        public string subscriptionPlanId { get; set; } = null!;
        [StringLength(90)]
        public string tierName { get; set; } = null!;
        [Column(TypeName = "decimal(18, 2)")]
        public decimal billingPricingPerMonth { get; set; }
        public int maxTransactionsPerMonth { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal thereafterAmount { get; set; }
        [StringLength(255)]
        public string? createdBy { get; set; }
        public DateTime createdAt { get; set; }
        [StringLength(255)]
        public string? updatedBy { get; set; }
        public DateTime updatedAt { get; set; }
    }
}
