using IWETD.Game.IO;
using IWETD.Game.Objects;
using IWETD.Game.Screens.Rooms;
using osu.Framework.Graphics;
using osuTK;

namespace IWETD.Game.Graphics.Graphs
{
    public class Grid
    {
        public Vector2 Size;
        public Vector2 VectoredCellSize;
        public int CellSize = 0;

        public int TotalCellCount = 0;

        public Store<Drawable> Objects = new Store<Drawable>();

        public bool IsRendered = false;

        public Grid(Vector2 scale, int cellSize = 1)
        {
            Size = scale;
            CellSize = cellSize;

            TotalCellCount = (int)(scale.X * scale.Y) / cellSize;

        }

        public Grid(Vector2 scale, Vector2 cellSize)
        {
            Size = scale;
            VectoredCellSize = cellSize;

            TotalCellCount = (int)(scale.X * scale.Y) / (int)cellSize.X;
        }

        public void Render(Room room)
        {
            if (IsRendered == false)
            {
                IsRendered = true;
                foreach (Drawable obj in Objects)
                {
                    room.Add(obj);
                }
            }
        }

        public void Add(Drawable gameObject)
        {
            gameObject.Position = GetProperPosition(gameObject.Position);

            Objects.Add(gameObject);
        }

        public Vector2 GetProperPosition(Vector2 pos)
        {
            return new Vector2(pos.X * CellSize, pos.Y * CellSize);
        }
    }
}
