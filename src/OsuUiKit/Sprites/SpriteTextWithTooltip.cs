// =============================================================================
// OsuUiKit — Extracted from ppy/osu (MIT Licence)
// SOURCE: osu.Game/Graphics/Sprites/SpriteTextWithTooltip.cs
// EXTRACTED: 2026-04-21
// DEPENDENCIES: ppy.osu.Framework, ppy.osu.Game.Resources
// SEE ALSO: https://github.com/ppy/osu
// =============================================================================
// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Framework.Graphics.Cursor;
using osu.Framework.Localisation;

namespace OsuUiKit.Sprites
{
    /// <summary>
    /// An <see cref="OsuSpriteText"/> with a publicly settable tooltip text.
    /// </summary>
    internal partial class SpriteTextWithTooltip : OsuSpriteText, IHasTooltip
    {
        public LocalisableString TooltipText { get; set; }
    }
}
