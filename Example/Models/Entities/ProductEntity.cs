using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Example.Models.Entities;

public class ProductEntity
{
	[Key]
	public int ProductID { get; set; }

	[Column(TypeName = "nvarchar(150)")]
	public string ProductName { get; set; } = null!;
	// Navigation properties
	public virtual ICollection<ProductImageEntity> ProductImages { get; set; } = new HashSet<ProductImageEntity>();
	public virtual ICollection<ProductSizeEntity> ProductSizes { get; set; } = new HashSet<ProductSizeEntity>();
	public virtual ICollection<ProductCategoryEntity> ProductCategories { get; set; } = new HashSet<ProductCategoryEntity>();
}
