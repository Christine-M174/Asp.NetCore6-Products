using BOL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CategoryBL
    {

        private readonly CategoryDA _categoryDA;

        public CategoryBL(CategoryDA categoryDA)
        {
            this._categoryDA = categoryDA;
        }

        public Category Save(Category category)
        {
            if (category.CategoryId == Guid.Empty)
            {


                return _categoryDA.Create(category);

            }
            else
            {
                return _categoryDA.Update(category);
            }
        }


        public Category Delete(Category category)
        {

            return _categoryDA.Delete(category);
        }



        public Category Find(Guid categoryId)
        {
            return _categoryDA.Find(categoryId);
        }

        public IQueryable<Category> Search(System.Linq.Expressions.Expression<Func<Category, bool>> predicate)
        {
            return _categoryDA.Where(predicate);
        }

    }
}
