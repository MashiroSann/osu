// =============================================================================
// OsuUiKit — Extracted from ppy/osu (MIT Licence)
// SOURCE: osu.Game/Graphics/UserInterfaceV2/LabelledDropdown.cs
// EXTRACTED: 2026-04-21
// DEPENDENCIES: ppy.osu.Framework, ppy.osu.Game.Resources
// SEE ALSO: https://github.com/ppy/osu
// =============================================================================
﻿// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System.Collections.Generic;
using osu.Framework.Graphics;
using OsuUiKit.UserInterface;

namespace OsuUiKit.UserInterfaceV2
{
    public partial class LabelledDropdown<TItem> : LabelledComponent<OsuDropdown<TItem>, TItem>
    {
        public LabelledDropdown(bool padded)
            : base(padded)
        {
        }

        public IEnumerable<TItem> Items
        {
            get => Component.Items;
            set => Component.Items = value;
        }

        public float DropdownWidth
        {
            get => Component.Width;
            set => Component.Width = value;
        }

        protected sealed override OsuDropdown<TItem> CreateComponent() => CreateDropdown().With(d =>
        {
            d.RelativeSizeAxes = Axes.X;
        });

        protected virtual OsuDropdown<TItem> CreateDropdown() => new Dropdown();

        private partial class Dropdown : OsuDropdown<TItem>
        {
            protected override DropdownMenu CreateMenu() => base.CreateMenu().With(menu => menu.MaxHeight = 200);
        }
    }
}
