using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace yad2.Models
{
    public class Store
    {
        [Key]
        [Required(ErrorMessage = "please enter the store id")]
        public int storeId { get; set; }

        [Required(ErrorMessage = "please enter the store Name")]
        public String storeName{ get; set; }


        [Required(ErrorMessage = "please enter the store lat")]
        public double lat { get; set; }


        [Required(ErrorMessage = "please enter the store lng")]
        public double lng { get; set; }

        [Required(ErrorMessage = "please enter the store address")]
        public string address { get; set; }
 
        public string Description { get; set; }
 
    }
}
