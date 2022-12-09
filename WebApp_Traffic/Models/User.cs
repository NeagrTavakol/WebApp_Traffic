using System.ComponentModel.DataAnnotations;

namespace WebApp_Traffic.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public ulong National_Code { get; set; }

        public ICollection<Traffic> Traffics { get; set; }
    }
}
