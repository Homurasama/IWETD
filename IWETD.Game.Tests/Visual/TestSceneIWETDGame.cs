using System;
using System.Collections.Generic;
using NUnit.Framework;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Platform;
using osu.Framework.Testing;
using osuTK.Graphics;

namespace IWETD.Game.Tests.Visual
{
    [TestFixture]
    public class TestSceneIWETDGame : TestScene
    {
        private IReadOnlyList<Type> RequiredGameDependencies => new[]
        {
            typeof(IWETDGame)
        };

        private IReadOnlyList<Type> RequiredGameBaseDependencies => new[]
        {
            typeof(IWETDGameBase)
        };

        [BackgroundDependencyLoader]
        private void Load(GameHost host, IWETDGameBase gameBase)
        {
            var game = new IWETDGame(null);
            game.SetHost(host);

            Children = new Drawable[]
            {
                new Box
                {
                    Colour = Color4.Black,
                    RelativeSizeAxes = Axes.Both
                },
                game
            };

            AddUntilStep("wait for load", () => game.IsLoaded);

            AddAssert("check IWETDGame DI members", () =>
            {
                foreach (var type in RequiredGameDependencies)
                    if (game.Dependencies.Get(type) == null)
                        throw new InvalidOperationException($"{type} has not been cached");

                return true;
            });

            AddAssert("check IWETDGameBase DI members", () =>
            {
                foreach (var type in RequiredGameBaseDependencies)
                    if (game.Dependencies.Get(type) == null)
                        throw new InvalidOperationException($"{type} has not been cached");

                return true;
            });
        }
    }
}