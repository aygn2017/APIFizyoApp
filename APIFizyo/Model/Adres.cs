using System.ComponentModel.DataAnnotations;

namespace APIFizyo.Model
{
    public class Adres
    {
        [Key]
        public int AdresID { get; set; }

        [Required(ErrorMessage = "{0} Gerekli."), Display(Name = "Kullanıcı")]
        public int KullanıcıID { get; set; }

        [Required(ErrorMessage = "{0} gerekli."), Display(Name = "Adres Adı"), StringLength(20, MinimumLength = 2, ErrorMessage = "{0} en az {2} en fazla {1} karakter olabilir.")]
        public string  AdresAdı { get; set; }

        [Required(ErrorMessage = "{0} gerekli."), Display(Name = "Adres Detayı"), StringLength(200, MinimumLength = 2, ErrorMessage = "{0} en az {2} en fazla {1} karakter olabilir.")]
        public string  AdresDetay { get; set; }

        [StringLength(200, MinimumLength = 2, ErrorMessage = "{0} en az {2} en fazla {1} karakter olabilir.")]
        public string PostaKodu { get; set; }

        [Required(ErrorMessage = "{0} Gerekli."), Display(Name = "İlçe")]
        public int İlçeID { get; set; }










        public İlçe İlçe { get; set; }
        public Kullanıcı Kullanıcı { get; set; }
    }
}
