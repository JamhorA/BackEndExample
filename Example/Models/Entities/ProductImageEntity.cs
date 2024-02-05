using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace Example.Models.Entities;

[PrimaryKey(nameof(ProductID), nameof(ImageID))]
public class ProductImageEntity
{
	[ForeignKey(nameof(Product))]
	public int ProductID { get; set; }

	[ForeignKey(nameof(Image))]
	public string? ImageID { get; set; }
	public virtual ProductEntity Product { get; set; } = null!;
	public virtual ImageEntity? Image { get; set; }
}
