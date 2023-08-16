namespace Blogger.Models
{
    [Table("Users")]
    public class Users
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [MaxLength(40)]
        public string Email { get; set; }

        [MaxLength(20)]
        public string Passwords { get; set; }

        [MaxLength(50)]
        public string NameSurname { get; set; }

        [MaxLength(15)]
        public string Phone { get; set; }
    }
}
