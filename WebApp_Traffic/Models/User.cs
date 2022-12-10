using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApp_Traffic.Models
{
    public class User
    {
        [Key]
        [DisplayName("کد یکتا")]
        public int Id { get; set; }
        [Required]
        [DisplayName("نام")]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("نام خانوادگی")]
        public string LastName { get; set; }
        [Required]
        [DisplayName("کد ملی")]
        public ulong National_Code { get; set; }

        public ICollection<Traffic> Traffics { get; set; }
    }
}
