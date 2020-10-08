using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SinglePage.Models.ViewModels;
namespace SinglePage.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        #region [- ctor -]
        public ProductController()
        {
            Ref_ProductViewModel = new Models.ViewModels.ProductViewModel();
            Ref_CategoryViewModel = new Models.ViewModels.CategoryViewModel();

        }
        #endregion

        #region [- props -]
        public Models.ViewModels.ProductViewModel Ref_ProductViewModel { get; set; }
        public Models.ViewModels.CategoryViewModel Ref_CategoryViewModel { get; set; }
        #endregion

        #region [- Actions -]

        #region [- Product() -]
        public ActionResult Product()
        {
            ViewBag.CategoryId =
                    new SelectList(Ref_ProductViewModel.GetCategoryFields(), "CategoryId", "Title");
            return View(Ref_ProductViewModel);
        }
        #endregion

        #region [- Create() -]
       
       
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Create(ProductViewModel ref_ProductViewModel)
        {
            if (ModelState.IsValid)
            {
               
                ViewBag.CategoryId =
                    new SelectList(Ref_ProductViewModel.GetCategoryFields(), "CategoryId", "Title");
                Ref_ProductViewModel.PostProduct(ref_ProductViewModel);

                return Json(new { Message = "Success" }, JsonRequestBehavior.AllowGet);
            }

            else
            {
                return Json(new
                {
                    ModelState_IsValid = "False",
                    JsonRequestBehavior.AllowGet
                });
            }
        }
        #endregion

    

        #region [- Edit() -]

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Edit(ProductViewModel ref_ProductViewModel)
        {
            if (ModelState.IsValid)
            {
                
                ViewBag.CategoryId =
                   new SelectList(Ref_ProductViewModel.GetCategoryFields(), "CategoryId", "Title");
                ref_ProductViewModel.FindProduct(ref_ProductViewModel.ProductId);
                ref_ProductViewModel.UpdateProduct(ref_ProductViewModel);
                return Json(new { Message = "Success" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new
                {
                    ModelState_IsValid = "False",
                    JsonRequestBehavior.AllowGet
                });
            }


        }
        

        #endregion

        #region [- Delete() -]

        
        [HttpPost]
        public ActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                Ref_ProductViewModel.DeleteProduct(id);
                return Json(JsonRequestBehavior.AllowGet);
            }

            else

            {
                return Json(new
                {
                    ModelState_IsValid = "False",
                    JsonRequestBehavior.AllowGet
                });
            }
        }
        #endregion

       
        #endregion
    }
}