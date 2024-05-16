using EFCoreConsoleApp.Data;
using EFCoreConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreConsoleApp.Repository
{
    public class MonthlyBillingRepository
    {
        private readonly BillingContext _context;

        public MonthlyBillingRepository(BillingContext context)
        {
            _context = context;
        }

        public MonthlyBilling? GetMonthlyBillingById(int id)
        {
            return _context.MonthlyBillings.Find(id);
        }

        public MonthlyBilling? GetMonthlyBillingByYearMonthAndPartnerToken(int year, int month, string partnerToken)
        {
            return _context.MonthlyBillings.Where(x => x.year == year && x.month == month && x.partnerToken.Equals(partnerToken)).FirstOrDefault();
        }

        public void UpsertMonthlyBilling(MonthlyBilling monthlyBilling)
        {
            MonthlyBilling? existingMonthlyBilling = GetMonthlyBillingByYearMonthAndPartnerToken(monthlyBilling.year, monthlyBilling.month, monthlyBilling.partnerToken);
            if (existingMonthlyBilling == null)
            {
                _context.MonthlyBillings.Add(monthlyBilling);
            }
            else
            {
                existingMonthlyBilling.successCount = monthlyBilling.successCount;
                existingMonthlyBilling.failureCount = monthlyBilling.failureCount;
                existingMonthlyBilling.thereafter = monthlyBilling.thereafter;
                _context.MonthlyBillings.Update(existingMonthlyBilling);
            }
        }
    }
}
