// =============================================================================
// OsuUiKit — Extracted from ppy/osu (MIT Licence)
// SOURCE: osu.Game/Graphics/Containers/Markdown/OsuMarkdownImage.cs
// EXTRACTED: 2026-04-21
// DEPENDENCIES: ppy.osu.Framework, ppy.osu.Game.Resources
// SEE ALSO: https://github.com/ppy/osu
// =============================================================================
﻿// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using Markdig.Syntax.Inlines;
using osu.Framework.Graphics.Containers.Markdown;
using osu.Framework.Graphics.Cursor;
using osu.Framework.Localisation;

namespace OsuUiKit.Containers.Markdown
{
    public partial class OsuMarkdownImage : MarkdownImage, IHasTooltip
    {
        public LocalisableString TooltipText { get; }

        public OsuMarkdownImage(LinkInline linkInline)
            : base($"https://osu.ppy.sh/media-url?url={linkInline.Url}")
        {
            TooltipText = linkInline.Title;
        }
    }
}
