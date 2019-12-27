using Masterpiece.Bll;
using Masterpiece.Repository.DBContext;
using Masterpiece.Repository.IRepository;
using System.Collections.Generic;

namespace AbhsCrmToC.Bll
{
    public class ProductBll : BllBase
    {
        private IProductRepository productRepository;

        public IProductRepository ProductRepository
        {
            get
            {
                if (productRepository == null)
                {
                    productRepository = new ProductRepository(contextFactory.DBContext);
                }

                return productRepository;
            }
        }

        public ProductBll(MasterpieceDBContext contextFactory) : base(contextFactory)
        {
        }

        public IList<ProductBll> GetBooks(int subjectId)
        {
            return null;
        }
    }
}