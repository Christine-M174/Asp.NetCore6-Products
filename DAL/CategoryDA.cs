using BOL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CategoryDA : IDisposable
    {

        private readonly ManageProductsContext _db;

        public CategoryDA(ManageProductsContext db)
        {
            _db = db;
        }

        public Category Create(Category category)
        {
            category.CategoryId = Guid.NewGuid();
            category.CreatedOn = DateTime.Now;
            category.ModifiedOn = DateTime.Now;

            _db.Categories.Add(category);
            _db.SaveChanges();
            return category;
        }

        public Category Update(Category category)
        {
            category.ModifiedOn = DateTime.Now;
            _db.Entry(category).State = EntityState.Modified;
            _db.SaveChanges();
            return category;
        }

        public Category Delete(Category category)
        {
            //    //   var  = _db.Comments.Where(x => x.CommentId == id).SingleOrDefault();
            //    _db.Comments.Remove();
            _db.Entry(category).State = EntityState.Deleted;
            _db.SaveChanges();

            return category;
        }




        public Category Find(Guid categoryId)
        {
            return _db.Categories.Find(categoryId);
        }

        public IQueryable<Category> Where(System.Linq.Expressions.Expression<Func<Category, bool>> predicate)
        {
            return _db.Categories.Where(predicate);
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
        // ~CommentDA()
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
