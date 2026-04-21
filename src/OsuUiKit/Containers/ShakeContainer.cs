// =============================================================================
// OsuUiKit — Extracted from ppy/osu (MIT Licence)
// SOURCE: osu.Game/Graphics/Containers/ShakeContainer.cs
// EXTRACTED: 2026-04-21
// DEPENDENCIES: ppy.osu.Framework, ppy.osu.Game.Resources
// SEE ALSO: https://github.com/ppy/osu
// =============================================================================
﻿// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Framework.Graphics.Containers;
using osu.Game.Extensions;

namespace OsuUiKit.Containers
{
    /// <summary>
    /// A container that adds the ability to shake its contents.
    /// </summary>
    public partial class ShakeContainer : Container
    {
        /// <summary>
        /// The length of a single shake.
        /// </summary>
        public float ShakeDuration = 80;

        /// <summary>
        /// Shake the contents of this container.
        /// </summary>
        /// <param name="maximumLength">The maximum length the shake should last.</param>
        public void Shake(double? maximumLength = null) => this.Shake(ShakeDuration, maximumLength: maximumLength);
    }
}
