using System.ComponentModel.DataAnnotations;

namespace APIFizyo.Model
{
    public class MedeniDurum
    {
        [Key]
        public int MedeniDurumID { get; set; }


        [Required(ErrorMessage = "{0} gerekli."), Display(Name = "Medeni Durum Adı"), StringLength(20, MinimumLength = 2, ErrorMessage = "{0} en az {2} en fazla {1} karakter olabilir.")]
        public string  MedeniDurumAdı { get; set; }


       
    }
}
