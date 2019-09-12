using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloggingDemo
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    namespace Entities
    {
        public class Blog
        {
            // "Primary Key", by convention
            public int BlogId { get; set; }
            public string Name { get; set; }

            // Navigation Property
            public virtual ICollection<Post> Posts { get; set; }
        }

        public class Post
        {
            // "Primary Key", by convention
            public int PostId { get; set; }
            public string Title { get; set; }
            public string Content { get; set; }
            public int BlogId { get; set; }
            // Navigation Property
            public virtual Blog Blog { get; set; }
        }
    }
}
