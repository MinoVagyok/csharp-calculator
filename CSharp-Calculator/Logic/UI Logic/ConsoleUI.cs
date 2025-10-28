using MatrixLibrary;
using System.Globalization;

namespace CSharp_Calculator.Logic.UI_Logic;

    
    public static class ConsoleUI
    {
        public static void Info(string msg)    => WriteColored(ConsoleColor.Cyan,  msg);
        public static void Success(string msg) => WriteColored(ConsoleColor.Green, msg);
        public static void Warn(string msg)    => WriteColored(ConsoleColor.Yellow,msg); 
        public static void Error(string msg)   => WriteColored(ConsoleColor.Red,   msg);

        private static void WriteColored(ConsoleColor color, string msg)
        {
            var previous = Console.ForegroundColor;
            try
            {
                Console.ForegroundColor = color;
                Console.WriteLine(msg);
            }
            finally
            {
                Console.ForegroundColor = previous;
            }
        }
        
        public static void PrintMatrix(Matrix m, string numberFormat = "0.##", int fieldWidth = 8, bool leftAlign = false)
        {
            if (m is null) throw new ArgumentNullException(nameof(m));

            Console.WriteLine($"Matrix ({m.Rows} x {m.Columns}):");
            for (int i = 0; i < m.Rows; i++)
            {
                Console.Write("| ");
                for (int j = 0; j < m.Columns; j++)
                {
                    string cell = m.Data[i][j].ToString(numberFormat, CultureInfo.InvariantCulture);
                    string padded = leftAlign ? cell.PadRight(fieldWidth) : cell.PadLeft(fieldWidth);
                    Console.Write(padded + " ");
                }
                Console.WriteLine("|");
            }
            Console.WriteLine();
        }
    }