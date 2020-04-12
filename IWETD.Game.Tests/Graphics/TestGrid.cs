using IWETD.Game.Graphics.Graphs;
using NUnit.Framework;
using osuTK;

namespace IWETD.Game.Tests.Graphics
{
    public class TestGrid
    {
        private Grid _grid = new Grid(new Vector2(512), 16);

        [Test]
        public void TestPositioning()
        {
            Assert.AreEqual(_grid.GetProperPosition(new Vector2(0)), new Vector2(0));
            Assert.AreEqual(_grid.GetProperPosition(new Vector2(1)), new Vector2(16));
            Assert.AreEqual(_grid.GetProperPosition(new Vector2(2, 1)), new Vector2(32, 16));
        }
    }
}
