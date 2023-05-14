using FasadaDomaci.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FasadaDomaci.Repositories
{
    public class PrijavaKursRepository
    {
        public PrijavaKurs GetById(int id)
        {
            return DB.prijave.FirstOrDefault(x => x.Id == id);
        }

        public List<PrijavaKurs> GetAll()
        {
            return DB.prijave;
        }

        public void Add(PrijavaKurs prijava)
        {
            DB.prijave.Add(prijava);
        }

        public void RemoveById(int id)
        {
            DB.prijave.RemoveAll(x => x.Id == id);
        }

        public List<PrijavaKurs> GetByStudentId(string studentJmbg)
        {
            return DB.prijave.Where(x => x.StudentJmbg == studentJmbg).ToList();
        }

        public List<PrijavaKurs> GetByKursId(int kursId)
        {
            return DB.prijave.Where(x => x.KursId == kursId).ToList();
        }

        public PrijavaKurs GetByStudentIdAndKursId(string studentJmbg, int kursId)
        {
            return DB.prijave.FirstOrDefault(x => 
                x.StudentJmbg == studentJmbg && 
                x.KursId == kursId
            );
        }
    }
}
