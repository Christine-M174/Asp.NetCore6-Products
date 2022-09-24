using BOL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UserBL
    {
        private readonly UserDA _userDA;

        public UserBL(UserDA userDA)
        {
            _userDA = userDA;
        }


        public User Save(User user)
        {
            if (user.UserId == Guid.Empty)
            {


                return _userDA.Create(user);

            }
            else
            {
                return _userDA.Update(user);
            }
        }

       // public IQueryable<User> List()
        //{
        //    return _userDA.List();
        //}

        public User Find(Guid userId)
        {
            return _userDA.Find(userId);
        }

        public User Delete(User user)
        {

            return _userDA.Delete(user);
        }

    }
}
