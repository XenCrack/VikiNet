﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VikiNet.Models
{
    public class SubjectType 
    {
        
        
        [Required]
        [Column("SubjectType", TypeName = "varchar(50)")]
        [StringLength(50)]
        public string SubjectTypeName{ get; set; }

        public List<Subject> Subjects { get; set; }

        

        


    }
}
