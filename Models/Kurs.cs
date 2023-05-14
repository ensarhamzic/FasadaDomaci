using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FasadaDomaci.Models
{
    public class Kurs
    {
        public static int IdCounter = 0;
        public int Id { get; set; }
        public string Naziv { get; set; }
        public int SmerId { get; set; }
        public string ProfesorJmbg { get; set; }
        public string AsistentJmbg { get; set; }

        public Kurs(string naziv, int smerId, string profesorJmbg, string asistentJmbg)
        {
            Id = ++IdCounter;
            Naziv = naziv;
            SmerId = smerId;
            ProfesorJmbg = profesorJmbg;
            AsistentJmbg = asistentJmbg;
        }

        public override string ToString()
        {
            return $"{Id}: {Naziv}";
        }
    }
}
