using IWETD.Game.IO;
using IWETD.Game.Objects;
using osuTK;

namespace IWETD.Game.Graphics.Graphs
{
    public class Grid
    {
        public Vector2 Size;
        public int CellCount = 0;
        public int CellSize = 0;

        public Store<DrawableGameObject> Objects = new Store<DrawableGameObject>();

        public Grid(Vector2 scale, int cellSize = 1)
        {
            Size = scale;
            CellCount = (int)(scale.X * scale.Y) / cellSize;
            CellSize = cellSize;
        }

        public void Add(Vector2 pos, DrawableGameObject gameObject)
        {
            gameObject.X = GetProperPosition(pos).X;
            gameObject.Y = GetProperPosition(pos).Y;

            Objects.Add(gameObject);
        }

        public Vector2 GetProperPosition(Vector2 pos)
        {
            return new Vector2(pos.X * CellSize, pos.Y * CellSize);
        }
    }
}
