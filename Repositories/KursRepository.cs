using FasadaDomaci.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FasadaDomaci.Repositories
{
    public class KursRepository
    {
        public Kurs GetById(int id)
        {
            return DB.kursevi.FirstOrDefault(x => x.Id == id);
        }

        public Kurs GetByNaziv(string naziv)
        {
            return DB.kursevi.FirstOrDefault(x => x.Naziv == naziv);
        }

        public List<Kurs> GetAll()
        {
            return DB.kursevi;
        }

        public void Add(Kurs kurs)
        {
            DB.kursevi.Add(kurs);
        }

        public void RemoveById(int id)
        {
            DB.kursevi.RemoveAll(x => x.Id == id);
        }

        public List<Kurs> GetBySmerId(int smerId)
        {
            return DB.kursevi.Where(x => x.SmerId == smerId).ToList();
        }
    }
}
