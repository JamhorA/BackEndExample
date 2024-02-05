using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace Example.Models.Entities;

[PrimaryKey(nameof(ProductID), nameof(SizeID))]
public class ProductSizeEntity
{
	[ForeignKey(nameof(Product))]
	public int ProductID { get; set; }

	[ForeignKey(nameof(Size))]
	public int SizeID { get; set; }
	public virtual ProductEntity Product { get; set; } = null!;
	public virtual SizeEntity Size { get; set; } = null!;
}
