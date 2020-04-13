using IWETD.Game.Attributes;

namespace IWETD.Game.Objects
{
    public class GameObject
    {
        [GameProperty]
        public int Id { get; set; } = 0;

        [GameProperty]
        public int X { get; set; }

        [GameProperty]
        public int Y { get; set; }

        [GameProperty]
        public string Texture { get; set; } = "BasicTile";

        [GameProperty]
        public string Hitbox { get; set; } = "Square";

        [GameProperty]
        public ObjectType ObjectType { get; set; } = ObjectType.Tile;

        [GameProperty]
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