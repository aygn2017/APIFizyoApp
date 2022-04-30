using System.ComponentModel.DataAnnotations;

namespace APIFizyo.Model
{
    public class Hesap
    {
        [Key]
        public int HesapID{ get; set; }
        [Required(ErrorMessage ="{0} gerekli"), Display(Name ="Banka")]
        public int BankaID { get; set; }
        [Required(ErrorMessage = "{0} gerekli"), Display(Name = "Kullanıcı")]
        public int KullanıcıID { get; set; }
        [Required(ErrorMessage = "{0} gerekli"), Display(Name = "Ad Soyad"),StringLength(50, MinimumLength = 2, ErrorMessage = "{0} en az {2} en fazla {1} karakterden oluşabilir.")]
        public string HesapSahibiTamAdı{ get; set; }
        [Required(ErrorMessage = "{0} gerekli"), Display(Name = "Bakiye")]
        public double Bakiye { get; set; }
        //[Required(ErrorMessage = "{0} gerekli"), Display(Name = "IBAN"), StringLength(26,ErrorMessage = "{0} en az {1} karakterden oluşmalıdır.")]
        public string IBAN { get; set; }
        [Required(ErrorMessage = "{0} gerekli"), Display(Name = "Hesap Numarası"), StringLength(32, MinimumLength = 2, ErrorMessage = "{0} en az {2} en fazla {1} karakterden oluşabilir.")]
        public string HesapNo { get; set; }
        [Required(ErrorMessage = "{0} gerekli"), Display(Name = "Ad Soyad"), StringLength(32, MinimumLength = 2, ErrorMessage = "{0} en az {2} en fazla {1} karakterden oluşabilir.")]
        public string ŞubeKodu { get; set; }

        public Kullanıcı Kullanıcı { get; set; }
        public Banka Banka { get; set; }


    }
}
