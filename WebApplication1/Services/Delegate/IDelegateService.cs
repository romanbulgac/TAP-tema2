namespace WebApplication1.Services.Delegate
{
    public interface IDelegateService
    {
        string Introduction(string value, Func<string, string, string> callback);

        string Hello(string firstname, string lastname);
        int Operation(int a, int b, Func<int, int, int> callback);
    }
}
