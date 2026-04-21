// =============================================================================
// OsuUiKit — Extracted from ppy/osu (MIT Licence)
// SOURCE: osu.Game/Graphics/UserInterfaceV2/LabelledComponent.cs
// EXTRACTED: 2026-04-21
// DEPENDENCIES: ppy.osu.Framework, ppy.osu.Game.Resources
// SEE ALSO: https://github.com/ppy/osu
// =============================================================================
﻿// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Graphics.UserInterface;

namespace OsuUiKit.UserInterfaceV2
{
    public abstract partial class LabelledComponent<TDrawable, TValue> : LabelledDrawable<TDrawable>, IHasCurrentValue<TValue>
        where TDrawable : Drawable, IHasCurrentValue<TValue>
    {
        protected LabelledComponent(bool padded)
            : base(padded)
        {
        }

        public Bindable<TValue> Current
        {
            get => Component.Current;
            set => Component.Current = value;
        }
    }
}
