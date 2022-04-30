using System.ComponentModel.DataAnnotations;

namespace APIFizyo.Model
{
    public class İhtiyaç
    {

        [Key]
        public int İhtiyaçID { get; set; }
        [Required(ErrorMessage = "{0} gerekli."), Display(Name = "İhtiyaç Adı"), StringLength(20, MinimumLength = 3, ErrorMessage = "{0} en az {2} en fazla {1} karakter olabilir.")]
        public string İhtiyaçAdı { get; set; }
        [Required(ErrorMessage = "{0} gerekli."), Display(Name = "Açıklama"), StringLength(400, MinimumLength = 3, ErrorMessage = "{0} en az {2} en fazla {1} karakter olabilir.")]
        public string Açıklama { get; set; }

        [Required(ErrorMessage = "{0} Gerekli."), Display(Name = "İhtiyaçSıklığı")]
        public int İhtiyaçSıklığıID { get; set; }

        [Required(ErrorMessage = "{0} Gerekli."), Display(Name = "Kullanıcı")]
        public int KullanıcıID { get; set; }

        public Kullanıcı Kullanıcı { get; set; }
     
        public İhtiyaçSıklığı İhtiyaçSıklığı { get; set; }
    }
}
