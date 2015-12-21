namespace SpaceWars.Screens.ScreenManagement
{
    using System;

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
                default:
                    throw new InvalidOperationException("This screen doesen't exist.");

            }
        }
    }
}
