using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SinglePage.Models.ViewModels;

namespace SinglePage.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        #region [- ctor -]
        public CategoryController()
        {
            Ref_CategoryViewModel = new Models.ViewModels.CategoryViewModel();
        }
        #endregion
        #region [- Props -]

        public Models.ViewModels.CategoryViewModel Ref_CategoryViewModel { get; private set; }

        #endregion

        #region [- Actions -]

        #region [- Category() -]
        public ActionResult Category()
        {
            return View(Ref_CategoryViewModel);
        }
        #endregion

        #region [- Create() -]
        [HttpPost]

        [AllowAnonymous]
        public ActionResult Create(CategoryViewModel ref_CategoryViewModel)
        {

            if (ModelState.IsValid)
            {
                Ref_CategoryViewModel.PostCategory(ref_CategoryViewModel);
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

        #region [-Edit(CategoryViewModel ref_CategoryViewModel)-]
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Edit(CategoryViewModel ref_CategoryViewModel)
        {
            if (ModelState.IsValid)
            {
                Ref_CategoryViewModel.FindCategory(ref_CategoryViewModel.CategoryId);
                Ref_CategoryViewModel.PutCategory(ref_CategoryViewModel);
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


        #region [- Delete(int id) -]
        [HttpPost]
        public ActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                Ref_CategoryViewModel.DeleteCategory(id);
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