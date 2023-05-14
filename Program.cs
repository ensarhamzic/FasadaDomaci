using FasadaDomaci;
using FasadaDomaci.Models;

// Koristimo samo fasadu, koja povezuje vise razlicitih repozitorijuma
// i omogucava nam da radimo sa njima na jednostavan nacin
// bez da moramo da znamo kako su implementirani
// Try i Catch blokovi su ovde zato sto neke od metoda fasada
// mogu da izbace izuzetak, pa da ne bi aplikacija pukla
try
{
    Fasada fasada = new Fasada();
    Nastavnik profesor = fasada.DodajProfesora("1234567890123", "Pera", "Peric", "Docent");
    Nastavnik asistent = fasada.DodajAsistenta("1234567890124", "Mika", "Mikic", "Asistent");
    Smer smer = fasada.DodajSmer("Softversko inzenjerstvo", "SI");
    Smer smer2 = fasada.DodajSmer("Matematika", "MA");
    Student student = fasada.DodajStudenta("1234567890125", "Zika", "Zikic", "036-037/20", smer.Id);
    Kurs kurs = fasada.DodajKurs("Informacioni sistemi", smer.Id, profesor.JMBG, asistent.JMBG);
    Kurs kurs2 = fasada.DodajKurs("Komunikacija covek - racunar", smer.Id, profesor.JMBG, asistent.JMBG);
    PrijavaKurs prijavaKurs = fasada.PrijavaNaKurs(kurs.Id, student.JMBG);
    PrijavaKurs prijavaKurs2 = fasada.PrijavaNaKurs(kurs2.Id, student.JMBG);

    //fasada.PrikaziSvePrijave();
    //fasada.PrikaziSvePrijaveKursa(kurs.Id);
    fasada.PrikaziSvePrijaveStudenta(student.JMBG);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
