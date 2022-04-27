using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VikiNet.Data.Base;

namespace VikiNet.Models
{
    public class SubjectType : EntityBase
    {
        
        [Display(Name ="Konu Türü")]
        [Required(ErrorMessage ="Tür Boş Bırakılamaz")]
        public string SubjectName { get; set; }

        

    }
}
