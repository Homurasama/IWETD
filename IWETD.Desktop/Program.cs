using IWETD.Game;
using osu.Framework;
using osu.Framework.Platform;

namespace IWETD.Desktop
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            using (GameHost host = Host.GetSuitableHost(@"IWETD"))
            using (var game = new IWETDGameDesktop(args))
            {
                host.Run(game);
            }
        }
    }
}