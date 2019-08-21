using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace productsAndCategories
{
    public class Association
    {
        [Required]
        public int AssociationId {get; set;}

        public int ProductId {get; set;}

        public int CategoryId {get; set;}

        public Product Product {get; set;}

        public Category Category {get; set;}
    }
}