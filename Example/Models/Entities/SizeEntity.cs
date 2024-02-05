using System.ComponentModel.DataAnnotations.Schema;
namespace Example.Models.Entities;

public class SizeEntity
{
	public int SizeID { get; set; }

	[Column(TypeName = "nvarchar(45)")]
	public string SizeName { get; set; } = null!;
	// Navigation property
	public virtual ICollection<ProductSizeEntity> ProductSizes { get; set; } = new HashSet<ProductSizeEntity>();
}
