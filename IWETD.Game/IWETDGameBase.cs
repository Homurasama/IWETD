using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using IWETD.Game.Database;
using IWETD.Game.Input;
using IWETD.Resources;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.IO.Stores;

namespace IWETD.Game
{
    public class IWETDGameBase : osu.Framework.Game, ICanAcceptFiles
    {
        private DependencyContainer _dependencies;

        private Container content;

        protected override Container<Drawable> Content => content;

        protected override IReadOnlyDependencyContainer CreateChildDependencies(IReadOnlyDependencyContainer parent) =>
            _dependencies = new DependencyContainer(base.CreateChildDependencies(parent));

        [BackgroundDependencyLoader]
        private void Load()
        {
            Resources.AddStore(new DllResourceStore(IWETDResources.Assembly));

            _dependencies.CacheAs(this);
            
            base.Content.Add(new GlobalActionContainer
            {
                RelativeSizeAxes = Axes.Both,
                Child = content = new DrawSizePreservingFillContainer()
            });
        }
        
        private readonly List<ICanAcceptFiles> fileImporters = new List<ICanAcceptFiles>();

        public async Task Import(params string[] paths)
        {
            var extension = Path.GetExtension(paths.First())?.ToLowerInvariant();

            foreach (var importer in fileImporters)
            {
                if (importer.HandledExtensions.Contains(extension))
                    await importer.Import(paths);
            }
        }

        public string[] HandledExtensions => fileImporters.SelectMany(i => i.HandledExtensions).ToArray();
    }
}