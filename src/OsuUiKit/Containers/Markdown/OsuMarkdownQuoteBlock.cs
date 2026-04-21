// =============================================================================
// OsuUiKit — Extracted from ppy/osu (MIT Licence)
// SOURCE: osu.Game/Graphics/Containers/Markdown/OsuMarkdownQuoteBlock.cs
// EXTRACTED: 2026-04-21
// DEPENDENCIES: ppy.osu.Framework, ppy.osu.Game.Resources
// SEE ALSO: https://github.com/ppy/osu
// =============================================================================
﻿// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using Markdig.Syntax;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers.Markdown;
using osu.Framework.Graphics.Shapes;
using osu.Game.Overlays;

namespace OsuUiKit.Containers.Markdown
{
    public partial class OsuMarkdownQuoteBlock : MarkdownQuoteBlock
    {
        public OsuMarkdownQuoteBlock(QuoteBlock quoteBlock)
            : base(quoteBlock)
        {
        }

        protected override Drawable CreateBackground() => new QuoteBackground();

        public override MarkdownTextFlowContainer CreateTextFlow()
        {
            return base.CreateTextFlow().With(f => f.Margin = new MarginPadding
            {
                Vertical = 10,
                Horizontal = 20,
            });
        }

        private partial class QuoteBackground : Box
        {
            [BackgroundDependencyLoader]
            private void load(OverlayColourProvider colourProvider)
            {
                Anchor = Anchor.CentreLeft;
                Origin = Anchor.CentreLeft;
                RelativeSizeAxes = Axes.Y;
                Width = 2;
                Colour = colourProvider.Content2;
            }
        }
    }
}
