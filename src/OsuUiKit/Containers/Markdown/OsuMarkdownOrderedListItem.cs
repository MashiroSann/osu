// =============================================================================
// OsuUiKit — Extracted from ppy/osu (MIT Licence)
// SOURCE: osu.Game/Graphics/Containers/Markdown/OsuMarkdownOrderedListItem.cs
// EXTRACTED: 2026-04-21
// DEPENDENCIES: ppy.osu.Framework, ppy.osu.Game.Resources
// SEE ALSO: https://github.com/ppy/osu
// =============================================================================
﻿// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Framework.Graphics;
using osu.Framework.Graphics.Sprites;

namespace OsuUiKit.Containers.Markdown
{
    public partial class OsuMarkdownOrderedListItem : OsuMarkdownListItem
    {
        private const float left_padding = 30;

        private readonly int order;

        public OsuMarkdownOrderedListItem(int order)
        {
            this.order = order;
            Padding = new MarginPadding { Left = left_padding };
        }

        protected override SpriteText CreateMarker() => base.CreateMarker().With(t =>
        {
            t.X = -left_padding;
            t.Text = $"{order}.";
        });
    }
}
