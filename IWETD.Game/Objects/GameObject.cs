namespace IWETD.Game.Objects
{
    public class GameObject
    {
        public int Id { get; set; } = 0;

        public int X { get; set; }

        public int Y { get; set; }

        public string Texture { get; set; } = "BasicTile";

        public string Hitbox { get; set; } = "Square";

        public ObjectType ObjectType { get; set; } = ObjectType.Tile;

        public int Rotation { get; set; } = 0;

        public override string ToString() => $"{Id}|{X}|{Y}|{Texture}|{Hitbox}|{ObjectType}|{Rotation}";
    }

    public enum ObjectType
    {
        Tile,
        Spike,
        Item,
        TeleStart,
        TeleEnd,
        Key,
        Door
    }
}