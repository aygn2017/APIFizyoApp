using System.ComponentModel.DataAnnotations;

namespace APIFizyo.Model
{
    public class İl
    {
        [Key]
        public int İlID { get; set; }

        [Required(ErrorMessage = "{0} gerekli."), Display(Name = "İl Adı"), StringLength(20, MinimumLength = 3, ErrorMessage = "{0} en az {2} en fazla {1} karakter olabilir.")]
        public string İlAdı { get; set; }

    }
}
