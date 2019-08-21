using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace productsAndCategories
{
    public class ProductsAndListProducts
    {
        public Product NewProduct {get; set;}
        public List<Product> ListOfProducts {get; set;}
    }
}