using FasadaDomaci.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FasadaDomaci.Repositories
{
    public class StudentRepository
    {
        public Student GetByJMBG(string jmbg)
        {
            return DB.studenti.FirstOrDefault(x => x.JMBG == jmbg);
        }

        public List<Student> GetAll()
        {
            return DB.studenti;
        }

        public void Add(Student student)
        {
            DB.studenti.Add(student);
        }
    }
}
