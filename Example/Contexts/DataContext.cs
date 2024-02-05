using Example.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Example.Contexts;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
	public DbSet<AddressEntity> Addresses { get; set; }
	public DbSet<CategoryEntity> Categories { get; set; }
	public DbSet<ImageEntity> Images { get; set; }
	public DbSet<ProductCategoryEntity> ProductCategories { get; set; }
	public DbSet<ProductEntity> Products { get; set; }
	public DbSet<ProductImageEntity> ProductImages { get; set; }
	public DbSet<ProductSizeEntity> ProductSizes { get; set; }
	public DbSet<SizeEntity> Sizes { get; set; }
	public DbSet<UserAddressEntity> UserAddresses { get; set; }
	public DbSet<UserEntity> Users { get; set; }
	public DbSet<UserImageEntity> UserImages { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		// Exempel på att konfigurera en kompositnyckel för UserAddressEntity
		modelBuilder.Entity<AddressEntity>()
	.HasKey(a => a.AddressID);
		modelBuilder.Entity<CategoryEntity>()
	.HasKey(c => c.CategoryID);
		modelBuilder.Entity<ImageEntity>()
	.HasKey(e => e.ImageID);
		modelBuilder.Entity<ProductEntity>()
	.HasKey(p => p.ProductID);
		modelBuilder.Entity<SizeEntity>()
.HasKey(p => p.SizeID);
		modelBuilder.Entity<UserAddressEntity>()
			.HasKey(ua => new { ua.UserID, ua.AddressID });

		// Upprepa liknande konfiguration för andra entiteter med kompositnycklar
		modelBuilder.Entity<UserImageEntity>()
			.HasKey(ui => new { ui.UserID, ui.ImageID });

		modelBuilder.Entity<ProductImageEntity>()
			.HasKey(pi => new { pi.ProductID, pi.ImageID });

		modelBuilder.Entity<ProductSizeEntity>()
			.HasKey(ps => new { ps.ProductID, ps.SizeID });

		modelBuilder.Entity<ProductCategoryEntity>()
			.HasKey(pc => new { pc.ProductID, pc.CategoryID });

		// Ytterligare konfigurationer om nödvändigt

		base.OnModelCreating(modelBuilder);


        // Seed Users
        var randomUsers = new List<UserEntity>();
        // Seed Addresses
        var randomAddresses = new List<AddressEntity>();
        // Seed Images
        var randomImages = new List<ImageEntity>();
        // Antag att du vill skapa relationer för alla användare och adresser
        var userAddressRelations = new List<UserAddressEntity>();
        var userImageRelations = new List<UserImageEntity>();
        // Seed Products
        var randomProducts = new List<ProductEntity>();
        // Seed Categoriess
        var randomCategories = new List<CategoryEntity>();
        // Seed Sizess
        var randomSizes = new List<SizeEntity>();
        var productImageRelations = new List<ProductImageEntity>();
        var productCategoryRelations = new List<ProductCategoryEntity>();
        var productSizeRelations = new List<ProductSizeEntity>();

        for (int i = 0; i < 10; i++) // Använd 0-baserad indexering
        {
            var userId = Guid.NewGuid().ToString();
            var imageUrl = $"https://picsum.photos/id/{i}/400/300"; // Använd Picsum för att generera en URL
            randomUsers.Add(new UserEntity
            {
                UserID = userId,
                FirstName = $"FirstName{i + 1}",
                LastName = $"LastName{i + 1}",
                Email = $"user{i + 1}@example.com",
                PhoneNumber = $"12345678{i + 1}",
            });

            randomAddresses.Add(new AddressEntity
            {
                AddressID = i + 1, // Antag att du vill att AddressID ska börja från 1
                Street = $"Street{i + 1}",
                City = $"City{i + 1}",
                Country = $"Country{i + 1}"
            });

            // Lägg till en relation för varje användare och adress
            userAddressRelations.Add(new UserAddressEntity
            {
                UserID = userId,
                AddressID = i + 1
            });

            randomImages.Add(new ImageEntity
            {
                ImageID = Guid.NewGuid().ToString(),
                ImageUrl = imageUrl
            });
            // Lägg till en relation för varje användare och adress
            userImageRelations.Add(new UserImageEntity
            {
                UserID = userId,
                ImageID = randomImages[i].ImageID,
            });
            randomProducts.Add(new ProductEntity
            {
                ProductID = i + 1,
                ProductName = $"Product{i}",
            });
            randomCategories.Add(new CategoryEntity
            {
                CategoryID = i + 1,
                CategoryName = $"Category{i}",
            });
            randomSizes.Add(new SizeEntity
            {
                SizeID = i + 1,
                SizeName = $"Size{i}",
            });
            productImageRelations.Add(new ProductImageEntity
            {
                ProductID = i + 1,
                ImageID = randomImages[i].ImageID,
            });
            productCategoryRelations.Add(new ProductCategoryEntity
            {
                ProductID = i + 1,
                CategoryID = i + 1,
            });
            productSizeRelations.Add(new ProductSizeEntity
            {
                ProductID = i + 1,
                SizeID = i + 1,
            });
        }

        // Efter att alla objekt har skapats, använd HasData för att seeda dem
        modelBuilder.Entity<UserEntity>().HasData(randomUsers);
        modelBuilder.Entity<AddressEntity>().HasData(randomAddresses);
        modelBuilder.Entity<UserAddressEntity>().HasData(userAddressRelations);
        modelBuilder.Entity<ImageEntity>().HasData(randomImages);
        modelBuilder.Entity<UserImageEntity>().HasData(userImageRelations);
        modelBuilder.Entity<ProductEntity>().HasData(randomProducts);
        modelBuilder.Entity<CategoryEntity>().HasData(randomCategories);
        modelBuilder.Entity<SizeEntity>().HasData(randomSizes);
        modelBuilder.Entity<ProductImageEntity>().HasData(productImageRelations);
        modelBuilder.Entity<ProductCategoryEntity>().HasData(productCategoryRelations);
        modelBuilder.Entity<ProductSizeEntity>().HasData(productSizeRelations);

    }
}
