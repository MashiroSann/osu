// =============================================================================
// OsuUiKit — Extracted from ppy/osu (MIT Licence)
// SOURCE: osu.Game/Graphics/Sprites/OsuSpriteText.cs
// EXTRACTED: 2026-04-21
// DEPENDENCIES: ppy.osu.Framework, ppy.osu.Game.Resources
// SEE ALSO: https://github.com/ppy/osu
// =============================================================================
﻿// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;
using osu.Framework.Graphics.Sprites;

namespace OsuUiKit.Sprites
{
    public partial class OsuSpriteText : SpriteText
    {
        [Obsolete("Use TruncatingSpriteText instead.")]
        public new bool Truncate
        {
            set => throw new InvalidOperationException($"Use {nameof(TruncatingSpriteText)} instead.");
        }

        public OsuSpriteText()
        {
            Shadow = true;
            Font = OsuFont.Default;
        }
    }
}
