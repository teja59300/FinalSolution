using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestuarantSearchApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestuarantSearchApi.Data
{
    public class SearchItemContext:DbContext
    {
        public SearchItemContext(DbContextOptions options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<RestaurantDetails>(ConfigureRestaurantDetails);
            builder.Entity<SearchItem>(ConfigureSearchItem);
        }

        private void ConfigureSearchItem(EntityTypeBuilder<SearchItem> builder)
        {
            builder.ToTable("Search");
            builder.Property(s => s.ItemId)
                .ForSqlServerUseSequenceHiLo("search_hilo")
                .IsRequired(true);
            builder.Property(s => s.ItemName)
                .IsRequired(true)
                .HasMaxLength(50);
            builder.Property(s => s.ItemPrice)
                .IsRequired(true);
            builder.Property(s => s.ItemPictureUrl)
                .IsRequired(true);
            builder.Property(s => s.Quantity)
                .IsRequired(true);
            builder.HasOne(s => s.Restaurants)
                .WithMany()
                .HasForeignKey(s => s.RestaurantId);
            
           
        }

        private void ConfigureRestaurantDetails(EntityTypeBuilder<RestaurantDetails> builder)
        {
            builder.ToTable("RestaurantDetails");
            builder.Property(s => s.RestaurantId)
                .ForSqlServerUseSequenceHiLo("restaurant_detais_hilo")
                .IsRequired();
            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(s => s.Location)
                .IsRequired();
            builder.Property(s => s.PictureUrl)
                .IsRequired();
            builder.Property(s => s.Rating)
                .IsRequired();
        }
        public DbSet<RestaurantDetails> RestaurantDetails { get; set; }
        public DbSet<SearchItem> SearchItems { get; set; }
    }
}
