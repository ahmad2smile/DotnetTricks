using System.Reflection;
using System.Runtime.CompilerServices;

namespace ReplacePrivateMethod;

public static class MethodInterceptor
{
    public static void ReplaceMethod(MethodInfo originalMethod, MethodInfo newMethod)
    {
        // Get the method pointers for both methods
        var originalHandle = originalMethod.MethodHandle;
        var newHandle = newMethod.MethodHandle;

        // Trigger IL Generation, not necessary but helpful
        RuntimeHelpers.PrepareMethod(originalHandle);
        RuntimeHelpers.PrepareMethod(newHandle);

        unsafe
        {
            if (IntPtr.Size == 4) // 32-bit systems
            {
                // NOTE: Move from Method's metadata to method instructions
                var inj = (int*)newHandle.Value.ToPointer() + 2;
                var tar = (int*)originalHandle.Value.ToPointer() + 2;
                *tar = *inj;
            }
            else // 64-bit systems
            {
                // NOTE: Move from Method's metadata to method instructions
                var inj = (long*)newHandle.Value.ToPointer() + 1;
                var tar = (long*)originalHandle.Value.ToPointer() + 1;
                *tar = *inj;
            }
        }
    }
}