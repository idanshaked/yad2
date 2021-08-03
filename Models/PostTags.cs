using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace yad2.Models
{
    public class PostTags
    {
        public int PostsPostID { get; set; }
        public Post post { get; set; }

        public int TagstagId { get; set; }
        public Tags Tags { get; set; }
    }
}
