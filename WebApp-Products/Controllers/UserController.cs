using BLL;
using BOL;
using DAL;
using Microsoft.AspNetCore.Mvc;

namespace WebApp_Products.Controllers
{
    public class UserController : Controller
    {

        private readonly UserBL _userBL;
        private readonly ManageProductsContext _db;
        private readonly Role _role;
        public UserController(UserBL userBL, ManageProductsContext db, Role role)
        {
            this._userBL = userBL;
            this._db = db;
            this._role = role;
        }
        [HttpPost]
        public JsonResult Login(LoginModel loginModel)
        {
            try
            {
                var user = _db.Users.Where(i => i.UserName == loginModel.UserName && i.Password == loginModel.Password).SingleOrDefault();
                //To check if the username or password inputs are empty or not, !ModelState.IsValid means ModelState.IsValid = false...

                if (user == null)
                {
                    return Json(new { errMsg = "Please enter your datasss" });

                }
                else if (user != null)
                {
                    //* Save User Information in session *// 

                    HttpContext.Session.SetString("UserId", user.UserId.ToString());
                    return Json("userid keeped in a session");
                }

                else
                {
                    return Json(new { errMsg = "Failed Login" });
                }
            }
            catch (Exception exp)
            {
                return Json(new { errMsg = "test" });
            }

        }
    }
}
