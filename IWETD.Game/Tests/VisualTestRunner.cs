using System;
using osu.Framework;

namespace IWETD.Game.Tests
{
    public static class VisualTestRunner
    {
        [STAThread]
        private static void Main(string[] args)
        {
            using (var host = Host.GetSuitableHost("IWETD Tests", true))
            {
                host.Run(new IWETDTestBrowser());
            }
        }
    }
}