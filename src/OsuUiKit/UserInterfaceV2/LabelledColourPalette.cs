// =============================================================================
// OsuUiKit — Extracted from ppy/osu (MIT Licence)
// SOURCE: osu.Game/Graphics/UserInterfaceV2/LabelledColourPalette.cs
// EXTRACTED: 2026-04-21
// DEPENDENCIES: ppy.osu.Framework, ppy.osu.Game.Resources
// SEE ALSO: https://github.com/ppy/osu
// =============================================================================
﻿// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Localisation;

namespace OsuUiKit.UserInterfaceV2
{
    public partial class LabelledColourPalette : LabelledDrawable<ColourPalette>
    {
        public LabelledColourPalette()
            : base(true)
        {
        }

        public BindableList<Colour4> Colours => Component.Colours;

        public LocalisableString ColourNamePrefix
        {
            get => Component.ColourNamePrefix;
            set => Component.ColourNamePrefix = value;
        }

        protected override ColourPalette CreateComponent() => new ColourPalette();
    }
}
