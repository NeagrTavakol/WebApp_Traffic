using System.ComponentModel.DataAnnotations;

namespace WebApp_Traffic.Models
{
    public class Traffic
    {
        [Key]
        public int Id_Traffic { get; set; }
        public int Type_Traffic { get; set; }
        public DateTime EntryOrOut_Time { get; set; }
        public User user { get; set; }
    }
}
