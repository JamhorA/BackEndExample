using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace Example.Models.Entities;

[PrimaryKey(nameof(ProductID), nameof(CategoryID))]
public class ProductCategoryEntity
{
	[ForeignKey(nameof(Product))]
	public int ProductID { get; set; }

	[ForeignKey(nameof(Category))]
	public int CategoryID { get; set; }
	public virtual ProductEntity Product { get; set; } = null!;
	public virtual CategoryEntity Category { get; set; } = null!;
}
