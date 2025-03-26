namespace WebApplication1.Services.Delegate
{
    public class DelegateService : IDelegateService
    {
        public string Introduction(string value, Func<string, string, string> callback)
        {
            var upperName = value.ToUpper();
            return callback(upperName, "Test");
        }

        public string Hello(string firstname, string lastname)
        {
            return $"Hello, {firstname} {lastname}";
        }

        public int Operation(int a, int b, Func<int, int, int> callback)
        {
            return callback(a, b);
        }
    }
}
