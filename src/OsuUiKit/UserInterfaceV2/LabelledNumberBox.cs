// =============================================================================
// OsuUiKit — Extracted from ppy/osu (MIT Licence)
// SOURCE: osu.Game/Graphics/UserInterfaceV2/LabelledNumberBox.cs
// EXTRACTED: 2026-04-21
// DEPENDENCIES: ppy.osu.Framework, ppy.osu.Game.Resources
// SEE ALSO: https://github.com/ppy/osu
// =============================================================================
﻿// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using OsuUiKit.UserInterface;

namespace OsuUiKit.UserInterfaceV2
{
    public partial class LabelledNumberBox : LabelledTextBox
    {
        protected override OsuTextBox CreateTextBox() => new OsuNumberBox();
    }
}
