using System;

namespace IWETD.Game
{
    public class IWETDGame : IWETDGameBase
    {
        private readonly string[] args;

        public IWETDGame(string[] args)
        {
            this.args = args;
        }
    }
}