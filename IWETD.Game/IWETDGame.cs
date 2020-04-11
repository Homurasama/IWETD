using osu.Framework.Allocation;

namespace IWETD.Game
{
    public class IWETDGame : IWETDGameBase
    {
        private readonly string[] _args;
        private DependencyContainer _dependencies;

        public IWETDGame(string[] args)
        {
            _args = args;
        }

        protected override IReadOnlyDependencyContainer CreateChildDependencies(IReadOnlyDependencyContainer parent) =>
            _dependencies = new DependencyContainer(base.CreateChildDependencies(parent));

        [BackgroundDependencyLoader]
        private void Load()
        {
            _dependencies.CacheAs(this);
        }
    }
}