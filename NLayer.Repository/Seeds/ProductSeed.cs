using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core;

namespace NLayer.Repository.Seeds
{
    internal class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product() { Id = 1, Name = "Kalem1", CategoryId = 1, CreatedDate = DateTime.Now, Price = 100, Stock = 20 },
                new Product() { Id = 2, Name = "Kalem2", CategoryId = 1, CreatedDate = DateTime.Now, Price = 200, Stock = 40 },
                new Product() { Id = 3, Name = "Kalem3", CategoryId = 1, CreatedDate = DateTime.Now, Price = 300, Stock = 60 },
                new Product() { Id = 4, Name = "Kitaplar1", CategoryId = 2, CreatedDate = DateTime.Now, Price = 600, Stock = 600 },
                new Product() { Id = 5, Name = "Kitaplar2", CategoryId = 2, CreatedDate = DateTime.Now, Price = 700, Stock = 70 },
                new Product() { Id = 6, Name = "Defterler1", CategoryId = 3, CreatedDate = DateTime.Now, Price = 300, Stock = 300 }
                );
        }
    }
}
