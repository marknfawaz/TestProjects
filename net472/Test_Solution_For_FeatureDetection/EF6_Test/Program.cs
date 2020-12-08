using System;
using System.Linq;
using EF6Example;
using EF6Example.Models;

//using EF6Example;
//using EF6Example.Models;

namespace Driver
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new FunctionalDbContext("name=default"))
            {
                Console.WriteLine(context.Database.Connection.ConnectionString);
                var recordCount = context.MyModels.Count();

                // Create a record if none currently exist
                if (recordCount == 0)
                {
                    context.MyModels.Add(new MyModel
                    {
                        Id = 1,
                        Name = "A Model"
                    });
                    context.SaveChanges();
                }
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }
    }
}