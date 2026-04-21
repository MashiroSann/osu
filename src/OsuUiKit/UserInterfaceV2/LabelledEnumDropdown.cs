// =============================================================================
// OsuUiKit — Extracted from ppy/osu (MIT Licence)
// SOURCE: osu.Game/Graphics/UserInterfaceV2/LabelledEnumDropdown.cs
// EXTRACTED: 2026-04-21
// DEPENDENCIES: ppy.osu.Framework, ppy.osu.Game.Resources
// SEE ALSO: https://github.com/ppy/osu
// =============================================================================
﻿// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;
using OsuUiKit.UserInterface;

namespace OsuUiKit.UserInterfaceV2
{
    public partial class LabelledEnumDropdown<TEnum> : LabelledDropdown<TEnum>
        where TEnum : struct, Enum
    {
        public LabelledEnumDropdown(bool padded)
            : base(padded)
        {
        }

        protected override OsuDropdown<TEnum> CreateDropdown() => new OsuEnumDropdown<TEnum>();
    }
}
