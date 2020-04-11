using IWETD.Resources;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.IO.Stores;

namespace IWETD.Game
{
    public class IWETDGameBase : osu.Framework.Game
    {
        protected override Container<Drawable> Content { get; }
        
        private DependencyContainer _dependencies;

        protected override IReadOnlyDependencyContainer CreateChildDependencies(IReadOnlyDependencyContainer parent) => 
            _dependencies = new DependencyContainer(base.CreateChildDependencies(parent));

        [BackgroundDependencyLoader]
        private void Load()
        {
            Resources.AddStore(new DllResourceStore(IWETDResources.Assembly));
            
            _dependencies.Cache(this);
        }
    }
}