using System.ComponentModel.DataAnnotations;
namespace Spotify1.Models
{
    public class Home
    {
        [Required]
        public string AName { get; set; }

        [Required]
        public string dob { get; set; }
        [Required]
        public string bio { get; set; }
        [Required]
        public string Sname { get; set; }
        [Required]
        public string dor { get; set; }
    }
}
