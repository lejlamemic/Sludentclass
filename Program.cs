using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentClassHW
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> stList = new List<Student> {
                new Student("NameOne", "SurNameOne", "email3568@aubih.edu.ba"),
                new Student("NameTwo", "SurNameTwo", "email1486@aubih.edu.ba"),
                new Student("NameThree", "SurNameThree", "email2149@aubih.edu.ba"),
            };

            stList.Sort();

            foreach (Student s in stList)
            {
                Console.WriteLine(s.getStudentInfo());
            }

            Console.ReadLine();
        }
    }

    class Person
    {
        protected string name, lastName;
        protected static int count = 0;

        protected Person(string name, string lastName)
        {
            count++;
            this.name = name;
            this.lastName = lastName;
        }

        protected string getPersonInfo()
        {
            return name + ", " + lastName;
        }
    }
    
    class Student : Person, IComparable<Student>
    {
        public string email {get; set;}
        private string Location;
        public string location
        {
            get
            {
                if (Location == "SA")
                {
                    return "Sarajevo";
                }
                else if (Location == "TZ")
                {
                    return "Tuzla";
                }
                else
                {
                    return "Other";
                }
            }
            set
            {
                if (value == "SA" || value == "SARAJEVO" || value == "Sarajevo")
                {
                    Location = "Sarajevo";
                }
                else if (value == "TZ" || value == "TUZLA" || value == "Tuzla")
                {
                    Location = "Tuzla";
                }
                else
                {
                    Location = "NA";
                }
            }
        }

        public Student() : base("Lejla", "Memic")
        {
            this.email = "email@aubih.edu.ba";
            this.location = "Sarajevo";
        }

        ~Student() {
            count = 0;
        }

        public Student(string name, string lastname, string email)
            : base(name, lastname)
        {
            this.email = email;
            this.location = "Sarajevo";
        }

        public bool setName(string input)
        {
            if (input.Length <= 2)
            {
                Console.WriteLine("Name must be at least two characters long");
                return false;
            }

            char[] charArray = input.ToCharArray();
            foreach(char c in charArray) {
                if(!char.IsLetter(c)) {
                    Console.WriteLine("Name can only have letters");
                    return false;
                }
            }

            if (char.IsUpper(charArray[0]))
            {
                Console.WriteLine("Name must start with an uppercase letter");
                return false;
            }

            return true;
        }
        
        public string getStudentInfo()
        {
            return base.getPersonInfo() + ", " + this.email + ", " + this.location;
        }

        public override string ToString()
        {
            return getStudentInfo();
        }

        public int CompareTo(Student student)
        {
            return this.email.CompareTo(student.email);
        }
    }
}
