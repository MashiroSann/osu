// =============================================================================
// OsuUiKit — Extracted from ppy/osu (MIT Licence)
// SOURCE: osu.Game/Graphics/UserInterface/PageSelector/PageEllipsis.cs
// EXTRACTED: 2026-04-21
// DEPENDENCIES: ppy.osu.Framework, ppy.osu.Game.Resources
// SEE ALSO: https://github.com/ppy/osu
// =============================================================================
﻿// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using OsuUiKit.Sprites;
using osu.Game.Overlays;

namespace OsuUiKit.UserInterface.PageSelector
{
    internal partial class PageEllipsis : CompositeDrawable
    {
        [BackgroundDependencyLoader]
        private void load(OverlayColourProvider colourProvider)
        {
            RelativeSizeAxes = Axes.Y;
            AutoSizeAxes = Axes.X;

            InternalChildren = new Drawable[]
            {
                new OsuSpriteText
                {
                    Font = OsuFont.GetFont(size: 12, weight: FontWeight.SemiBold),
                    Text = "...",
                    Colour = colourProvider.Light3,
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                }
            };
        }
    }
}
