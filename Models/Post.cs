using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace yad2.Models
{
    public class Post
    {
        [Key]
        public int PostID { get; set; }

        public User Publisher { get; set; }

        public List<Tags> Tags { get; set; }

        //TODO: Change to Product entity
        public Product Product { get; set; }

        // Save the urls as a string formatted with ; as a seperator
        public string PicUrls { get; set; }

        public DateTime PublishDate { get; set; }
    }
}
