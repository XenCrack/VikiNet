using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VikiNet.Data.Base;

namespace VikiNet.Models
{
    public class Subject : EntityBase
    {
        

        [Required(ErrorMessage ="Konu başlığı boş bırakılamaz")]
        [Column("Name", TypeName = "varchar(50)")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Konu başlığı boş bırakılamaz")]
        [Column("SubjectName", TypeName = "text")]
        
        public string SubjectName { get; set; }

        [Required]
        [Column("createddate", TypeName = "datetime")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [Column("modifieddate", TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }

        public int SubjectTypeId { get; set; }

        [ForeignKey(nameof(SubjectTypeId))]
        public SubjectType SubjectType { get; set; }




    }
}
