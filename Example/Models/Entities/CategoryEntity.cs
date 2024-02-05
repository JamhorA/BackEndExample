using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Example.Models.Entities;

public class CategoryEntity
{
	[Key]
	public int CategoryID { get; set; }
	[Column(TypeName = "nvarchar(45)")]
	public string CategoryName { get; set; } = null!;
	// Navigation property
	public virtual ICollection<ProductCategoryEntity> ProductCategories { get; set; } = new HashSet<ProductCategoryEntity>();
}
