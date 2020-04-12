namespace IWETD.Game.Objects
{
    public class GameObject
    {
        public int X { get; set; }

        public int Y { get; set; }

        public string Texture { get; set; }

        public string Hitbox { get; set; }

        public override string ToString() => $"{X}|{Y}|{Texture}|{Hitbox}";
    }
}