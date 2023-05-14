using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FasadaDomaci.Models
{
    public class PrijavaKurs
    {
        public static int IdCounter = 0;
        public int Id { get; set; }
        public int KursId { get; set; }
        public string StudentJmbg { get; set; }
        public bool NaCekanju { get; set; } = true;
        public PrijavaKurs(int kursId, string studentJmbg)
        {
            Id = ++IdCounter;
            KursId = kursId;
            StudentJmbg = studentJmbg;
        }
        public override string ToString()
        {
            return $"{Id}: {KursId} {StudentJmbg} - {(NaCekanju ? "Na čekanju" : "Potvrdjeno")}";
        }
    }
}
