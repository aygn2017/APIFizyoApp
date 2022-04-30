using System.ComponentModel.DataAnnotations;

namespace APIFizyo.Model
{
    public class İhtiyaçSıklığı
    {
        [Key]
        public int İhtiyaçSıklığıID { get; set; }

        [Required(ErrorMessage = "{0} gerekli."), Display(Name = "İhtiyaç Sıklığı Adı"), StringLength(20, MinimumLength = 2, ErrorMessage = "{0} en az {2} en fazla {1} karakter olabilir.")]
        public string İhtiyaçSıklığıAdı { get; set; }
    }
}
