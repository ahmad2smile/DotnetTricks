using System.Diagnostics;
using System.Reflection;
using ReplacePrivateMethod;

MethodInterceptor.ReplaceMethod(
    typeof(MainClient).GetMethod("PrivateMethod", BindingFlags.NonPublic | BindingFlags.Instance)!,
    typeof(OverridenClient).GetMethod("PrivateMethod", BindingFlags.NonPublic | BindingFlags.Instance)!);

var service = new OverridenClient();

var result = service.PrivateMethodCaller();

Console.WriteLine(result);

Debug.Assert(result == "This is an overwritten private",
    "Message shouldn't be 'This is a private' as call to PrivateMethod should have been replaced.");