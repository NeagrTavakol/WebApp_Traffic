using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApp_Traffic.Models
{
    public class Traffic
    {
        [Key]
        [DisplayName("آیدی تردد")]
        public int Id_Traffic { get; set; }
        [DisplayName("نوع تردد")]
        public int Type_Traffic { get; set; }
        [DisplayName("تاریخ و تایم")]
        public DateTime EntryOrOut_Time { get; set; }
        [DisplayName("کد یکتا")]
        public int userid { get; set; }
        public User user { get; set; }
    }
}
