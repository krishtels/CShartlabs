using System;
using System.Collections.Generic;
using System.Linq;

namespace HumanProject
{
    class Human
    {
        private static int numberOfId;
        public int Id { get; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Middlename { get; set; }
        public DateTime DateOfBirth { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public int Age
        {
            get
            {
                return CalculateAge(DateOfBirth);
            }
        }
        public string Adress { get; set; }
        public Educations Education { get; set; }
        public Genders Gender { get; set; }
        public Human Mother { get; private set; }
        public Human Father { get; private set; }
        public List<Human> Children = new List<Human>();
        public Human() : this("Unknown", "Unknown") { }
        public Human(string surname, string name, string middlename = "-") : this(surname, name, middlename, DateTime.Now, Genders.Male, Educations.HighSchool) { }
        public Human(string surname, string name, string middlename, DateTime dateOfBirth, Genders gender, Educations education, double weight = 0, double height = 0, string adress = null, Human mother = null, Human father = null)
        {
            Id = numberOfId++;
            Name = name;
            Surname = surname;
            Middlename = middlename;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            Education = education;
            Weight = weight;
            Height = height;
            Adress = adress;
            Mother = mother;
            Father = father;
            if (Mother != null)
            {
                Mother.AddChild(this);
            }
            if (Father != null)
            {
                Father.AddChild(this);
            }
        }
        public string this[string propname]
        {
            get
            {
                switch (propname)
                {
                    case "FullName":
                        return Surname + " " + Name + " " + Middlename;
                    case "DateOfBirth":
                        return DateOfBirth.ToString("dd.MM.yyyy");
                    case "Education":
                        return Education.ToString();
                    case "Gender":
                        return Gender.ToString();
                    default:
                        return null;
                }
            }
            set
            {
                switch (propname)
                {
                    case "Name":
                        Name = value;
                        break;
                    case "Surname":
                        Surname = value;
                        break;
                    case "MiddleName":
                        Middlename = value;
                        break;
                    case "Adress":
                        Adress = value;
                        break;
                    default:
                        break;
                }
            }
        }
        public void AddChild(Human child)
        {
            if (child != null)
            {
                Children.Add(child);
            }
        }
        public void RemoveChild(Human child)
        {
            if (child != null)
            {
                Children.Remove(child);
            }
        }
        public void SetParent(Human parent)
        {
            if (parent != null)
            {
                if (parent.Gender == Genders.Male)
                {
                    Father = parent;
                }
                else
                {
                    Mother = parent;
                }
                parent.AddChild(this);
            }
        }
        public double IndexOfBody()
        {
            if (Height > 0)
            {
                return Weight / (Height * Height);
            }
            else
            {
                return 0;
            }
        }
        private int CalculateAge(DateTime dateOfBirth)
        {
            DateTime nowDate = DateTime.Now;
            int age = nowDate.Year - dateOfBirth.Year;
            if (nowDate.Month < dateOfBirth.Month || (nowDate.Month == dateOfBirth.Month && nowDate.Day < dateOfBirth.Day))
            {
                age--;
            }
            return age;
        }
        public void ChangeGender()
        {
            if (Gender == Genders.Male)
            {
                Gender = Genders.Female;
            }
            else
            {
                Gender = Genders.Male;
            }
        }
        public void ChangeGender(Genders gender)
        {
            Gender = gender;
        }
        public bool LegalAge()
        {
            return Age >= 18;
        }
        public override string ToString()
        {
            string result = Id.ToString() + ". Full Name: " + this["FullName"] + '\n';
            int age = CalculateAge(DateOfBirth);
            result += "Date of birth: " + this["DateOfBirth"] + " Age: " + age.ToString() + '\n' + "Gender: " + this["Gender"] + '\n' + "Education: " + this["Education"] + '\n' + "Weight(kilos) " + Weight.ToString() + " height(meters): " + Height.ToString() + '\n';
            if (Mother != null)
            {
                result += "Mother " + Mother.Name + '\n';
            }
            if (Father != null)
            {
                result += "Father " + Father.Name + '\n';
            }
            if (Children.Count() > 0)
            {
                result += "Children amount: " + Children.Count() + '\n' + "Children names: ";
                for (int i = 0; i < Children.Count(); i++)
                {
                    result += Children[i].Name + " ";
                }
                result += '\n';
            }
            result += "Adress: " + Adress + '\n';
            return result;
        }
    }
}
