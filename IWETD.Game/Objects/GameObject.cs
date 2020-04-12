using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
namespace IWETD.Game.Objects
{
    public abstract class GameObject : CompositeDrawable, IGameObject
    {
        protected abstract Drawable Hitbox { get; }
        public virtual bool Solid => true;

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
