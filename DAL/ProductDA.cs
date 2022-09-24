using BOL;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class ProductDA : IDisposable
    {
        private readonly ManageProductsContext _db;

        public ProductDA(ManageProductsContext db)
        {
            _db = db;
        }

        public async Task<Product> Create(Product Product)
        {
            Product.ProductId = Guid.NewGuid();
            Product.CreatedOn = DateTime.Now;
            Product.StatusCode = true;

            _db.Products.Add(Product);
            await _db.SaveChangesAsync();
            return Product;
        }

        public async Task<Product> Update(Product product)
        {
            product.ModifiedOn = DateTime.Now;
            _db.Entry(product).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return product;
        }

        public async Task<Product> Delete(Product product)
        {
            _db.Entry(product).State = EntityState.Deleted;
            await _db.SaveChangesAsync();

            return product;
        }


        public async Task<Product> Find(Guid productId)
        {
            return await _db.Products.FindAsync(productId);
        }

        public IQueryable<Product> Where(System.Linq.Expressions.Expression<Func<Product, bool>> predicate)
        {
            return _db.Products.Where(predicate);
        }


        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~AttachmentDA()
        // {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion


    }
}