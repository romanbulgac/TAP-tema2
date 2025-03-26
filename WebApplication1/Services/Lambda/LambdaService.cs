using System.Diagnostics.Eventing.Reader;

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

        public string HelloSB()
        {
            var lambdaExp = () => {
                string s = "Hello, World!";
                return s;
            };
            return lambdaExp();
        }
        public string HelloExp()
        {
            var lambdaExp = () => ("Hello, World!");
            return lambdaExp();
        }

        public double PowExp(double a, int b)
        {
            var lambdaExp = (double x, int y) => Math.Pow(x, y);
            return lambdaExp(a, b);
        }
        public double PowSB(double a, int b)
        {
            var lambdaExp = (double x, int y) => {
                if (x == 0){
                    return 0;
                }
                else if (y == 0)
                {
                    return 1;
                }
                else if (y == 1)
                {
                    return x;
                }
                else if (y % 2 == 0)
                {
                    double result = PowSB(x, y / 2);
                    return result * result;
                }
                else if(y % 2 != 0)
                {
                    double result = PowSB(x, (y-1) / 2);
                    return result * result * x;
                }
                return 0;
            };
            return lambdaExp(a, b);
        }

        public double SqrtExp(double a)
        {
            var lambdaExp = (double x) => Math.Sqrt(x);
            return lambdaExp(a);
        }

        public double SqrtSB(double a)
        {
            var lambdaExp = (double x) => {
                if (x < 0)
                {
                    return double.NaN;
                }
                double result = x;
                double previousResult = 0;
                while (Math.Abs(result - previousResult) > 0.0001)
                {
                    previousResult = result;
                    result = (result + x / result) / 2;
                }
                return result;
            };
            return lambdaExp(a);
        }

        public double SumExp(double a, double b, double c)
        {
            Func<double, double,double, double> lambdaExp = (double x, double y, double _) => x + y;
            return lambdaExp(a, b, c);
        }
        public double SumSB(double a, double b, double c)
        {
            Func<double, double,double, double> lambdaExp = (double x, double y, double _) => {
                double result = x + y;
                return result;
            };
            return lambdaExp(a, b, c);
        }

        public double[] SortSB(double[] values, bool ascending)
        {
            Func<double[], bool, double[]> lambdaExp = (double[] x, bool y = true) =>
            {
                if (y)
                {
                    Array.Sort(x);
                }
                else
                {
                    Array.Sort(x);
                    Array.Reverse(x);
                }

                return x;
            };
            return lambdaExp(values, ascending);
        }
        public double[] SortExp(double[] values, bool ascending)
        {
            Func<double[], bool, double[]> lambdaExp = (double[] x, bool y = true) => y ? x.OrderBy(v => v).ToArray() : x.OrderByDescending(v => v).ToArray();
            return lambdaExp(values, ascending);
        }

        public int SumTupleExp(Tuple<int, int> tuple)
        {
            Func<Tuple<int, int>, int> lambdaExp = (Tuple<int, int> x) => x.Item1 + x.Item2;
            return lambdaExp(tuple);
        }
        public int SumTupleSB(Tuple<int, int> tuple)
        {
            Func<Tuple<int, int>, int> lambdaExp = (Tuple<int, int> x) => {
                int result = x.Item1 + x.Item2;
                return result;
                };
            return lambdaExp(tuple);
        }

        public async Task<string> SendMessageSB(string value)
        {
            var lambdaExp = async (string v) =>
            {
                await Delay();
                return value;
            };

            return await lambdaExp(value);
        }
        public async Task<string> SendMessageExp(string value)
        {
            var lambdaExp = async (string v) => await Delay().ContinueWith(_ => value);
            return await lambdaExp(value);
        }
    }
}
