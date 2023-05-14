using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FasadaDomaci.Models
{
    public class Smer
    {
        public static int IdCounter = 0;
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Oznaka { get; set; }
        public Smer(string naziv, string oznaka)
        { 
            Id = ++IdCounter;
            Naziv = naziv;
            Oznaka = oznaka;
        }
        public override string ToString()
        {
            return $"{Id}: {Naziv}";
        }
    }
}
