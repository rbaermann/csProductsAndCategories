using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace productsAndCategories
{
    public class CategoryWithProducts
    {
        public Category CurrentCategory {get; set;}

        public List<Product> ListOfProducts {get; set;}

        public Association Association {get; set;}
    }
}