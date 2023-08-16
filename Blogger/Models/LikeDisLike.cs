namespace Blogger.Models
{
    [Table("LikeDisLike")]
    public class LikeDisLike
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int BlogId { get; set; }
        public string ipAdresi { get; set; }
        public bool Status { get; set; }
        public Blogs Blogs { get; set; }

        // Tek'e Tek İlişli
        // One to One 
    }
}
