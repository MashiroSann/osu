// =============================================================================
// OsuUiKit — Extracted from ppy/osu (MIT Licence)
// SOURCE: osu.Game/Graphics/UserInterface/OsuMenuItem.cs
// EXTRACTED: 2026-04-21
// DEPENDENCIES: ppy.osu.Framework, ppy.osu.Game.Resources
// SEE ALSO: https://github.com/ppy/osu
// =============================================================================
﻿// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.UserInterface;
using osu.Framework.Localisation;

namespace OsuUiKit.UserInterface
{
    public class OsuMenuItem : MenuItem
    {
        public readonly MenuItemType Type;

        public Hotkey Hotkey { get; init; }

        public IconUsage Icon { get; init; }

        public OsuMenuItem(LocalisableString text, MenuItemType type = MenuItemType.Standard)
            : this(text, type, null)
        {
        }

        public OsuMenuItem(LocalisableString text, MenuItemType type, Action? action)
            : base(text, action)
        {
            Type = type;
        }
    }
}
