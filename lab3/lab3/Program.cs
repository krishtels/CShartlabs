using System;

namespace HumanProject
{
    enum Genders
    {
        Male,
        Female
    }
    enum Educations
    {
        PrimarySchool,
        HighSchool,
        University
    }
    class Program
    {
        static void Main(string[] args)
        {
            Human father = new Human("Borisov", "Vasilii", "Aleksandrovich");
            father.Weight = 74;
            father.Height = 1.9;
            Console.WriteLine(father.IndexOfBody());
            Human mother = new Human("Borisova", "Natalia", "Aleksandrovna", new DateTime(1976, 1, 12), Genders.Female, Educations.University);
            Console.WriteLine(mother.Age);
            Human child = new Human();
            child.Name = "Vova";
            child.Surname = "Borisov";
            child.DateOfBirth = new DateTime(2003, 3, 25);
            child.Education = Educations.HighSchool;
            child.SetParent(father);
            child.SetParent(mother);
            if (!child.LegalAge())
            {
                Console.WriteLine(child["FullName"] + " is less then 18");
            }
            Console.WriteLine(child);
            child.ChangeGender();
            child["Name"] = "Marina";
            Humans family = new Humans();
            family.AddHuman(father);
            family.AddHuman(mother);
            family.AddHuman(child);
            for (int i = 0; i < family.NumberOfHumans; i++)
            {
                Console.WriteLine(family[i]);
            }
            Console.ReadKey();
        }
    }
}
