using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VikiNet.Data.Base;

namespace VikiNet.Models
{
    public class Subject : EntityBase
    {
        

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public int SubjectTypeId { get; set; }

        [ForeignKey(nameof(SubjectTypeId))]
        public SubjectType SubjectType { get; set; }

        
    }
}
