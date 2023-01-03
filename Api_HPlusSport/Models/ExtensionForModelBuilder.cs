using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Api_HPlusSport.Models
{
    public static class ExtensionForModelBuilder
    {
        public static void Seed(this ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Category>().HasData
            (
                new Category { Id = 1, Name = "barnakler" },
                 new Category { Id = 2, Name = "brus" },
                  new Category { Id = 3, Name = "blad" },
                   new Category { Id = 4, Name = "dokker" },
                    new Category { Id = 5, Name = "utstyr" }
                ) ;
            modelBuilder.Entity<Product>().HasData
      (
          new Product { Id = 1, Sku= "summer", Name = "qwertyuiop", Description ="for vinteren", Price = 9, IsAvailable=true, CategoryId=1 },
          new Product { Id = 2, Sku = "summer", Name = "asdfghj", Description = "for sdfgd", Price = 92, IsAvailable = true, CategoryId = 1 },
          new Product { Id = 3, Sku = "fjell", Name = "dfghjkl", Description = "for sdfgsd", Price = 29, IsAvailable = false, CategoryId = 2 },
          new Product { Id = 4, Sku = "spring", Name = "zxcvbn", Description = "for cvbvxb", Price = 94, IsAvailable = true, CategoryId = 3 },
          new Product { Id = 5, Sku = "fall", Name = "vbnm,.", Description = "for dghdfg", Price = 59, IsAvailable = true, CategoryId = 4 },
          new Product { Id = 6, Sku = "fjell", Name = "fghjkl;", Description = "for vintghdfgeren", Price = 49, IsAvailable = true, CategoryId = 4 },
          new Product { Id = 7, Sku = "summer", Name = "rtyuio", Description = "for dfghdgf", Price = 95, IsAvailable = true, CategoryId = 3 },
          new Product { Id = 8, Sku = "cloth", Name = "uiop[", Description = "for fdghgfd", Price = 39, IsAvailable = true, CategoryId = 2 },
          new Product { Id = 9, Sku = "summer", Name = "qwertyuhjk", Description = "for dfgh", Price = 19, IsAvailable = false, CategoryId = 1 },
          new Product { Id = 10, Sku = "fjell", Name = "fgdqwertasdffd", Description = "for dfgh", Price = 79, IsAvailable = true, CategoryId = 2 },
          new Product { Id = 11, Sku = "spring", Name = "zxcvbasdf", Description = "for dfghgdf", Price = 33, IsAvailable = false, CategoryId = 3 }

          );
        }
    }
}
