namespace ReplacePrivateMethod;

public class OverridenClient : MainClient
{
    private string PrivateMethod()
    {
        return "This is an overwritten private";
    }
}