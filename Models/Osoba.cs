using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FasadaDomaci.Models
{
    public class Osoba
    {
        public string JMBG { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public Osoba(string jmbg, string ime, string prezime)
        {
            JMBG = jmbg;
            Ime = ime;
            Prezime = prezime;
        }
        public override string ToString()
        {
            return $"{Ime} {Prezime} {JMBG}";
        }
    }
}
