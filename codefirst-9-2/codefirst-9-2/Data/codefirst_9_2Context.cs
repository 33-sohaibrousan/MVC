using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace codefirst_9_2.Data
{
    public class codefirst_9_2Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public codefirst_9_2Context() : base("name=codefirst_9_2Context")
        {
        }

        public System.Data.Entity.DbSet<codefirst_9_2.Models.Course> Courses { get; set; }

        public System.Data.Entity.DbSet<codefirst_9_2.Models.Student> Students { get; set; }

        public System.Data.Entity.DbSet<codefirst_9_2.Models.StudentCource> StudentCources { get; set; }
    }
}
