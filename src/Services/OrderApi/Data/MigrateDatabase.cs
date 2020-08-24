using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApi.Data
{
    public static class MigrateDatabase
    {
        public static void EnsureCreated(OrdersContext context)
        {
            System.Console.WriteLine("Migration tking place.....Creating Database..");
            context.Database.Migrate();

            System.Console.WriteLine("Migration Completed...");
        }
    }
}
