using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services.Delegate;

namespace WebApplication1.Controllers;
[ApiController]
[Route("[controller]")]
public class TestDelegateController : ControllerBase
{
    private readonly IDelegateService _delegateService;

    public TestDelegateController(IDelegateService delegateService)
    {
        _delegateService = delegateService;
    }

    [HttpGet("intro")]
    public string Introduction(string name)
    {
        var callback = _delegateService.Hello;

        return _delegateService.Introduction(name, callback);
    }

    [HttpGet("intro-condition")]
    public string IntroductionCondition(string name, bool welcome)
    {
        var callback1 = _delegateService.Hello;
        var callback2 = (string firstname, string lastname) => $"Bye, {firstname} {lastname}";

        var callback = welcome ? callback1 : callback2;

        return _delegateService.Introduction(name, callback);
    }
    [HttpGet("math-operation-anonymous")]
    public int Operation(int a, int b, string operation)
    {
        Func<int, int, int> callback = operation switch
        {
            "add" => (x, y) => x + y,
            "sub" => (x, y) => x - y,
            "mul" => (x, y) => x * y,
            "div" => (x, y) => y != 0 ? x / y : throw new DivideByZeroException("Cannot divide by zero"),
            _ => throw new System.Exception("Invalid operation")
        };
        return _delegateService.Operation(a, b, callback);
    }

    public delegate int MathOperation(int a, int b);
    [NonAction]
    public int Add(int a, int b)
    {
        return a + b;
    }

    [NonAction]
    public int Sub(int a, int b)
    {
        return a - b;
    }

    [NonAction]
    public int Mul(int a, int b)
    {
        return a * b;
    }

    [NonAction]
    public int Div(int a, int b)
    {
        return b != 0 ? a / b : throw new DivideByZeroException("Cannot divide by zero");
    }
    [HttpGet("math-operation-named")]
    public int OperationNM(int a, int b, string operation)
    {
        MathOperation mathOp = operation switch
        {
            "add" => Add,
            "sub" => Sub,
            "mul" => Mul,
            "div" => Div,
            _ => throw new System.Exception("Invalid operation")
        };
        return _delegateService.Operation(a, b, (x, y) => mathOp(x, y));
    }

    delegate string Notificare(string message);

    [NonAction]
    static string AfiseazaMesaj(string message)
    {
        return $"Mesaj: {message}";
    }

    [NonAction]
    static string InregistreazaLog(string message)
    {
        return $"Log: mesajul \"{message}\" a fost înregistrat.";
    }

    [NonAction]
    static string TrimiteNotificare(string message)
    {
        return "Notificare: Utilizatorul a fost informat.";
    }

    [HttpGet("send-notification")]
    public string ExecutaProces(string message)
    {

        Notificare notificari = AfiseazaMesaj;
        notificari += InregistreazaLog;
        notificari += TrimiteNotificare;


        return notificari.Invoke(message);
    }

    [HttpGet("send-notification-anonymous")]
    public string SendNotification(string message)
    {

        Func<string, string> notification = (message) =>
        {
            return $"Mesaj: {message}";
        };
        notification += (message) =>
        {
            return $"Log: mesajul \"{message}\" a fost înregistrat.";
        };
        notification += (message) =>
        {
            return "Notificare: Utilizatorul a fost informat.";
        };


        return notification.Invoke(message);
    }


}
