using osu.Framework.Configuration;
using osu.Framework.Platform;

namespace IWETD.Game.Configuration
{
    public class GameConfigManager : IniConfigManager<IWETDConfig>
    {
        protected override void InitialiseDefaults()
        {
            base.InitialiseDefaults();
        }
        public GameConfigManager(Storage storage) : base(storage)
        {

        }
    }

    public enum IWETDConfig
    {

    }
}
