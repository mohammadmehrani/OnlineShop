using SinglePage.Models.DomainModels.DTO.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SinglePage.Models.ViewModels
{
    public class ProductViewModel
    {
        #region [- ctor -]
        public ProductViewModel()
        {
            Ref_ProductRepository = new DomainModels.POCO.ProductRepository();
           
        }
        #endregion

        #region [- props -]

        #region [- props for class -]
        public Models.DomainModels.POCO.ProductRepository Ref_ProductRepository { get; set; }

        #endregion

        #region [- props for Model -]
        public int ProductId { get; set; }
        public int? ProductCode { get; set; }
        public string ProductName { get; set; }
        public int? Amount { get; set; }
        public decimal? Price { get; set; }
        public decimal? UnitPrice { get; set; }

        public int? CategoryId{ get; set; }

        
        #endregion

        #endregion

        #region [- Methods -]
        #region [- GetProduct() -]
        public List<DomainModels.DTO.EF.product> GetProduct()
        {
            var products = Ref_ProductRepository.Select();
            return products;
        }
        #endregion

        #region [- PostProduct(ProductViewModel ref_ProductViewModel) -]
        public void PostProduct(ProductViewModel ref_ProductViewModel)
        {
            DomainModels.DTO.EF.product ref_Product = new DomainModels.DTO.EF.product();


            ref_Product.CategoryId = ref_ProductViewModel.CategoryId;
            ref_Product.ProductName = ref_ProductViewModel.ProductName;
            ref_Product.ProductCode = ref_ProductViewModel.ProductCode;
            ref_Product.UnitPrice = ref_ProductViewModel.UnitPrice;
            ref_Product.Amount = ref_ProductViewModel.Amount;
               
       
            Ref_ProductRepository.Insert(ref_Product);
        }
        #endregion

        #region [- GetCategoryFields() -]
        public dynamic GetCategoryFields()
        {
            var categories = Ref_ProductRepository.SelectCategoryFields();
            return categories;
        }
        #endregion

       
        #region [- FindProduct(int id) -]
        public ProductViewModel FindProduct(int? id)
        {
            var ref_product = Ref_ProductRepository.FindProduct(id);
            ProductViewModel ref_productViewModel = new ProductViewModel();
            ref_productViewModel.ProductCode = ref_product.ProductCode;
            ref_productViewModel.ProductName = ref_product.ProductName;
            ref_productViewModel.Amount = ref_product.Amount;
            //ref_productViewModel.Price = ref_product.Price;
            ref_productViewModel.UnitPrice = ref_product.UnitPrice;
            ref_productViewModel.CategoryId = ref_product.CategoryId;
            ref_productViewModel.ProductId = ref_product.ProductId;

            return ref_productViewModel;
        }
        #endregion
        #region [- UpdateProduct(ProductViewModel ref_ProductViewModel) -]
        public void UpdateProduct(ProductViewModel ref_ProductViewModel)
        {
            product ref_Product = new product();
            ref_Product.ProductCode = ref_ProductViewModel.ProductCode;
            ref_Product.ProductName = ref_ProductViewModel.ProductName;
            ref_Product.Amount = ref_ProductViewModel.Amount;
            //ref_Product.Price = ref_ProductViewModel.Price;
            ref_Product.UnitPrice = ref_ProductViewModel.UnitPrice;
            ref_Product.CategoryId = ref_ProductViewModel.CategoryId;
            ref_Product.ProductId = ref_ProductViewModel.ProductId;

            Ref_ProductRepository.Update(ref_Product);
        }

        #endregion

        #region [- DeleteProduct(int id) -]
        public void DeleteProduct(int id)
        {
            Ref_ProductRepository.Delete(id);
        }
        #endregion
        #endregion
    }
}