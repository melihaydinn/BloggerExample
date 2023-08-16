namespace Blogger.Models
{
    [Table("Projects")]
    public class Projects
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [MaxLength(50)]
        public string ProjectName { get; set; }

        [MaxLength(50)]
        public string Images { get; set; }

        [MaxLength(350)]
        public string Explanation { get; set; }
    }
}
