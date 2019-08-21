using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace productsAndCategories
{
    public class ProductWithCategories
    {
        public Product CurrentProduct {get; set;}

        public List<Category> ListOfCategories {get; set;}

        public Association Association {get; set;}
    }
}