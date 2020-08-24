using Microsoft.EntityFrameworkCore;
using RestaurantApi.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantApi.DataAccess
{
    public class ReviewDbContext : DbContext
    {
        public ReviewDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Review> Reviews { get; set; }


    }
}
