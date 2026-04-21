// =============================================================================
// OsuUiKit — Extracted from ppy/osu (MIT Licence)
// SOURCE: osu.Game/Graphics/UserInterface/TernaryStateMenuItem.cs
// EXTRACTED: 2026-04-21
// DEPENDENCIES: ppy.osu.Framework, ppy.osu.Game.Resources
// SEE ALSO: https://github.com/ppy/osu
// =============================================================================
// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

#nullable disable

using System;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Localisation;

namespace OsuUiKit.UserInterface
{
    /// <summary>
    /// An <see cref="OsuMenuItem"/> with three possible states.
    /// </summary>
    public abstract class TernaryStateMenuItem : StatefulMenuItem<TernaryState>
    {
        /// <summary>
        /// Creates a new <see cref="TernaryStateMenuItem"/>.
        /// </summary>
        /// <param name="text">The text to display.</param>
        /// <param name="nextStateFunction">A function to inform what the next state should be when this item is clicked.</param>
        /// <param name="type">The type of action which this <see cref="TernaryStateMenuItem"/> performs.</param>
        /// <param name="action">A delegate to be invoked when this <see cref="TernaryStateMenuItem"/> is pressed.</param>
        protected TernaryStateMenuItem(LocalisableString text, Func<TernaryState, TernaryState> nextStateFunction, MenuItemType type = MenuItemType.Standard, Action<TernaryState> action = null)
            : base(text, nextStateFunction, type, action)
        {
        }

        public override IconUsage? GetIconForState(TernaryState state)
        {
            switch (state)
            {
                case TernaryState.Indeterminate:
                    return FontAwesome.Solid.DotCircle;

                case TernaryState.True:
                    return FontAwesome.Solid.Check;
            }

            return null;
        }
    }
}
