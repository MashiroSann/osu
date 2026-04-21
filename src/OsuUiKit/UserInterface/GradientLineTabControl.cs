// =============================================================================
// OsuUiKit — Extracted from ppy/osu (MIT Licence)
// SOURCE: osu.Game/Graphics/UserInterface/GradientLineTabControl.cs
// EXTRACTED: 2026-04-21
// DEPENDENCIES: ppy.osu.Framework, ppy.osu.Game.Resources
// SEE ALSO: https://github.com/ppy/osu
// =============================================================================
// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

#nullable disable

using osu.Framework.Graphics.UserInterface;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osuTK;
using osu.Framework.Graphics.Shapes;
using osuTK.Graphics;
using osu.Framework.Graphics.Colour;

namespace OsuUiKit.UserInterface
{
    public abstract partial class GradientLineTabControl<TModel> : PageTabControl<TModel>
    {
        protected Color4 LineColour
        {
            get => line.Colour;
            set => line.Colour = value;
        }

        private readonly GradientLine line;

        protected GradientLineTabControl()
        {
            RelativeSizeAxes = Axes.X;

            AddInternal(line = new GradientLine
            {
                Anchor = Anchor.BottomCentre,
                Origin = Anchor.BottomCentre,
            });
        }

        protected override Dropdown<TModel> CreateDropdown() => null;

        protected override TabFillFlowContainer CreateTabFlow() => new TabFillFlowContainer
        {
            Anchor = Anchor.BottomCentre,
            Origin = Anchor.BottomCentre,
            AutoSizeAxes = Axes.X,
            RelativeSizeAxes = Axes.Y,
            Direction = FillDirection.Horizontal,
            Spacing = new Vector2(20, 0),
        };

        private partial class GradientLine : GridContainer
        {
            public GradientLine()
            {
                RelativeSizeAxes = Axes.X;
                Size = new Vector2(0.8f, 1f);

                Content = new[]
                {
                    new Drawable[]
                    {
                        new Box
                        {
                            RelativeSizeAxes = Axes.Both,
                            Colour = ColourInfo.GradientHorizontal(Color4.Transparent, Colour)
                        },
                        new Box
                        {
                            RelativeSizeAxes = Axes.Both,
                            Colour = ColourInfo.GradientHorizontal(Colour, Color4.Transparent)
                        },
                    }
                };
            }
        }
    }
}
