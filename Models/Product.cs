using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace productsAndCategories
{
    public class Product
    {
        [Required]
        public int ProductId {get; set;}

        [Required]
        [MinLength(2)]
        public string Name {get; set;}

        [Required]
        [MinLength(20)]
        public string Description {get; set;}

        [Required]
        public decimal Price {get; set;}

        public List<Association> CategoryAssociation {get; set;}

        public DateTime CreatedAt {get; set;} = DateTime.Now;

        public DateTime UpdatedAt {get; set;} = DateTime.Now;
    }
}