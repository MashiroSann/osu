// =============================================================================
// OsuUiKit — Extracted from ppy/osu (MIT Licence)
// SOURCE: osu.Game/Graphics/Containers/Markdown/Footnotes/OsuMarkdownFootnote.cs
// EXTRACTED: 2026-04-21
// DEPENDENCIES: ppy.osu.Framework, ppy.osu.Game.Resources
// SEE ALSO: https://github.com/ppy/osu
// =============================================================================
// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using Markdig.Extensions.Footnotes;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers.Markdown;
using osu.Framework.Graphics.Containers.Markdown.Footnotes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Localisation;

namespace OsuUiKit.Containers.Markdown.Footnotes
{
    public partial class OsuMarkdownFootnote : MarkdownFootnote
    {
        public OsuMarkdownFootnote(Footnote footnote)
            : base(footnote)
        {
        }

        public override SpriteText CreateOrderMarker(int order) => CreateSpriteText().With(marker =>
        {
            marker.Text = LocalisableString.Format("{0}.", order);
        });

        public override MarkdownTextFlowContainer CreateTextFlow() => base.CreateTextFlow().With(textFlow =>
        {
            textFlow.Margin = new MarginPadding { Left = 30 };
        });
    }
}
