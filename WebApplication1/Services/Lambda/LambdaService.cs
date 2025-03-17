namespace WebApplication1.Services.Lambda
{
    public class LambdaService : ILambdaService
    {
        public Tuple<int, int, int> SplitNumber(int value)
        {
            var lambdaExp = (int num) => new Tuple<int, int, int>(num % 10, (num /= 10) % 10, (num /= 10) % 10);
            return lambdaExp(value);
        }

        public bool TryParseNumber(string value)
        {
            return int.TryParse(value, out _);
        }

        public async Task<string> ToLowerCaseDelayed(string value)
        {
            var lambaExp = async (string v) =>
            {
                await Delay();
                return value.ToLower();
            };

            return await lambaExp(value);
        }


        public Task Delay()
        {
            return Task.Delay(10000);
        }
    }
}
