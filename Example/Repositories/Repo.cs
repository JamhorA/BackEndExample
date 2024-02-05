using Example.Contexts;
using Example.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Example.Repositories;

public abstract class Repo<TEntity> : IRepo<TEntity> where TEntity : class
{

	private readonly DataContext _dataContext;

	protected Repo(DataContext dataContext)
	{
		_dataContext = dataContext;
	}

	public virtual async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate)
	{
		try 
		{
			await _dataContext.Set<TEntity>().AnyAsync(predicate);
			return true;
		}
		catch(Exception ex) 
		{
			Debug.WriteLine(ex.Message);
			return false;
		}
	}
	public virtual async Task<TEntity> CreateAsync(TEntity entity)
	{
		try
		{
			await _dataContext.Set<TEntity>().AddAsync(entity);
			await _dataContext.SaveChangesAsync();
			return entity;
		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex.Message);
			return null!;
		}
	}
	public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
	{
		try
		{
			var entity = await _dataContext.Set<TEntity>().FirstOrDefaultAsync(predicate);
			return entity!;
		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex.Message);
			return null!;
		}
	}
	public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
	{
		try
		{
			return await _dataContext.Set<TEntity>().ToListAsync();
		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex.Message);
			return null!;
		}
	}
	public virtual async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate)
	{
		try
		{
			return await _dataContext.Set<TEntity>().Where(predicate).ToListAsync();
		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex.Message);
			return null!;
		}
	}
	public virtual async Task<TEntity> UpdateAsync(TEntity entity)
	{
		try
		{
			_dataContext.Set<TEntity>().Update(entity);
			await _dataContext.SaveChangesAsync();
			return entity;
		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex.Message);
			return null!;
		}
	}
	public virtual async Task<TEntity> DeleteAsync(TEntity entity)
	{
		try
		{
			_dataContext.Set<TEntity>().Remove(entity);
			await _dataContext.SaveChangesAsync();
			return entity;
		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex.Message);
			return null!;
		}
	}

}
