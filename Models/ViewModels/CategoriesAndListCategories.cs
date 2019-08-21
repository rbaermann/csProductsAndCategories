using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace productsAndCategories
{
    public class CategoriesAndListCategories
    {
        public Category NewCategory {get; set;}
        public List<Category> ListOfCategories {get; set;}
    }
}