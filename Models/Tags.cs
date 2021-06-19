using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace yad2.Models
{
    public class Tags
    {
        [Key]
        [Required(ErrorMessage = "please enter the tag id")]
        public int tagId { get; set; }

        [Required(ErrorMessage = "please enter the tag Name")]
        public String tageName { get; set; }

        public String tagIcon { get; set; }
    }
}
