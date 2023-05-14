using FasadaDomaci.Models;
using FasadaDomaci.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FasadaDomaci
{
    public class Fasada
    {
        private readonly KursRepository kursRepository;
        private readonly StudentRepository studentRepository;
        private readonly NastavnikRepository nastavnikRepository;
        private readonly SmerRepository smerRepository;
        private readonly PrijavaKursRepository prijavaKursRepository;

        public Fasada()
        {
            kursRepository = new KursRepository();
            studentRepository = new StudentRepository();
            prijavaKursRepository = new PrijavaKursRepository();
            nastavnikRepository = new NastavnikRepository();
            smerRepository = new SmerRepository();
        }

        public PrijavaKurs PrijavaNaKurs(int kursId, string studentJmbg)
        {
            var kurs = kursRepository.GetById(kursId);
            var student = studentRepository.GetByJMBG(studentJmbg);

            if (kurs == null)
                throw new Exception("Kurs ne postoji");
            if (student == null)
                throw new Exception("Student ne postoji");
            if (kurs.SmerId != student.SmerId)
                throw new Exception("Student ne pripada smeru kursa");
            if (prijavaKursRepository.GetByStudentIdAndKursId(studentJmbg, kursId) != null)
                throw new Exception("Student je vec prijavljen na kurs");

            var prijava = new PrijavaKurs(kursId, studentJmbg);
            prijavaKursRepository.Add(prijava);
            Console.WriteLine($"Student {student.Ime} {student.Prezime} se prijavio na kurs {kurs.Naziv}");
            return prijava;
        }

        public List<PrijavaKurs> VratiSvePrijave()
        {
            return prijavaKursRepository.GetAll();
        }

        public void PrikaziSvePrijave()
        {
            List<PrijavaKurs> prijave = VratiSvePrijave();
            Console.WriteLine("\n\nSve prijave:");
            foreach (var prijava in prijave)
            {
                Student st = GetStudentByJmbg(prijava.StudentJmbg);
                Kurs k = GetKursById(prijava.KursId);
                Console.WriteLine($"\n{prijava.Id}:\nKurs: {k.Naziv}\nStudent: {st.Ime} {st.Prezime}\nStatus: {(prijava.NaCekanju ? "Na čekanju" : "Potvrdjeno")}");
            }
        }

        public List<PrijavaKurs> VratiSvePrijaveNaKurs(int kursId)
        {
            var kurs = kursRepository.GetById(kursId);
            if (kurs == null)
                throw new Exception("Kurs ne postoji");
            return prijavaKursRepository.GetByKursId(kursId);
        }

        public void PrikaziSvePrijaveNaKurs(int kursId)
        {
            List<PrijavaKurs> prijave = VratiSvePrijaveNaKurs(kursId);
            Kurs k = GetKursById(kursId);
            Console.WriteLine($"\n\nSve prijave na kurs {k.Naziv}:");
            foreach (var prijava in prijave)
            {
                Student st = GetStudentByJmbg(prijava.StudentJmbg);
                Console.WriteLine($"\n{prijava.Id}:\nStudent: {st.Ime} {st.Prezime}\nStatus: {(prijava.NaCekanju ? "Na čekanju" : "Potvrdjeno")}");
            }
        }

        public List<PrijavaKurs> VratiSvePrijaveStudenta(string studentJmbg)
        {
            var student = studentRepository.GetByJMBG(studentJmbg);
            if (student == null)
                throw new Exception("Student ne postoji");
            return prijavaKursRepository.GetByStudentId(studentJmbg);
        }

        public void PrikaziSvePrijaveStudenta(string studentJmbg)
        {
            List<PrijavaKurs> prijave = VratiSvePrijaveStudenta(studentJmbg);
            Student st = GetStudentByJmbg(studentJmbg);
            Console.WriteLine($"\n\nSve prijave studenta {st.Ime} {st.Prezime}:");
            foreach (var prijava in prijave)
            {
                Kurs k = GetKursById(prijava.KursId);
                Console.WriteLine($"\n{prijava.Id}:\nKurs: {k.Naziv}\nStatus: {(prijava.NaCekanju ? "Na čekanju" : "Potvrdjeno")}");
            }
        }

        private Nastavnik DodajNastavnika(string jmbg, string ime, string prezime, string zvanje)
        {
            var nastavnik = nastavnikRepository.GetByJMBG(jmbg);
            var student = studentRepository.GetByJMBG(jmbg);
            if (nastavnik != null || student != null)
                throw new Exception("Osoba vec postoji u sistemu");
            nastavnik = new Nastavnik(jmbg, ime, prezime, zvanje);
            return nastavnik;
        }

        public Nastavnik DodajProfesora(string jmbg, string ime, string prezime, string zvanje)
        {
            Nastavnik nastavnik = DodajNastavnika(jmbg, ime, prezime, zvanje);
            nastavnik.Tip = Tipovi.PROFESOR;
            nastavnikRepository.Add(nastavnik);
            Console.WriteLine($"Dodat je profesor {nastavnik.Ime} {nastavnik.Prezime}");
            return nastavnik;
        }

        public Nastavnik DodajAsistenta(string jmbg, string ime, string prezime, string zvanje)
        {
            Nastavnik nastavnik = DodajNastavnika(jmbg, ime, prezime, zvanje);
            nastavnik.Tip = Tipovi.ASISTENT;
            nastavnikRepository.Add(nastavnik);
            Console.WriteLine($"Dodat je asistent {nastavnik.Ime} {nastavnik.Prezime}");
            return nastavnik;
        }

        public Student DodajStudenta(string jmbg, string ime, string prezime, string brojIndeksa, int smerId)
        {
            var nastavnik = nastavnikRepository.GetByJMBG(jmbg);
            var student = studentRepository.GetByJMBG(jmbg);
            if (student != null || nastavnik != null)
                throw new Exception("Osoba vec postoji u sistemu");
            var smer = smerRepository.GetById(smerId);
            if (smer == null)
                throw new Exception("Smer ne postoji");
            student = new Student(jmbg, ime, prezime, brojIndeksa, smerId);
            studentRepository.Add(student);
            Console.WriteLine($"Dodat je student {student.Ime} {student.Prezime}");
            return student;
        }

        public Smer DodajSmer(string naziv, string oznaka)
        {
            var smer = smerRepository.GetByNaziv(naziv);
            if (smer != null)
                throw new Exception("Smer vec postoji");
            smer = new Smer(naziv, oznaka);
            smerRepository.Add(smer);
            Console.WriteLine($"Dodat je smer {smer.Naziv}: {smer.Oznaka}");
            return smer;
        }

        public Kurs DodajKurs(string naziv, int smerId, string profesorJmbg, string asistentJmbg)
        {
            var kurs = kursRepository.GetByNaziv(naziv);
            if (kurs != null)
                throw new Exception("Kurs vec postoji");
            var smer = smerRepository.GetById(smerId);
            if (smer == null)
                throw new Exception("Smer ne postoji");
            var profesor = nastavnikRepository.GetProfesorByJMBG(profesorJmbg);
            if (profesor == null)
                throw new Exception("Nastavnik ne postoji ili nije profesor");
            var asistent = nastavnikRepository.GetAsistentByJMBG(asistentJmbg);
            if (asistent == null)
                throw new Exception("Nastavnik ne postoji ili nije asistent");
            kurs = new Kurs(naziv, smerId, profesorJmbg, asistentJmbg);
            kursRepository.Add(kurs);
            Console.WriteLine($"Dodat je kurs {kurs.Naziv}");
            return kurs;
        }

        public Student GetStudentByJmbg(string jmbg)
        {
            return studentRepository.GetByJMBG(jmbg);
        }

        public Kurs GetKursById(int id)
        {
            return kursRepository.GetById(id);
        }

    }
}
