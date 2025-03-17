namespace WebApplication1.Services.Linq
{
    public class Student
    {
        public Student(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class LinqService : ILinqService
    {
        public List<Student> stUdents = new List<Student>()
        {
            new Student("T1", 25),
            new Student("T2", 29),
            new Student("T3", 33),
        };

        public int CountStudentsOver(int value)
        {
            //Query-expression
            //var query = from student in stUdents
            //            where student.Age >= value
            //                select student;

            //return query.Count();

            //Method-expression 
            return stUdents.Count(student => student.Age >= value);
        }
    }
}
