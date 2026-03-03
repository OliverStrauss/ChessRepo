// See https://aka.ms/new-console-template for more information


using ChessEngine.Engine;

namespace ChessEngine.Backend
{


    public class Program
    {
        public static void Main(string[] args)
        {
            Board b;
            b = new Board();
            Console.WriteLine(b);
        }
    }
}