// =============================================================================
// OsuUiKit — Extracted from ppy/osu (MIT Licence)
// SOURCE: osu.Game/Graphics/Containers/ReverseChildIDFillFlowContainer.cs
// EXTRACTED: 2026-04-21
// DEPENDENCIES: ppy.osu.Framework, ppy.osu.Game.Resources
// SEE ALSO: https://github.com/ppy/osu
// =============================================================================
﻿// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;

namespace OsuUiKit.Containers
{
    public partial class ReverseChildIDFillFlowContainer<T> : FillFlowContainer<T> where T : Drawable
    {
        protected override int Compare(Drawable x, Drawable y) => CompareReverseChildID(x, y);
    }
}
