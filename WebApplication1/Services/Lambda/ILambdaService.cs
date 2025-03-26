namespace WebApplication1.Services.Lambda
{
    public interface ILambdaService
    {
        Tuple<int, int, int> SplitNumber(int value);

        bool TryParseNumber(string value);

        Task<string> ToLowerCaseDelayed(string value);

        string HelloSB();
        string HelloExp();

        double PowSB(double a, int b);
        double PowExp(double a, int b);

        double SqrtSB(double a);
        double SqrtExp(double a);

        double SumSB(double a, double b, double c);
        double SumExp(double a, double b, double c);

        double[] SortSB(double[] values, bool ascending);
        double[] SortExp(double[] values, bool ascending);

        int SumTupleExp(Tuple<int, int> tuple);
        int SumTupleSB(Tuple<int, int> tuple);

        Task<string> SendMessageSB(string value);
        Task<string> SendMessageExp(string value);
    
    }
}
