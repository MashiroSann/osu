// =============================================================================
// OsuUiKit — Extracted from ppy/osu (MIT Licence)
// SOURCE: osu.Game/Graphics/UserInterface/TimeSlider.cs
// EXTRACTED: 2026-04-21
// DEPENDENCIES: ppy.osu.Framework, ppy.osu.Game.Resources
// SEE ALSO: https://github.com/ppy/osu
// =============================================================================
﻿// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Framework.Localisation;

namespace OsuUiKit.UserInterface
{
    /// <summary>
    /// A slider bar which displays a millisecond time value.
    /// </summary>
    public partial class TimeSlider : RoundedSliderBar<double>
    {
        public override LocalisableString TooltipText => $"{base.TooltipText} ms";
    }
}
