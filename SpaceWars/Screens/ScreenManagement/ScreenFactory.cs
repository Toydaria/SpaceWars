using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceWars.Screens.ScreenManagement
{
    public static class ScreenFactory
    {
        public static GameScreen CreateScreen(string screenName)
        {
            switch (screenName)
            {
                case "MainScreen":
                    return new MainScreen();

                case "SplashScreen":
                    return new SplashScreen();

                case "GameOverScreen":
                    return new GameOverScreen();
                case "InstructionsScreen":
                    return new InstructionsScreen();
                default:
                    throw new InvalidOperationException("This screen doesen't exist.");

            }
        }
    }
}
