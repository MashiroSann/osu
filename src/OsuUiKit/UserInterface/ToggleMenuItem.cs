// =============================================================================
// OsuUiKit — Extracted from ppy/osu (MIT Licence)
// SOURCE: osu.Game/Graphics/UserInterface/ToggleMenuItem.cs
// EXTRACTED: 2026-04-21
// DEPENDENCIES: ppy.osu.Framework, ppy.osu.Game.Resources
// SEE ALSO: https://github.com/ppy/osu
// =============================================================================
// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Localisation;

namespace OsuUiKit.UserInterface
{
    /// <summary>
    /// An <see cref="OsuMenuItem"/> which displays an enabled or disabled state.
    /// </summary>
    public class ToggleMenuItem : StatefulMenuItem<bool>
    {
        /// <summary>
        /// Creates a new <see cref="ToggleMenuItem"/>.
        /// </summary>
        /// <param name="text">The text to display.</param>
        /// <param name="type">The type of action which this <see cref="ToggleMenuItem"/> performs.</param>
        public ToggleMenuItem(LocalisableString text, MenuItemType type = MenuItemType.Standard)
            : this(text, type, null)
        {
        }

        /// <summary>
        /// Creates a new <see cref="ToggleMenuItem"/>.
        /// </summary>
        /// <param name="text">The text to display.</param>
        /// <param name="type">The type of action which this <see cref="ToggleMenuItem"/> performs.</param>
        /// <param name="action">A delegate to be invoked when this <see cref="ToggleMenuItem"/> is pressed.</param>
        public ToggleMenuItem(LocalisableString text, MenuItemType type, Action<bool>? action)
            : base(text, value => !value, type, action)
        {
        }

        public override IconUsage? GetIconForState(bool state) => state ? FontAwesome.Solid.Check : null;
    }
}
