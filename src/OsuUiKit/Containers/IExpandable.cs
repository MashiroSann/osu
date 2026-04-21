// =============================================================================
// OsuUiKit — Extracted from ppy/osu (MIT Licence)
// SOURCE: osu.Game/Graphics/Containers/IExpandable.cs
// EXTRACTED: 2026-04-21
// DEPENDENCIES: ppy.osu.Framework, ppy.osu.Game.Resources
// SEE ALSO: https://github.com/ppy/osu
// =============================================================================
﻿// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Framework.Bindables;
using osu.Framework.Graphics;

namespace OsuUiKit.Containers
{
    /// <summary>
    /// An interface for drawables with ability to expand/contract.
    /// </summary>
    public interface IExpandable : IDrawable
    {
        /// <summary>
        /// Whether this drawable is in an expanded state.
        /// </summary>
        BindableBool Expanded { get; }
    }
}
