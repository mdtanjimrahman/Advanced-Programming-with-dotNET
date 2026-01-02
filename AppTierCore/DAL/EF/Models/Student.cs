using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.EF.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Cgpa { get; set; }
    }
}
