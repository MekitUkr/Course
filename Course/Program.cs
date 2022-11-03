using System;
using PL;
namespace Course
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.InputEncoding = System.Text.Encoding.Unicode;
            MainMenu menu = new MainMenu();
            menu.Start();
        }
    }
}
