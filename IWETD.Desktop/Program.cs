using System;
using osu.Framework;
using osu.Framework.Platform;
using IWETD.Game;

namespace IWETD.Desktop
{
    class Program
    {
        static void Main(string[] args)
        {
            using (GameHost host = Host.GetSuitableHost(@"IWETD"))
            using (IWETDGame game = new IWETDGame(args))
                host.Run(game);
        }
    }
}
