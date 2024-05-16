//how to change the using statement.
using EFCoreConsoleApp.Data;
using EFCoreConsoleApp.Repository;
using EFCoreConsoleApp.TestDriven;
using Microsoft.EntityFrameworkCore;

namespace EFCoreConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start ...");

            using (var context = new BillingContext())
            {
                //Create the database if it doesn't exist
                context.Database.EnsureCreated();

                var testBilling = new TestBilling(context);

                //Add a new BillingTransaction
                testBilling.SaveTheBilling();

                //Save the BillingTransaction
                context.SaveChanges();

                Console.WriteLine("End ...");
            }
        }
    }
}
