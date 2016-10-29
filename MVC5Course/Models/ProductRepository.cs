using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVC5Course.Models
{   
	public  class ProductRepository : EFRepository<Product>, IProductRepository
	{
        public override IQueryable<Product> All()
        {
            return base.All().Where(p=>!p.IsDeleted);
        }
        public Product find(int id)
        {
            return this.All().FirstOrDefault(p=>p.ProductId==id);
        }

        public IQueryable<Product> get®aÆ·¹P”µ(int count)
        {
            return this.All().OrderByDescending(p => p.ProductId).Take(count);
        }

        public override void Delete(Product entity)
        {
            entity.IsDeleted = true;
        }
    }

	public  interface IProductRepository : IRepository<Product>
	{

	}
}