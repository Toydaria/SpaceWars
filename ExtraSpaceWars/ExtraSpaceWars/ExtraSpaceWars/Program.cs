using System;

namespace ExtraSpaceWars
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (ExtraSpaceWars game = new ExtraSpaceWars())
            {
                game.Run();
            }
        }
    }
#endif
}

