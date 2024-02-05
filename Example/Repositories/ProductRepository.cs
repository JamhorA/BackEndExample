using Example.Contexts;
using Example.Models.Entities;
using Example.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Example.Repositories;

public class ProductRepository(DataContext dataContext) : Repo<ProductEntity>(dataContext), IProductRepository
{
	private readonly DataContext _dataContext = dataContext;
    public override async Task<IEnumerable<ProductEntity>> GetAllAsync()
    {
        try
        {
            var products = await _dataContext.Products
                .Include(x => x.ProductSizes).ThenInclude(x => x.Size)
                .Include(x => x.ProductImages).ThenInclude(x => x.Image)
                .Include(x => x.ProductCategories).ThenInclude(x => x.Category).ToListAsync();
            if (products != null)
                return products;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        return null!;
    }

    public override Task<IEnumerable<ProductEntity>> GetAllAsync(Expression<Func<ProductEntity, bool>> predicate)
	{
		return base.GetAllAsync(predicate);
	}

	public override async Task<ProductEntity> GetAsync(Expression<Func<ProductEntity, bool>> predicate)
	{
		try
		{
			var product = await _dataContext.Products
				.Include(x => x.ProductSizes).ThenInclude(x => x.Size)
                .Include(x => x.ProductImages).ThenInclude(x => x.Image)
                .Include(x => x.ProductCategories).ThenInclude(x => x.Category).FirstOrDefaultAsync(predicate);
		} catch(Exception ex)
		{
			Debug.WriteLine(ex.Message);
		}
		return null!;
	}
}
