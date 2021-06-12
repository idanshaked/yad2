using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace yad2.Models
{
    public class Product
    {
        [Key]
        public String ProductId { set; get; }

        public String description { set; get; }
        public int price { set; get; }

        // remove after add post model
        /*public Post post { set; get; }*/
    }
}
