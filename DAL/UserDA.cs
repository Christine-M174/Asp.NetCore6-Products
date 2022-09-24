using BOL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserDA
    {

        private readonly ManageProductsContext _db;

        public UserDA(ManageProductsContext db)
        {
            this._db = db;
        }


        public User Create(User user)
        {
            user.UserId = Guid.NewGuid();
            _db.Users.Add(user);
            _db.SaveChanges();
            return user;
        }


        public IQueryable<User> List()
        {
            var list = _db.Users;
            return list;
        }


        public User Find(Guid userId)
        {
            return _db.Users.Find(userId);
        }

        public User Update(User user)
        {

            _db.Entry(user).State = EntityState.Modified;
            _db.SaveChanges();
            return user;
        }


        public User Delete(User user)
        {

            _db.Entry(user).State = EntityState.Deleted;
            _db.SaveChanges();

            return user;
        }



        //public User Find(Guid userId)
        //{
        //    var user= _db.Users
        //        .Include("TaskStatues")
        //        .SingleOrDefault(t => t.UserId == userId);

        //    return user;
        //}



    }
}
