using System.ComponentModel.DataAnnotations;

namespace APIFizyo.Model
{
    public class İlçe
    {
        [Key]
        public int İlçeID { get; set; }
        [Required(ErrorMessage = "{0} gerekli."), Display(Name = "İlçe Adı"), StringLength(20, MinimumLength = 3, ErrorMessage = "{0} en az {2} en fazla {1} karakter olabilir.")]
        public string İlçeAdı { get; set; }
        [Required(ErrorMessage = "{0} Gerekli."), Display(Name = "İl")]
        public int İlID { get; set; }

        public İl İl { get; set; }

    }
}
