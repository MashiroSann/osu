// OsuUiKit Demo Game — Component gallery host.

using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osuTK.Graphics;

namespace OsuUiKit.Demo
{
    /// <summary>
    /// A minimal osu-framework Game subclass that renders a scrollable gallery
    /// of OsuUiKit controls so developers can preview components in isolation.
    /// </summary>
    /// <remarks>
    /// Add new components to <see cref="load"/> to include them in the gallery.
    /// </remarks>
    public partial class OsuUiKitDemoGame : osu.Framework.Game
    {
        [BackgroundDependencyLoader]
        private void load()
        {
            // Background
            Add(new osu.Framework.Graphics.Shapes.Box
            {
                RelativeSizeAxes = Axes.Both,
                Colour = new Color4(0.12f, 0.12f, 0.12f, 1f),
            });

            // Gallery container
            Add(new BasicScrollContainer
            {
                RelativeSizeAxes = Axes.Both,
                Padding = new MarginPadding(20),
                Child = new FillFlowContainer
                {
                    RelativeSizeAxes = Axes.X,
                    AutoSizeAxes = Axes.Y,
                    Direction = FillDirection.Vertical,
                    Spacing = new osuTK.Vector2(0, 16),
                    Children = new Drawable[]
                    {
                        new osu.Framework.Graphics.Sprites.SpriteText
                        {
                            Text = "OsuUiKit Component Gallery",
                            Font = new osu.Framework.Graphics.Sprites.FontUsage("Torus", 28, "Bold"),
                            Colour = Color4.White,
                        },
                        new osu.Framework.Graphics.Sprites.SpriteText
                        {
                            Text = "Add OsuUiKit components here to preview them.",
                            Font = new osu.Framework.Graphics.Sprites.FontUsage("Torus", 16),
                            Colour = new Color4(0.7f, 0.7f, 0.7f, 1f),
                        },
                    }
                }
            });
        }
    }
}
