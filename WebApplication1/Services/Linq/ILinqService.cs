namespace WebApplication1.Services.Linq
{
    public interface ILinqService
    {
        int CountStudentsOver(int value);

        List<Car> GetCarsByBrand(string brand);
        List<string> Models();
        int CarsCount();
        List<Car> Filter(int year);
        List<string> Join();
    }


}
