// =============================================================================
// OsuUiKit — Extracted from ppy/osu (MIT Licence)
// SOURCE: osu.Game/Graphics/UserInterfaceV2/OsuHexColourPicker.cs
// EXTRACTED: 2026-04-21
// DEPENDENCIES: ppy.osu.Framework, ppy.osu.Game.Resources
// SEE ALSO: https://github.com/ppy/osu
// =============================================================================
﻿// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.UserInterface;
using OsuUiKit.UserInterface;
using osu.Game.Overlays;

namespace OsuUiKit.UserInterfaceV2
{
    public partial class OsuHexColourPicker : HexColourPicker
    {
        public OsuHexColourPicker()
        {
            Padding = new MarginPadding(20);
            Spacing = 20;
        }

        [BackgroundDependencyLoader(true)]
        private void load(OverlayColourProvider? overlayColourProvider, OsuColour osuColour)
        {
            Background.Colour = overlayColourProvider?.Dark6 ?? osuColour.GreySeaFoamDarker;
        }

        protected override TextBox CreateHexCodeTextBox() => new OsuTextBox();
        protected override ColourPreview CreateColourPreview() => new OsuColourPreview();

        private partial class OsuColourPreview : ColourPreview
        {
            private readonly Box preview;

            public OsuColourPreview()
            {
                InternalChild = new CircularContainer
                {
                    RelativeSizeAxes = Axes.Both,
                    Masking = true,
                    Child = preview = new Box
                    {
                        RelativeSizeAxes = Axes.Both
                    }
                };
            }

            protected override void LoadComplete()
            {
                base.LoadComplete();

                Current.BindValueChanged(colour => preview.Colour = colour.NewValue, true);
            }
        }
    }
}
