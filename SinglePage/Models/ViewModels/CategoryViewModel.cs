using SinglePage.Models.DomainModels.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SinglePage.Models.ViewModels
{
    public class CategoryViewModel
    {
        #region [- ctor -]
        public CategoryViewModel()
        {
            Ref_CategoryRepository = new DomainModels.POCO.CategoryRepository();
           
        }
        #endregion

        #region [- props -]

        #region [- props for class -]
        public Models.DomainModels.POCO.CategoryRepository Ref_CategoryRepository { get; set; }
       
        #endregion

        #region [- props for Model -]
        public int CategoryId { get; set; }
        public int? Code { get; set; }
        public string Title { get; set; }
        #endregion

        #endregion

        #region [- Methods -]
        #region [- GetCategory() -]
        public List<Models.DomainModels.DTO.EF.Category> GetCategory()
        {
            var categories = Ref_CategoryRepository.Select();
            return categories;
        }
        #endregion

        #region [- PostCategory(CategoryViewModel ref_CategoryViewModel) -]
        public void PostCategory(CategoryViewModel ref_CategoryViewModel)
        {
            DomainModels.DTO.EF.Category ref_Category = new DomainModels.DTO.EF.Category();
            ref_Category.CategoryId = ref_CategoryViewModel.CategoryId;
            ref_Category.Code = ref_CategoryViewModel.Code;
            ref_Category.Title = ref_CategoryViewModel.Title;
            Ref_CategoryRepository.Insert(ref_Category);
        }
        #endregion

        #region [- FindCategory(int id) -]
        public CategoryViewModel FindCategory(int? Id)
        {
            var ref_category = Ref_CategoryRepository.FindCategory(Id);
            CategoryViewModel ref_categoryViewModel = new CategoryViewModel();
            ref_categoryViewModel.CategoryId = ref_category.CategoryId;
            ref_categoryViewModel.Code = ref_category.Code;
            ref_categoryViewModel.Title = ref_category.Title;

            return ref_categoryViewModel;
        }
        #endregion

        #region [- PutCategory(CategoryViewModel ref_CategoryViewModel) -]
        public void PutCategory(CategoryViewModel ref_CategoryViewModel)
        {
            DomainModels.DTO.EF.Category ref_Category = new DomainModels.DTO.EF.Category();
            ref_Category.CategoryId = ref_CategoryViewModel.CategoryId;
            ref_Category.Code = ref_CategoryViewModel.Code;
            ref_Category.Title = ref_CategoryViewModel.Title;
            Ref_CategoryRepository.Update(ref_Category);
        }
        #endregion

        #region [- DeleteCategory(int id) -]
        public void DeleteCategory(int id)
        {
            Ref_CategoryRepository.Delete(id);
        } 
        #endregion
        #endregion
    }
}