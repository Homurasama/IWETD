using System;
using System.Collections.Generic;
using System.Text;
using osu.Framework.Allocation;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;

namespace IWETD.Game.Graphics
{
    public class DrawableBackground : CompositeDrawable, IBackground
    {
        public string BackgroundTexture { get; set; }

        public DrawableBackground()
        {

        }

        public DrawableBackground(string backgroundTexture)
        {
            BackgroundTexture = backgroundTexture;
        }

        [BackgroundDependencyLoader]
        private void Load(TextureStore store)
        {
            AddInternal(drawable: new Sprite
            {
                Texture = store.Get("Background/" + BackgroundTexture),
                Size = Size
            });
        }

        public override string ToString()
        {
            return $"{BackgroundTexture}";
        }
    }
}
