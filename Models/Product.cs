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
        public int ProductID { get; set; }
        public String description { set; get; }
        public int price { set; get; }
        public int PostID { get; set; }

        public Post Post { get; set; }

        public int StoreID { get; set; }

        public Store store { get; set; }
    }
}
