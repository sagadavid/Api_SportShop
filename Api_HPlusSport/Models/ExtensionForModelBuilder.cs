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
          new Product { Id = 1, Sku="asdaf", Name = "aswertrefas", Description ="for vinteren", Price = 9, IsAvailable=true, CategoryId=1 },
          new Product { Id = 2, Sku = "asd", Name = "asdfasd", Description = "for sdfgd", Price = 9, IsAvailable = true, CategoryId = 1 },
          new Product { Id = 3, Sku = "dfgfds", Name = "asdfasdf", Description = "for sdfgsd", Price = 9, IsAvailable = true, CategoryId = 2 },
          new Product { Id = 4, Sku = "dsgsd", Name = "afdsaf", Description = "for cvbvxb", Price = 9, IsAvailable = true, CategoryId = 3 },
          new Product { Id = 5, Sku = "dfgfd", Name = "xzvzxc", Description = "for dghdfg", Price = 9, IsAvailable = true, CategoryId = 4 },
          new Product { Id = 6, Sku = "sdgf", Name = "sdafsad", Description = "for vintghdfgeren", Price = 9, IsAvailable = true, CategoryId = 4 },
          new Product { Id = 7, Sku = "sdfgs", Name = "retwret", Description = "for dfghdgf", Price = 9, IsAvailable = true, CategoryId = 3 },
          new Product { Id = 8, Sku = "wert", Name = "sdgfdg", Description = "for fdghgfd", Price = 9, IsAvailable = true, CategoryId = 2 },
          new Product { Id = 9, Sku = "trdhg", Name = "barntwertakler", Description = "for dfgh", Price = 9, IsAvailable = true, CategoryId = 1 },
          new Product { Id = 10, Sku = "wertre", Name = "fgdfd", Description = "for dfgh", Price = 9, IsAvailable = true, CategoryId = 2 },
          new Product { Id = 11, Sku = "dfsgs", Name = "barfgsgsdnakler", Description = "for dfghgdf", Price = 9, IsAvailable = true, CategoryId = 3 }

          );
        }
    }
}
