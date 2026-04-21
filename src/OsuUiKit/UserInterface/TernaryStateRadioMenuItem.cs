// =============================================================================
// OsuUiKit — Extracted from ppy/osu (MIT Licence)
// SOURCE: osu.Game/Graphics/UserInterface/TernaryStateRadioMenuItem.cs
// EXTRACTED: 2026-04-21
// DEPENDENCIES: ppy.osu.Framework, ppy.osu.Game.Resources
// SEE ALSO: https://github.com/ppy/osu
// =============================================================================
// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

#nullable disable

using System;
using osu.Framework.Localisation;

namespace OsuUiKit.UserInterface
{
    /// <summary>
    /// A ternary state menu item which will always set the item to <c>true</c> on click, even if already <c>true</c>.
    /// </summary>
    public class TernaryStateRadioMenuItem : TernaryStateMenuItem
    {
        /// <summary>
        /// Creates a new <see cref="TernaryStateMenuItem"/>.
        /// </summary>
        /// <param name="text">The text to display.</param>
        /// <param name="type">The type of action which this <see cref="TernaryStateMenuItem"/> performs.</param>
        /// <param name="action">A delegate to be invoked when this <see cref="TernaryStateMenuItem"/> is pressed.</param>
        public TernaryStateRadioMenuItem(LocalisableString text, MenuItemType type = MenuItemType.Standard, Action<TernaryState> action = null)
            : base(text, getNextState, type, action)
        {
        }

        private static TernaryState getNextState(TernaryState state) => TernaryState.True;
    }
}
