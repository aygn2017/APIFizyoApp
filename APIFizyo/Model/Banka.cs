using System.ComponentModel.DataAnnotations;

namespace APIFizyo.Model
{
    public class Banka
    {
        [Key]
        public int BankaID { get; set; }

        [Required(ErrorMessage = "{0} gerekli."), Display(Name = "Banka Adı"), StringLength(30, MinimumLength = 2, ErrorMessage = "{0} en az {2} en fazla {1} karakter olabilir.")]
        public string  BankaAdı { get; set; }
    }
}
