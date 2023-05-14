using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FasadaDomaci.Models
{
    public class Nastavnik : Osoba
    {
        public string Zvanje { get; set; }
        public Tipovi Tip { get; set; }

        public Nastavnik(string jmbg, string ime, string prezime, string zvanje) : base(jmbg, ime, prezime)
        {
            Zvanje = zvanje;
        }

        public override string ToString()
        {
            return $"{Ime} {Prezime} {JMBG} {Zvanje} {Tip}";
        }
    }
}
