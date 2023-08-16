namespace Blogger.Models
{
    [Table("Pages")]
    public class Pages
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [MaxLength(50)]
        public string PageName { get; set; }

        [MaxLength(50)]
        public string Banners { get; set; }

        public string Explanation { get; set; }
    }
}
