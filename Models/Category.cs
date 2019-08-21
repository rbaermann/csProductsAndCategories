using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace productsAndCategories
{
    public class Category
    {
        [Required]
        public int CategoryId {get; set;}

        [Required]
        [MinLength(2)]
        public string Name {get; set;}

        public List<Association> ProductAssociation {get; set;}

        public DateTime CreatedAt {get; set;} = DateTime.Now;

        public DateTime UpdatedAt {get; set;} = DateTime.Now;
    }
}