using Microsoft.EntityFrameworkCore;

namespace Blogger.Models
{
    public class DatabaseContext:DbContext
    {
        public DbSet<BlogComments> BlogComments { get; set; }
        public DbSet<Blogs> Blogs { get; set; }
        public DbSet<LikeDisLike> LikeDisLike { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Projects> Projects { get; set; }
        public DbSet<Pages> Pages  { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=SA103HOCA\SQLEXPRESS;Database=CoreBlogData;User Id=sa;Password=1;");

            //optionsBuilder.UseSqlServer(@"Server=myServerAddress;Database=myDataBase;Trusted_Connection=True;");
        }


    }
}
