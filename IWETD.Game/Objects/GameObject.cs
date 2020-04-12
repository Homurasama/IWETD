using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
namespace IWETD.Game.Objects
{
    public abstract class GameObject : CompositeDrawable, IGameObject
    {
        protected abstract Hitbox HitboxType { get; }
        public virtual bool Solid => true;

        private Drawable _hitbox;

        [BackgroundDependencyLoader]
        private void Load()
        {
            CreateHitbox();
            AddInternal(_hitbox);
        }

        private void CreateHitbox()
        {
            switch (HitboxType)
            {
                case Hitbox.Square:
                    _hitbox = CreateDrawable(new Box());
                    
                    break;
                
                case Hitbox.Triangle:
                    _hitbox = CreateDrawable(new Triangle());
                    
                    break;
            }

            Drawable CreateDrawable(Drawable drawable)
                => drawable.With(d =>
                {
                    d.Alpha = 0;
                    d.AlwaysPresent = true;
                    d.Position = Position;
                    d.Size = Size;
                });
        }

        // TODO: Player should be cached.
        public bool CheckHit(Drawable player)
            => player.BoundingBox.IntersectsWith(_hitbox.BoundingBox);
    }

    public enum Hitbox
    {
        Square,
        Triangle,
    }
}
