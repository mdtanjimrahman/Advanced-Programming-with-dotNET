using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.EF.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]  
        [Column(TypeName = "varchar")]
        public string Name { get; set; }
        
        [Required]
        public double Cgpa { get; set; }
    }
}
