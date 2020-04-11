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
            using (var game = new IWETDGame(args))
            {
                host.Run(game);
            }
        }
    }
}