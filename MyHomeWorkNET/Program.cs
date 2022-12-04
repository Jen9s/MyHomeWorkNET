string[] cars = { "Nissan", "Aston Martin", "Chevrolet", 
    "Alfa Romeo", "Chrysler", "Dodge", "BMW", "Ferrari",
    "Audi", "Bentley", "Ford", "Lexus", "Mercedes", 
    "Toyota", "Volvo", "Subaru", "Жигули :)"};

var studentList = new List<Student>() { 
    new Student() { StudentID = 1, StudentName = "John", Age = 13} ,
    new Student() { StudentID = 2, StudentName = "Moin",  Age = 21 } ,
    new Student() { StudentID = 3, StudentName = "Bill",  Age = 18 } ,
    new Student() { StudentID = 4, StudentName = "Ram" , Age = 20} ,
    new Student() { StudentID = 5, StudentName = "Ron" , Age = 15 } 
};

// StartingWithF(cars);
// OddCar(cars);
// StringSize(cars);
// StringSizeCombo(cars);
// StringSizeIndex(cars);

// SortCollection(studentList);
GroupStudentAge(studentList);

void StartingWithF(params string[] cars)
{
    var nameCarsF = from carName in cars
        where carName.ToUpper().StartsWith("F") 
        // where carName[0] == 'F'
        select carName;
    
    foreach (var s in nameCarsF)
    {
        Console.WriteLine(s);
    }
}

void OddCar(params string[] cars)
{
    var oddCars = from car in cars
        where Array.IndexOf(cars, car) % 2 == 1
        select car;

    foreach (var s in oddCars)
    {
        Console.WriteLine(s);
    }
}

void StringSize(params string[] cars)
{
    var nameSize = from car in cars
        select new
        {
            size = car.Length
        };
    foreach (var s in nameSize)
    {
        Console.WriteLine($"{s.size}");
    }
}

void StringSizeCombo(params string[] cars)
{
    var nameSize = from car in cars
        select new
        {
            name = car,
            size = car.Length
        };
    foreach (var s in nameSize)
    {
        Console.WriteLine($"{s.name} - {s.size}");
    }
}

void StringSizeIndex(params string[] cars)
{
    var nameSize = from car in cars
        select new
        {
            index = Array.IndexOf(cars,car),
            size = car.Length
        };
    foreach (var s in nameSize)
    {
        Console.WriteLine($"{s.index} - {s.size}");
    }
}

void SortCollection(List<Student> students)
{
    var sortCollection = from student in students
        where student.Age > 12 && student.Age < 20
        orderby student.Age descending, student.StudentName
        select student;
    
    foreach (var student in sortCollection)
    {
        Console.WriteLine($"{student.StudentID} - {student.StudentName} - {student.Age}");
    }
}

void GroupStudentAge(List<Student> students)
{
    var groupStudentAge = from student in students
        group student by student.Age;

    foreach (var student in groupStudentAge)
    {
        Console.WriteLine($"{student.Key}");
        foreach (var st in student)
        {
            Console.WriteLine($"{st.StudentID} - {st.StudentName}");
        }
    }
}

public class Student
{
    internal int StudentID { get; set; }
    internal string StudentName { get; set; }
    internal int Age{ get; set; }

    public Student() { }
    public Student(int StudentID, string StudentName, int Age)
    {
        this.StudentID = StudentID;
        this.StudentName = StudentName;
        this.Age = Age;
    }
}

