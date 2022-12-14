using System;
using System.Collections.Generic;
using System.Text;

namespace LocalDatabase.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FechaNacimiento { get; set; }
        public int Nota { get; set; }
        public string Aprobado { get; set; }
    }
}
