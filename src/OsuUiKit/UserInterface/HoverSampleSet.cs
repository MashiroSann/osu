// =============================================================================
// OsuUiKit — Extracted from ppy/osu (MIT Licence)
// SOURCE: osu.Game/Graphics/UserInterface/HoverSampleSet.cs
// EXTRACTED: 2026-04-21
// DEPENDENCIES: ppy.osu.Framework, ppy.osu.Game.Resources
// SEE ALSO: https://github.com/ppy/osu
// =============================================================================
﻿// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System.ComponentModel;

namespace OsuUiKit.UserInterface
{
    public enum HoverSampleSet
    {
        [Description("default")]
        Default,

        [Description("button")]
        Button,

        [Description("button-sidebar")]
        ButtonSidebar,

        [Description("tabselect")]
        TabSelect,

        [Description("dialog-cancel")]
        DialogCancel,

        [Description("dialog-ok")]
        DialogOk,

        [Description("menu-open")]
        MenuOpen,
    }
}
