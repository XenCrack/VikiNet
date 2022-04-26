using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VikiNet.Data.Base;

namespace VikiNet.Models
{
    public class SubjectType : EntityBase
    {
        
        
        public string SubjectName { get; set; }

        public List<Subject> Subjects { get; set; }

    }
}
