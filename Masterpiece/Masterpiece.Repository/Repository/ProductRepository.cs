using Masterpiece.Domain.Entity;
using Masterpiece.Repository.DBContext;
using Masterpiece.Repository.RepositoryBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Masterpiece.Repository.IRepository
{
    public class ProductRepository : RepositoryBase<MasterpieceDBContext, Product>, IProductRepository
    {
        public ProductRepository(MasterpieceDBContext dbcontext) : base(dbcontext)
        {
        }

        public int Add(Product entity)
        {
            return base.InsertEntity(entity);
        }
    }
}
