using osu.Framework.Testing;

namespace IWETD.Game.Tests
{
    public class IWETDTestBrowser : IWETDGameBase
    {
        protected override void LoadComplete()
        {
            base.LoadComplete();
            
            Add(new TestBrowser("IWETD.Game.Tests"));
        }
    }
}