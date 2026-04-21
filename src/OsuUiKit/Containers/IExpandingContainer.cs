// =============================================================================
// OsuUiKit — Extracted from ppy/osu (MIT Licence)
// SOURCE: osu.Game/Graphics/Containers/IExpandingContainer.cs
// EXTRACTED: 2026-04-21
// DEPENDENCIES: ppy.osu.Framework, ppy.osu.Game.Resources
// SEE ALSO: https://github.com/ppy/osu
// =============================================================================
﻿// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Framework.Allocation;
using osu.Framework.Graphics.Containers;

namespace OsuUiKit.Containers
{
    /// <summary>
    /// A target expanding container that should be resolved by children <see cref="IExpandable"/>s to propagate state changes.
    /// </summary>
    [Cached(typeof(IExpandingContainer))]
    public interface IExpandingContainer : IContainer, IExpandable
    {
    }
}
