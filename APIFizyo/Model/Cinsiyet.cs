using System.ComponentModel.DataAnnotations;

namespace APIFizyo.Model
{
    public class Cinsiyet
    {
        [Key]
        public int CinsiyetID { get; set; }

        [Required(ErrorMessage = "{0} gerekli."), Display(Name = "Cinsiyet Adı"), StringLength(20, MinimumLength = 3, ErrorMessage = "{0} en az {2} en fazla {1} karakter olabilir.")]
        public string CinsiyetAdı { get; set; }
    }
}
