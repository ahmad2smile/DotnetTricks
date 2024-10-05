# Dotnet Tricks

## Replace Private Method

This Project [ReplacePrivateMethod](ReplacePrivateMethod/ReplacePrivateMethod.csproj) Replaces a private method's
implementation with some other method, so when the private method is called your custom
method runs. Ex:

1. Suppose a private method in a library you want to do something else:

```csharp
private string? PrivateMethod()
{
    return "This is a private";
}
```

2. Replaces it so when it's called it runs following method instead:

```csharp
// NOTE: Method in any class with any name
private string? PrivateMethod()
{
    return "This is an overwritten private";
}
```

This is done by replacing original method's Instructions' Location in IL with Instructions Location of method to
replaced in IL.

Credits: [Code Ease Blog](https://www.codeease.net/programming/questions/dynamically-replace-the-contents-of-a-c-sharp-method)