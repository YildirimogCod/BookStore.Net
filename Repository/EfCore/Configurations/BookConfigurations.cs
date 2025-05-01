using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Repository.EfCore.Configurations
{
     public class BookConfigurations:IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasData(
                new Book()
                {
                    Id = 1,
                    Title = "C# in Depth",
                    Price = 75
                },
                new Book
                {
                    Id = 2,
                    Title = "Kazım Karabekir",
                    Price = 175
                },
                new Book
                {
                    Id = 3,
                    Title = "Fevzi Çakmak",
                    Price = 75
                }
            );
        }
    }
}
