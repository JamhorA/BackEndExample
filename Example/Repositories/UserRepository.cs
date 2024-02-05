using Example.Contexts;
using Example.Models.Entities;
using Example.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Example.Repositories;

public class UserRepository(DataContext dataContext) : Repo<UserEntity>(dataContext), IUserRepository
{
	private readonly DataContext _dataContext = dataContext;

	public override async Task<IEnumerable<UserEntity>> GetAllAsync()
	{
		try
		{
			var users = await _dataContext.Users.Include(x => x.UserAddresses)
				.ThenInclude(x => x.Address).Include(x => x.UserImages)
				.ThenInclude(x => x.Image).ToListAsync();
			if (users != null)
				return users;
		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex.Message);
		}
		return null!;
	}

	public override Task<IEnumerable<UserEntity>> GetAllAsync(Expression<Func<UserEntity, bool>> predicate)
	{
		return base.GetAllAsync(predicate);
	}

	public override async Task<UserEntity> GetAsync(Expression<Func<UserEntity, bool>> predicate)
	{
		try
		{
			var product = await _dataContext.Users.Include(x => x.UserAddresses)
				.ThenInclude(x => x.Address).Include(x => x.UserImages)
				.ThenInclude(x => x.Image).FirstOrDefaultAsync(predicate);
		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex.Message);
		}
		return null!;
	}
}
