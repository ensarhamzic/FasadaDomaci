using FasadaDomaci.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FasadaDomaci
{
    // Ovde se nalaze svi podaci koji su potrebni za rad aplikacije, poput baze podataka
    // Radi jednostavnosti su svi podaci u memoriji, kao staticke liste
    // ali bi u realnom slucaju svakako bili u bazi
    public static class DB
    {
        public static List<Smer> smerovi = new();
        public static List<Student> studenti = new();
        public static List<Nastavnik> nastavnici = new();
        public static List<PrijavaKurs> prijave = new();
        public static List<Kurs> kursevi = new();
    }
}
