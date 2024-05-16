using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreConsoleApp.Models
{
    public class MonthlyBilling
    {
        [Key]
        public int id { get; set; }
        public int year { get; set; }
        public int month { get; set; }
        //Not nullable
        [StringLength(36)]
        public string partnerToken { get; set; } = null!;
        //Not nullable
        [StringLength(90)]
        public string subscriptionPlanId { get; set; } = null!;

        [Column(TypeName = "decimal(18, 2)")]
        public decimal thereafter { get; set; }
        public int successCount { get; set; }
        public int failureCount { get; set; }
    }
}
