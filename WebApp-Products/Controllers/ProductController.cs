using BLL;
using BOL;
using DAL;
using Microsoft.AspNetCore.Http;
//using WebApp_Products.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace WebApp_Products.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class ProductController : Controller
    {
        private readonly ProductBL _productBL;
        private readonly ManageProductsContext _db;
        //private readonly User _user;
        //private readonly Product _product;
        public ProductController(ManageProductsContext db, ProductBL productBL)//(ProductBL productBL, ApplicationDbContext db)//, User user)//, Product product)
        {
            this._productBL = productBL;
            this._db = db;
            //this._user = user;
           // this._product = product;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            var userId = HttpContext.Session.GetString("UserId");
            product.CreatedBy = Guid.Parse(userId);
            product.StatusCode = true;

            bool value = _db.Users.Where(i => i.Role.RoleName == "Admin" || i.Role.RoleName == "Manager").Any();
            if (value == false)
            {
                return new JsonResult(new { errMsg = "permissions for Admin and Managers only" });
            }
            else
            {
                await _productBL.Save(product);
            }
            return Json(product);
        }

        [HttpPost]
        public async Task<IActionResult> EditProduct(Product product)
        {
            var userId = HttpContext.Session.GetString("UserId");
            product.ModifiedBy = Guid.Parse(userId);

            bool value = _db.Users.Where(i => i.Role.RoleName == "Admin" || i.Role.RoleName == "Manager").Any();
            if (value == false)
            {
                return new JsonResult(new { errMsg = "permissions for Admin and Managers only" });
            }
            else
            {
                await _productBL.Save(product);
            }
            return Json(product);
        }

        [HttpGet]
        public async Task<IActionResult> GetProductById(Guid productId)
        {
            var getproductid =await  _productBL.Find(productId);
            return Json(getproductid);
        }

        [HttpGet]
        public IActionResult GetListOfProjects()
        {
            List<Product> products = _db.Products.Where(i => i.StatusCode == true).ToList();
            return Json(products);
        }

        [HttpGet]
        public IActionResult GetListOfProjectsName()
        {
            var ProductsName = _db.Products.Where(i => i.StatusCode == true).Select(i => i.ProductName).ToList();
            return Json(ProductsName);
        }

        [HttpGet]
        public IActionResult GetListOfProjectsCreationDate()
        {
            var ProductscreationDates = _db.Products.Where(i => i.StatusCode == true).Select(i => i.CreatedOn).ToList();
            return Json(ProductscreationDates);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProduct(Product product)
        {
            await _productBL.Delete(product);
            return Json(new { errMsg = "this product moved to the archive" });

        }


        [HttpPost]
        public async Task<IActionResult> DeactivateProduct(Product product)
        {
            bool value = _db.Users.Where(i => i.Role.RoleName == "Admin").Any();
            if (value == false)
            {
                return new JsonResult(new { errMsg = "permissions for Admin and Managers only" });
            }
            else 
            {
                product.StatusCode = false;
               await  _productBL.Save(product);
            }
            return Json(new { errMsg = "this product moved to the archive" });
        }
    }

    //[Route("api/Product/ProductsList")]
    //[HttpGet]
    //public IActionResult ProductsList()
    //{
    //    var products = _db.Products.ToList().SingleOrDefault();
    //    return Json(products);
    //}

    //[HttpPost]
    //public IActionResult CreateProduct(Product product)
    //{
    //    //var userId = HttpContext.Session.GetString("UserId");
    //    var newProduct = _productBL.Save(product);
    //    // product.CreatedBy = Guid.Parse(userId);
    //    return Json(newProduct);

    //}

    //[HttpPost]
    //public IActionResult Create(Product Product)
    //{
    //    Product.ProductId = Guid.NewGuid();
    //    Product.CreatedOn = DateTime.Now;
    //    Product.StatusCode = true;

    //  var newProduct =  _db.Products.Add(Product);
    //    ///_db.SaveChanges();
    //    return Json(newProduct);
    //}


    //[HttpPost]
    //public IActionResult EditProduct(Product product)



}



