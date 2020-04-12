using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;

namespace IWETD.Game.Objects
{
    public class DrawableGameObject : CompositeDrawable, IGameObject
    {
        public GameObject GameObject { get; private set; } = new GameObject();

        public Drawable Hitbox;

        public virtual bool Solid => true;
        
        public DrawableGameObject() {}

        public DrawableGameObject(string objectString)
        {
            
        }
        
        public DrawableGameObject(GameObject gameObject)
        {
            GameObject = gameObject;
        }

        [BackgroundDependencyLoader]
        private void Load()
        {
            CreateHitbox();
            AddInternal(Hitbox);
        }

        private void CreateHitbox()
        {
            Hitbox.With(d =>
            {
                d.Alpha = 0;
                d.AlwaysPresent = true;
                d.Position = Position;
                d.Size = Size;
            });
        }

        // TODO: Player should be cached.
        public bool CheckHit(Drawable player)
            => player.BoundingBox.IntersectsWith(Hitbox.BoundingBox);
    }
}
