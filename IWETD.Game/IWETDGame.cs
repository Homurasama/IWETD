namespace IWETD.Game
{
    public class IWETDGame : IWETDGameBase
    {
        private readonly string[] _args;

        public IWETDGame(string[] args)
        {
            _args = args;
        }
    }
}