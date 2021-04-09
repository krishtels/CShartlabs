using System;

namespace HumanProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Human first = new Human("Borisova", "Natalia", "Aleksandrovna", new DateTime(1976, 1, 12), Genders.Female, Educations.University);
            ITStudent prog = new ITStudent("Dedow", "Kole", "Anatolievich", Student.Universities.BSUIR, Student.Degrees.Graduate, new DateTime(2000, 12, 1), Genders.Male, Educations.HighSchool);
            Philologist philo = new Philologist("Tutov", "Pasha", "-");
            Student stud = new ArtStudent("Fulloc", "Nasa", "-");
            Student programmerAnother = new ITStudent("Ded", "Lesha", "Anatolievich", Student.Universities.BSU, Student.Degrees.Postgraduate, new DateTime(1999, 1, 16), Genders.Male, Educations.University);
            Student justHuman = new Philologist("Goga", "Faina", "-");
            prog.SetPerformance();
            prog.PassSession();
            Console.WriteLine(prog);
            philo.SetPerformance();
            philo.PassSession();
            Console.WriteLine(philo);
            Console.WriteLine(philo.SocialSkills);
            Console.WriteLine(stud);
            stud.WorkHard();
            programmerAnother.WorkHard();
            justHuman.WorkHard();
            Console.WriteLine(first);
            Console.ReadKey();
        }
    }
}
