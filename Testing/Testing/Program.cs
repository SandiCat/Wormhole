using System;

namespace TestingNamespace
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (Testing game = new Testing())
            {
                game.Run();
            }
        }
    }
}

