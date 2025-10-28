using System;
using CSharp_Calculator.Logic.Error_Handling;

namespace CSharp_Calculator.Logic.UI_Logic
{
    public static class MenuRunner
    {
        public static void Run(Action action)
            => ErrorHandler.SafeRun(action);

        public static T Run<T>(Func<T> func, T fallback = default)
            => ErrorHandler.SafeRun(func, fallback);
    }
}