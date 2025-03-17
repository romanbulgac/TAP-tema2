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
    }
}
