using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eugene.Models
{
    public class News
    {
        public string Title { get; set; }
        public string Story { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Author { get; set; }
    }
}
