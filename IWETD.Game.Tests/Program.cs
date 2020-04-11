using osu.Framework;

namespace IWETD.Game.Tests
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            using (var host = Host.GetSuitableHost("IWETD Tests", true))
            {
                host.Run(new IWETDTestBrowser());
            }
        }
    }
}