using System;
using System.Collections.Generic;

namespace HumanProject
{
    class ArtStudent : Student
    {
        public ArtStudent() : this("Unknown", "Unknown", "Unknown") { }
        public ArtStudent(string surname, string name, string middlename, bool talent, Universities university, Degrees degree, DateTime dateOfBirth, Genders gender = Genders.Male, Educations education = Educations.HighSchool) : base(surname, name, middlename, university, degree, dateOfBirth, gender, education)
        {
            Marks = new Subjects();
            SeccionMarks = new List<int>();
            Talented = talent;
            DrawSkill = 0;
        }
        public ArtStudent(string surname, string name, string middlename) : base(surname, name, middlename, Universities.BSU, Degrees.Graduate)
        {
            Marks = new Subjects();
            SeccionMarks = new List<int>();
            Talented = false;
            DrawSkill = 0;
        }
        private struct Subjects
        {
            public int Painting, Sculpture, GraphicsArt;
        }
        Subjects Marks;
        public bool Talented { get; set; }
        public int DrawSkill { get; set; }
        public override void PassSession()
        {
            Random rand = new Random();
            switch (Performance)
            {
                case PerformanceList.Excellent:
                    {
                        Marks.GraphicsArt = rand.Next(9, 10);
                        Marks.Painting = rand.Next(9, 10);
                        Marks.Sculpture = rand.Next(9, 10);
                        break;
                    }
                case PerformanceList.Good:
                    {
                        Marks.GraphicsArt = rand.Next(7, 9);
                        Marks.Painting = rand.Next(7, 9);
                        Marks.Sculpture = rand.Next(7, 9);
                        break;
                    }
                case PerformanceList.Satisfactory:
                    {
                        Marks.GraphicsArt = rand.Next(4, 7);
                        Marks.Painting = rand.Next(4, 7);
                        Marks.Sculpture = rand.Next(4, 7);
                        break;
                    }
                case PerformanceList.Unsatisfactory:
                    {
                        Marks.GraphicsArt = rand.Next(0, 5);
                        Marks.Painting = rand.Next(0, 5);
                        Marks.Sculpture = rand.Next(0, 5);
                        break;
                    }
                default:
                    {
                        GetExpelled();
                        break;
                    }
            }
            if (Marks.Painting < 4 || Marks.GraphicsArt < 4 || Marks.Sculpture < 4)
            {
                if (Talented == false)
                {
                    Retake();
                } else
                {
                    Draw();
                    if (DrawSkill < 30)
                    {
                        Retake();
                    }
                }
            }
            else
            {
                SeccionMarks.Add(Marks.Sculpture);
                SeccionMarks.Add(Marks.Painting);
                SeccionMarks.Add(Marks.GraphicsArt);
                CalculateAverageMarks();
                UpdateGrants();
            }
        }
        public void Draw()
        {
            DrawSkill += 2;
            Console.WriteLine("You draw a picture");
        }
        public override int Study()
        {
            int mark;
            Random rand = new Random();
            if (Talented)
            {
                mark = rand.Next(9, 11);
            }
            else
            {
                mark = rand.Next(0, 11);
            }
            return mark;
        }

        public override bool WriteDiploma()
        {
            if (Talented && Performance == PerformanceList.Good)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        override public string ToString()
        {
            string result = base.ToString();
            result += "Specialization: Art" + '\n' + "Diploma: " + WriteDiploma() + '\n';
            result += "Grant " + Grants + '\n';
            return result;
        }
    }
}
