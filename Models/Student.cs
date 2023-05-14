using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FasadaDomaci.Models
{
    public class Student : Osoba
    {
        public string BrojIndeksa { get; set; }
        public int SmerId { get; set; }
        public Student(string jmbg, string ime, string prezime, string brojIndeksa, int smerId) : base(jmbg, ime, prezime)
        {
            BrojIndeksa = brojIndeksa;
            SmerId = smerId;
        }
        public override string ToString()
        {
            return $"{Ime} {Prezime} {JMBG} {BrojIndeksa}";
        }
    }
}
