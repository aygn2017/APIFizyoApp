using System.ComponentModel.DataAnnotations;

namespace APIFizyo.Model
{
    public class MedeniBilgi
    {
        [Key]
        public int MedeniBilgiID { get; set; }

        [Required(ErrorMessage = "{0} gerekli."), Display(Name = "Kullanıcı")]
        public int KullanıcıID { get; set; }

        [Required(ErrorMessage = "{0} gerekli."), Display(Name = "Medeni Durum")]
        public int MedeniDurumID { get; set; }

        [Required(ErrorMessage = "{0} gerekli."), Display(Name = "Çocuk Sayısı")]
        public int ÇocukSayısı { get; set; }

        public Kullanıcı Kullanıcı { get; set; }

        public MedeniDurum MedeniDurum { get; set; }


    }
}
