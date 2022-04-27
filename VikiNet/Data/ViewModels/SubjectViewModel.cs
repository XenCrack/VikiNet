using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VikiNet.Data.ViewModels
{
    public class SubjectViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Başlık")]
        [Required(ErrorMessage = "Başlık boş geçilemez")]
        public string Name { get; set; }

        [Display(Name ="Açıklama")]
        [Required(ErrorMessage = "Açıklama boş geçilemez")]
        public string Description { get; set; }

        [Display(Name = "Afiş")]
        public string ImageUrl { get; set; }

        [Display(Name ="Oluşturulma Tarihi")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [Display(Name ="Değiştirilme Tarihi")]
        public DateTime ModifiedDate { get; set; } = DateTime.Now;

        
        
    }
}






