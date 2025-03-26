using System.Data.Common;

namespace WebApplication1.Services.Linq;
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

public class Car
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public double EngineSize { get; set; }
    public string Color { get; set; }

    public Car(string brand, string model, int year, double engineSize, string color)
    {
        Brand = brand;
        Model = model;
        Year = year;
        EngineSize = engineSize;
        Color = color;
    }

    public override string ToString()
    {
        return $"{Year} {Brand} {Model}, Engine: {EngineSize}L, Color: {Color}";
    }
}

static class CarStorage{
    static public List<Car> cars = new (){
        new Car("Toyota", "Corolla", 2010, 1.6, "Red"),
        new Car("Toyota", "Camry", 2015, 2.5, "Black"),
        new Car("Toyota", "Land Cruiser", 2018, 4.6, "White"),
        new Car("Ford", "Fiesta", 2012, 1.4, "Blue"),
        new Car("Ford", "Focus", 2016, 1.6, "Green"),
        new Car("Ford", "Mondeo", 2019, 2.0, "Yellow"),
        new Car("BMW", "1", 2013, 1.6, "Black"),
        new Car("BMW", "3", 2017, 2.0, "White"),
        new Car("BMW", "5", 2020, 2.5, "Red"),
    };
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

    public List<Car> GetCarsByBrand(string brand)
    {
        //Query-expression
        // var query = from car in CarStorage.cars
        //            where car.Brand == brand
        //            select car;

        // return query.ToList();

        //Method-expression
        return CarStorage.cars.Where(car => car.Brand.ToLower() == brand.ToLower()).ToList();
    }


    public List<string> Models()
    {
        //Query-expression
        //var query = from car in CarStorage.cars
        //            select car.Brand + " " +  car.Model ;

        //return query.ToList();

        //Method-expression
        return CarStorage.cars.Select(car =>car.Brand + ' ' + car.Model).ToList();
    }

    public int CarsCount()
    {
        //Query-expression
        //var query = from car in CarStorage.cars
        //            select car;

        //return query.Count();

        //Method-expression
        return CarStorage.cars.Count();
    }

    public List<Car> Filter(int year){
        //Query-expression
        //var query = from car in CarStorage.cars
        //            where car.Year > year
        //            select car;

        //return query.ToList();

        //Method-expression
        return CarStorage.cars.Where(car => car.Year > year).ToList();
    }

    public List<string> Join(){
        //Query-expression
        // var query = from car in CarStorage.cars
        //             join car2 in CarStorage.cars on car.Brand equals car2.Brand
        //             select car.Brand + " " + car.Model + " " + car2.Model;
        // return query.ToList();

        //Method-expression
        return CarStorage.cars.Join(CarStorage.cars, 
        car => car.Brand, car2 => car2.Brand, 
        (car, car2) => car.Brand + ' ' + car.Model + ' ' + car2.Model)
        .ToList();
    }
}

