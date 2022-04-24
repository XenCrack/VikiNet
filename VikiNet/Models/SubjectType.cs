using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VikiNet.Data.Base;

namespace VikiNet.Models
{
    public class SubjectType : EntityBase
    {
        
        
        [Required]
        [Column("SubjectType", TypeName = "varchar(50)")]
        [StringLength(50)]
        public string SubjectTypeName{ get; set; }

        public List<Subject> Subjects { get; set; }

        

        


    }
}
