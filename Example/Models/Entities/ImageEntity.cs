using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Example.Models.Entities;

public class ImageEntity
{
	[Key]
	public string ImageID { get; set; } = Guid.NewGuid().ToString();

	[Column(TypeName = "nvarchar(450)")]
	public string? ImageUrl { get; set; }
	// Navigation properties
	public virtual ICollection<UserImageEntity> UserImages { get; set; } = new HashSet<UserImageEntity>();
	public virtual ICollection<ProductImageEntity> ProductImages { get; set; } = new HashSet<ProductImageEntity>();
}
