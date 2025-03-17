namespace WebApplication1.Services.Lambda
{
    public interface ILambdaService
    {
        Tuple<int, int, int> SplitNumber(int value);

        bool TryParseNumber(string value);

        Task<string> ToLowerCaseDelayed(string value);
    }
}
