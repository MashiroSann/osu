// =============================================================================
// OsuUiKit — Extracted from ppy/osu (MIT Licence)
// SOURCE: osu.Game/Graphics/UserInterface/CommaSeparatedScoreCounter.cs
// EXTRACTED: 2026-04-21
// DEPENDENCIES: ppy.osu.Framework, ppy.osu.Game.Resources
// SEE ALSO: https://github.com/ppy/osu
// =============================================================================
﻿// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Framework.Extensions.LocalisationExtensions;
using osu.Framework.Graphics;
using osu.Framework.Localisation;
using OsuUiKit.Sprites;

namespace OsuUiKit.UserInterface
{
    public abstract partial class CommaSeparatedScoreCounter : RollingCounter<double>
    {
        protected override double RollingDuration => 1000;
        protected override Easing RollingEasing => Easing.Out;

        protected override double GetProportionalDuration(double currentValue, double newValue) =>
            currentValue > newValue ? currentValue - newValue : newValue - currentValue;

        protected override LocalisableString FormatCount(double count) => ((long)count).ToLocalisableString(@"N0");

        protected override OsuSpriteText CreateSpriteText()
            => base.CreateSpriteText().With(s => s.Font = s.Font.With(fixedWidth: true));
    }
}
