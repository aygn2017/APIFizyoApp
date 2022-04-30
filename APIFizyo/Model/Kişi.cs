
using APIFizyo.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIFizyo.Model
{
    public class Kişi
    {
        [Key]
        public int KişiID { get; set; }

        [Required(ErrorMessage = "{0} Gerekli"), Display(Name = "Kullanıcı")]
        public int KullanıcıID { get; set; }

        [Required(ErrorMessage = "{0} Gerekli"), Display(Name = "Ad"), StringLength(40, MinimumLength = 2, ErrorMessage = ("{0} en az {2} en fazla {1} karakter olabilir"))]
        public string AdVeİkinciAd { get; set; }

        [Required(ErrorMessage = "{0} Gerekli"), Display(Name = "Soyad"), StringLength(20, MinimumLength = 2, ErrorMessage = ("{0} en az {2} en fazla {1} karakter olabilir"))]
        public string Soyad { get; set; }

        [Required(ErrorMessage = "{0} Gerekli"), Display(Name = "Doğum Tarihi"), DataType(DataType.Date), Column(TypeName = "Date"), DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DogumTarihi { get; set; }

        [NotMapped]
        public int Yaş
        {
            get
            {
                DateTime dogumGunu = DogumTarihi;
                int yas = DateTime.Today.Year - dogumGunu.Year;

                if (dogumGunu > DateTime.Today.AddYears(-yas))
                {
                    yas--;
                }
                return yas;
            }
        }

        [NotMapped]
        public string TamAdı
        {
            get
            {
                return AdVeİkinciAd + " " + Soyad;
            }
        }


        [Required(ErrorMessage = "{0} Gerekli"), Display(Name = "Cinsiyet")]
        public int CinsiyetID { get; set; }

        [Required(ErrorMessage = "{0} Gerekli"), Display(Name = "İl")]
        public int İlID { get; set; }

        public Kullanıcı Kullanıcı { get; set; }
        public Cinsiyet Cinsiyet { get; set; }
        public İl İl { get; set; }
    }
}
