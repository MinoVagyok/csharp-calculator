using CSharp_Calculator.Logic.UI_Logic;

using System;
using System.Collections.Generic;
using CSharp_Calculator.Logic.UI_Logic;

namespace CSharp_Calculator.Logic.Error_Handling
{

    public static class ErrorHandler
    {
        public static void SafeRun(Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                var e = Unwrap(ex);
                ConsoleUI.Error("Error: " + MapException(e));
            }
        }
        
        public static T SafeRun<T>(Func<T> func, T fallback = default)
        {
            try
            {
                return func();
            }
            catch (Exception ex)
            {
                var e = Unwrap(ex);
                ConsoleUI.Error("Error: " + MapException(e));
                return fallback;
            }
        }
        
        private static Exception Unwrap(Exception ex)
        {
            if (ex is AggregateException agg && agg.InnerExceptions.Count > 0)
                return Unwrap(agg.InnerExceptions[0]);

            return ex.InnerException ?? ex;
        }
        
        private static string MapException(Exception ex) => ex switch
        {
            FileNotFoundException fnf => $"File not found: {fnf.FileName ?? fnf.Message}",
            DirectoryNotFoundException => "Directory not found.",
            PathTooLongException => "File path is too long.",
            UnauthorizedAccessException => "Access denied for this file or directory.",
            System.Text.Json.JsonException => "Invalid JSON format.",
            FormatException => "Invalid data/file format.",
            DivideByZeroException => "Division by zero is not allowed.",
            InvalidOperationException ioe => ioe.Message, 
            NotSupportedException nse => nse.Message,     
            ArgumentException ae => ae.Message,           
            
            _ => ex.Message
        };
    }
}




