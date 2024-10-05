namespace ReplacePrivateMethod;

public class MainClient
{
    public string PrivateMethodCaller()
    {
        return PrivateMethod();
    }

    private string PrivateMethod()
    {
        return "This is a private";
    }
}