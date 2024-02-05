using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace Example.Models.Entities;

[PrimaryKey(nameof(UserID), nameof(AddressID))]
public class UserAddressEntity
{

	[ForeignKey(nameof(User))]
	public required string UserID { get; set; }

	[ForeignKey(nameof(Address))]
	public int AddressID { get; set; }


	public virtual UserEntity User { get; set; } = null!;
	public virtual AddressEntity Address { get; set; } = null!;
}
