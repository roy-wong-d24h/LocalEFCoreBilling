using EFCoreConsoleApp.Data;
using EFCoreConsoleApp.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreConsoleApp.Repository
{
    public class BillingTransactionRepository
    {
        private readonly BillingContext _context;
        private readonly int threshold = 5;

        public BillingTransactionRepository(BillingContext context)
        {
            _context = context;
        }

        public BillingTransaction? GetBillingTransactionById(int id)
        {
            return _context.BillTransactions.Find(id);
        }

        public List<BillingTransaction> GetBillingTransactionsByTransactionId(string transactionId)
        {
            List<BillingTransaction> billingTransactions = [];
            billingTransactions = [.. _context.BillTransactions.Where(x => x.transactionId.Equals(transactionId))];
            return billingTransactions;
        }

        public List<BillingTransaction> GetBillingTransactionsByPartnerTokenWithYearMonth(string partnerToken, int year, int month)
        {
            List<BillingTransaction> billingTransactions = [];
            billingTransactions = [.. _context.BillTransactions.Where(x => x.partnerToken.Equals(partnerToken) && x.year == year && x.month == month)];
            return billingTransactions;
        }

        public List<BillingTransaction> GetBillingTransactionsByYearAndMonth(int year, int month)
        {
            List<BillingTransaction> billingTransactions = [];
            billingTransactions = [.. _context.BillTransactions.Where(x => x.year == year && x.month == month)];
            return billingTransactions;
        }

        public List<BillingTransaction> GetBillingTransactionsByPartnerTokenWithDatetimeRange(string partnerToken, int start_year, int start_month, int start_day, int end_year, int end_month, int end_day)
        {
            List<BillingTransaction> billingTransactions = [];
            billingTransactions = [.. _context.BillTransactions.Where(x => x.partnerToken.Equals(partnerToken) && x.year >= start_year && x.month >= start_month && x.day >= start_day && x.year <= end_year && x.month <= end_month && x.day <= end_day)];
            return billingTransactions;
        }

        public List<BillingTransaction> GetBillingTransactionsByDatetimeRange(int year, int month)
        {
            List<BillingTransaction> billingTransactions = [];
            billingTransactions = [.. _context.BillTransactions.Where(x => x.year == year && x.month == month)];
            return billingTransactions;
        }

        public void AddBillingTransaction(BillingTransaction billingTransaction)
        {
            _context.BillTransactions.Add(billingTransaction);
        }

        public int GetCustomerUsageByYearMonth(int year, int month, string customerToken)
        {
            //int usage = 0;
            //int normal_usage = 0;
            //int failed_usage = 0;
            //List<BillingTransaction> billingTransactions = [];
            //billingTransactions = [.. _context.BillTransactions.Where(x => x.customerToken.Equals(customerToken) && x.year == year && x.month == month)];
            //foreach (BillingTransaction billingTransaction in billingTransactions)
            //{
            //    normal_usage += billingTransaction.successClassificationAPICount + billingTransaction.successBPMAPICount;
            //    failed_usage += billingTransaction.failureClassificationAPICount + billingTransaction.failureBPMAPICount + billingTransaction.failureRecognitionAPICount;
            //}

            //usage = normal_usage + (failed_usage / threshold);


            var usageData = _context.BillTransactions
                .Where(x => x.customerToken.Equals(customerToken) && x.year == year && x.month == month)
                .Select(x => new
                {
                    NormalUsage = x.successClassificationAPICount + x.successBPMAPICount,
                    FailedUsage = x.failureClassificationAPICount + x.failureBPMAPICount + x.failureRecognitionAPICount
                })
                .ToList();

            int normal_usage = usageData.Sum(x => x.NormalUsage);
            int failed_usage = usageData.Sum(x => x.FailedUsage);

            int usage = normal_usage + (failed_usage / threshold);


            return usage;
        }


    }
}
