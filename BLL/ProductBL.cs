using BOL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ProductBL
    {

        private readonly ProductDA _productDA;

        public ProductBL(ProductDA productDA)
        {
            this._productDA = productDA;
        }

        public async Task<Product> Save(Product product)
        {
            if (product.ProductId == Guid.Empty)
            {


                return await _productDA.Create(product);

            }
            else
            {
                return await _productDA.Update(product);
            }
        }


        public async Task<Product> Delete(Product product)
        {

            return await _productDA.Delete(product);
        }



        public async Task<Product> Find(Guid productId)
        {
            return await _productDA.Find(productId);
        }

        public IQueryable<Product> Search(System.Linq.Expressions.Expression<Func<Product, bool>> predicate)
        {
            return _productDA.Where(predicate);
        }


    }
}
