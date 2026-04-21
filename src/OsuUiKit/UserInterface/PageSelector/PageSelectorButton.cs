// =============================================================================
// OsuUiKit — Extracted from ppy/osu (MIT Licence)
// SOURCE: osu.Game/Graphics/UserInterface/PageSelector/PageSelectorButton.cs
// EXTRACTED: 2026-04-21
// DEPENDENCIES: ppy.osu.Framework, ppy.osu.Game.Resources
// SEE ALSO: https://github.com/ppy/osu
// =============================================================================
﻿// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

#nullable disable

using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics;
using osu.Framework.Allocation;
using osu.Framework.Graphics.Shapes;
using OsuUiKit.Containers;
using osu.Framework.Input.Events;
using JetBrains.Annotations;
using osu.Game.Overlays;

namespace OsuUiKit.UserInterface.PageSelector
{
    public abstract partial class PageSelectorButton : OsuClickableContainer
    {
        protected const int DURATION = 200;

        [Resolved]
        protected OverlayColourProvider ColourProvider { get; private set; }

        protected Box Background;

        protected PageSelectorButton()
        {
            AutoSizeAxes = Axes.X;
            Height = 20;
        }

        [BackgroundDependencyLoader]
        private void load()
        {
            Add(new CircularContainer
            {
                RelativeSizeAxes = Axes.Y,
                AutoSizeAxes = Axes.X,
                Masking = true,
                Children = new[]
                {
                    Background = new Box
                    {
                        RelativeSizeAxes = Axes.Both
                    },
                    CreateContent().With(content =>
                    {
                        content.Anchor = Anchor.Centre;
                        content.Origin = Anchor.Centre;
                        content.Margin = new MarginPadding { Horizontal = 10 };
                    })
                }
            });
        }

        [NotNull]
        protected abstract Drawable CreateContent();

        protected override bool OnHover(HoverEvent e)
        {
            UpdateHoverState();
            return base.OnHover(e);
        }

        protected override void OnHoverLost(HoverLostEvent e)
        {
            base.OnHoverLost(e);
            UpdateHoverState();
        }

        protected abstract void UpdateHoverState();
    }
}
