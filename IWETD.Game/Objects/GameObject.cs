using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osuTK;

namespace IWETD.Game.Objects
{
    public abstract class GameObject : Sprite, IGameObject
    {
        public virtual bool Clippable => false;
        public GameObject(Vector2 pos, Vector2 size)
        {
            Size = size;
        }

        [BackgroundDependencyLoader]
        public virtual void Load(TextureStore textures)
        {

        }
    }
}
