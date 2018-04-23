using System;

using DevExpress.Xpo;

using DevExpress.Xpo.DB;
using DevExpress.Data.Filtering;


namespace ConsoleApplication1
{

    class Program
    {

        static void Main(string[] args)
        {

            XpoDefault.DataLayer = XpoDefault.GetDataLayer("http://localhost:55777/Service1.svc",

            AutoCreateOption.DatabaseAndSchema);

            XpoDefault.Session = null;

            using (UnitOfWork uow = new UnitOfWork())
            {
                if (uow.FindObject(typeof(Customer), new BinaryOperator("ContactName", "Alex Smith", BinaryOperatorType.Equal)) == null)
                {
                Customer custAlex = new Customer(uow);
                custAlex.ContactName = "Alex Smith";
                custAlex.CompanyName = "DevExpress";
                custAlex.Save();
                
                Customer Tom = new Customer(uow);
                Tom.ContactName = "Tom Jensen";
                Tom.CompanyName = "ExpressIT";
                Tom.Save();
                uow.CommitChanges();
                }

                using (XPCollection<Customer> customers = new XPCollection<Customer>(uow))
                {
               
                    foreach (Customer customer in customers)
                    {
               
                        Console.WriteLine("Company Name = {0}; ContactName = {1}", customer.CompanyName, customer.ContactName);
                    }
                }
            }

            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }
    }
}
