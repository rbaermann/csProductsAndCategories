using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using productsAndCategories.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace productsAndCategories.Controllers
{
    public class HomeController : Controller
    {
        private ProductsAndCategoriesContext dbContext;

        public HomeController(ProductsAndCategoriesContext context)
        {
            dbContext = context;
        }

        [HttpGet("")]
        public ViewResult Index()
        {
            ProductsAndListProducts viewModel = ListOfProductsViewModel();
            return View("Index", viewModel);
        }

        [HttpPost("newProduct")]
        public IActionResult CreateProduct(ProductsAndListProducts newPro)
        {
            if(ModelState.IsValid)
            {
                dbContext.Add(newPro.NewProduct);
                dbContext.SaveChanges();
                return RedirectToAction("Index"); //CHANGE LATER TO REDIRECT TO PRODUCT ID PAGE
            }
            ProductsAndListProducts viewModel = ListOfProductsViewModel();
            return View("Index", viewModel);
        }

        [HttpGet("categories")]
        public ViewResult AllCategories()
        {
            CategoriesAndListCategories viewModel = ListOfCategoriesViewModel();
            return View("Categories", viewModel);
        }

        [HttpPost("newCategory")]
        public IActionResult CreateCategory(CategoriesAndListCategories newCat)
        {
            if(ModelState.IsValid)
            {
                dbContext.Add(newCat.NewCategory);
                dbContext.SaveChanges();
                return RedirectToAction("AllCategories"); //CHANGE LATER TO REDIRECT TO PRODUCT ID PAGE
            }
            CategoriesAndListCategories viewModel = ListOfCategoriesViewModel();
            return View("Index", viewModel);
        }

        [HttpGet("product/{ProductId}")]
        public ViewResult ProductWithCats(int ProductId)
        {
            ProductWithCategories viewModel = ListOfCatsForProductViewModel(ProductId);
            return View("ProductWithCats", viewModel);
        }

        [HttpPost("product/edit/{ProductId}")]
        public RedirectToActionResult EditProduct(int ProductId, ProductWithCategories newCat)
        {
            newCat.Association.ProductId = ProductId;
            dbContext.Add(newCat.Association);
            dbContext.SaveChanges();
            return RedirectToAction("ProductWithCats", new{ProductId = ProductId});
        }

        [HttpGet("category/{CategoryId}")]
        public ViewResult CatWithProducts(int CategoryId)
        {
            CategoryWithProducts viewModel = ListOfProductsForCatViewModel(CategoryId);
            return View("CatWithProducts", viewModel);
        }

        [HttpPost("category/edit/{CategoryId}")]
        public RedirectToActionResult EditCategory(int CategoryId, CategoryWithProducts newPro)
        {
            newPro.Association.CategoryId = CategoryId;
            dbContext.Add(newPro.Association);
            dbContext.SaveChanges();
            return RedirectToAction("CatWithProducts", new{CategoryId = CategoryId});
        }

        public ProductsAndListProducts ListOfProductsViewModel()
        {
            ProductsAndListProducts LOP = new ProductsAndListProducts();
            LOP.ListOfProducts = dbContext.Products.ToList();
            return LOP;
        }

        public CategoriesAndListCategories ListOfCategoriesViewModel()
        {
            CategoriesAndListCategories LOC = new CategoriesAndListCategories();
            LOC.ListOfCategories = dbContext.Categories.ToList();
            return LOC;
        }

        public ProductWithCategories ListOfCatsForProductViewModel(int id)
        {
            ProductWithCategories PWC = new ProductWithCategories();
            PWC.CurrentProduct = dbContext.Products
            .Include(p => p.CategoryAssociation)
            .ThenInclude(pc => pc.Category)
            .FirstOrDefault(p => p.ProductId == id);

            PWC.ListOfCategories = dbContext.Categories
            .Include(c => c.ProductAssociation)
            .ThenInclude(cp => cp.Product)
            .Where(c => !PWC.CurrentProduct.CategoryAssociation.Select(cp => cp.Category).Contains(c))
            .ToList();
            return PWC;
        }

        public CategoryWithProducts ListOfProductsForCatViewModel(int id)
        {
            CategoryWithProducts CWP = new CategoryWithProducts();

            CWP.CurrentCategory = dbContext.Categories
            .Include(c => c.ProductAssociation)
            .ThenInclude(cp => cp.Product)
            .FirstOrDefault(c => c.CategoryId == id);

            CWP.ListOfProducts = dbContext.Products
            .Include(p => p.CategoryAssociation)
            .ThenInclude(pc => pc.Category)
            .Where(p => !CWP.CurrentCategory.ProductAssociation.Select(pc => pc.Product).Contains(p))
            .ToList();
            return CWP;
        }
    }
}
