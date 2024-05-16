using EFCoreConsoleApp.Data;
using EFCoreConsoleApp.Models;
using EFCoreConsoleApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreConsoleApp.TestDriven
{
    public class TestBilling
    {
        private readonly BillingContext _context;
        public TestBilling(BillingContext cx) {
            _context = cx;
        }

        public void SaveTheBilling()
        {
            BillingTransactionRepository billingTransactionRepository = new BillingTransactionRepository(_context);
            billingTransactionRepository.AddBillingTransaction(new BillingTransaction
            {
                year=2024,
                month=5,
                day=16,
                transactionId = "123456A",
                userToken = "userToken",
                doctorToken = "doctor",
                customerToken = "customer",
                partnerToken = "partner",
                successClassificationAPICount = 1

            });

        }


    }
}
