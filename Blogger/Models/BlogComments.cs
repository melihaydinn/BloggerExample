namespace Blogger.Models
{
    [Table("BlogComments")]
    public class BlogComments
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int BlogId { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }

        [MaxLength(50)]
        public string Commenter { get; set; }
        public DateTime CommentDate { get; set; }

        [MaxLength(350)]
        public string CommentText { get; set; }

        public Blogs Blogs { get; set; }
    }
}
