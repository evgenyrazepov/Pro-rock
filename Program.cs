using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ConsoleApp9
{
    public class Int
    {

        protected int _number;
        public int n { get { return this._number; } set { this._number = value; } }
        public Int(int number)
        {
            this._number = number;
        }

        public static Int operator +(Int i1, Int i2)
        {
            return new Int(i1.n + i2.n);
        }
        public override string ToString()
        {
            return this._number.ToString();
        }

        public static Int operator ++(Int i)
        {
            i.n++;
            return i;
        }
        public static Int operator *(Int i1, Int i2)
        {
            return new Int(i1.n * i2.n);
        }

        public override bool Equals(object? a)
        {
            if (a == null)
                return false;
            return this.GetHashCode == a.GetHashCode;
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public static bool operator ==(Int a, Int b)
        {
            return a.Equals(b);
        }
        public static bool operator !=(Int a, Int b)
        {
            return !a.Equals(b);
        }
        public static bool operator >(Int a, Int b)
        {
            return a.n > b.n;
        }
        public static bool operator <(Int a, Int b)
        {
            return a.n < b.n;
        }
        public static bool operator true(Int i)
        {
            return i.n != 0;
        }
        public static bool operator false(Int i)
        {
            return i.n == 0;
        }

        public static Int operator &(Int i1, Int i2)
        {
            return ((i1.n != 0) && (i2.n != 0)) ? new Int(1) : new Int(0);
        }
        public static implicit operator int(Int i)
        {
            return i.n;
        }
    }

    // индексатор


    class Student 
    { 
    public string? firstname { get; set; }

        public string? lastname { get; set; }

        public int age { get; set; }
        public Student(string firstname, string lastname, int age) { 
        this.firstname = firstname; ;
            this.lastname = lastname;
            this.age = age;
        }
        public override string ToString()
        {
            return $"{firstname} {lastname}, {age} лет";
        }
    }

    class Group {


        public string? name { get; set; }
        protected List<Student> students  = new List<Student>();
        public Group(string name, params Student[] students) {

            this.name = name;
            foreach (Student student in students)
                this.students.Add(student);
        }

        public float AvgAge() {
            int sum = 0;
            foreach (Student student in this.students)
                sum += student.age ?? 0;
            return (float)sum / this.students.Count;
        }
        public Student this[int index]
        {
            get
            {
              return this.students[index];

            }
            
        }
      

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Group g = new Group("211", new Student("regh", "jfj", 15),
                                       new Student("cdff", "jfj", 15));
            Console.WriteLine(g.AvgAge());
            Console.WriteLine();
    }
    }
}