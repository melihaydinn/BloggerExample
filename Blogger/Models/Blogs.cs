namespace Blogger.Models
{
    [Table("Blogs")]
    public class Blogs
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [MaxLength(50)]
        public string BlogName { get; set; }

        [MaxLength(50)]
        public string Images { get; set; }
        public string Explanation { get; set; }
        public DateTime PublishDate { get; set; }
        public List<LikeDisLike> LikeDisLike { get; set; }
        public List<BlogComments> BlogComments { get; set; }
       
        // Tek'e Çok ilişki
        // One to Many

    }
}
