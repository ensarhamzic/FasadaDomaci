using FasadaDomaci.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FasadaDomaci.Repositories
{
    public class SmerRepository
    {
        public Smer GetById(int id)
        {
            return DB.smerovi.FirstOrDefault(x => x.Id == id);
        }

        public Smer GetByNaziv(string naziv)
        {
            return DB.smerovi.FirstOrDefault(x => x.Naziv == naziv);
        }

        public List<Smer> GetAll()
        {
            return DB.smerovi;
        }

        public void Add(Smer smer)
        {
            DB.smerovi.Add(smer);
        }

        public void RemoveById(int id)
        {
            DB.smerovi.RemoveAll(x => x.Id == id);
        }
    }
}
