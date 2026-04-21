// =============================================================================
// OsuUiKit — Extracted from ppy/osu (MIT Licence)
// SOURCE: osu.Game/Graphics/UserInterfaceV2/FileSelection/HiddenFilesToggleCheckbox.cs
// EXTRACTED: 2026-04-21
// DEPENDENCIES: ppy.osu.Framework, ppy.osu.Game.Resources
// SEE ALSO: https://github.com/ppy/osu
// =============================================================================
// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Framework.Allocation;
using osu.Framework.Graphics;
using OsuUiKit.UserInterface;
using osu.Game.Localisation;
using osu.Game.Overlays;
using osuTK;
using osuTK.Graphics;

namespace OsuUiKit.UserInterfaceV2.FileSelection
{
    internal partial class HiddenFilesToggleCheckbox : OsuCheckbox
    {
        public HiddenFilesToggleCheckbox()
        {
            RelativeSizeAxes = Axes.None;
            AutoSizeAxes = Axes.None;
            Size = new Vector2(140, OsuDirectorySelectorBreadcrumbDisplay.HEIGHT);
            Margin = new MarginPadding { Right = OsuDirectorySelectorBreadcrumbDisplay.HORIZONTAL_PADDING, };
            Anchor = Anchor.CentreLeft;
            Origin = Anchor.CentreLeft;
            LabelTextFlowContainer.Anchor = Anchor.CentreLeft;
            LabelTextFlowContainer.Origin = Anchor.CentreLeft;
            LabelText = UserInterfaceStrings.ShowHidden;

            Scale = new Vector2(0.8f);
        }

        [BackgroundDependencyLoader(true)]
        private void load(OverlayColourProvider? overlayColourProvider, OsuColour colours)
        {
            if (overlayColourProvider != null)
                return;

            Nub.AccentColour = colours.GreySeaFoamLighter;
            Nub.GlowingAccentColour = Color4.White;
            Nub.GlowColour = Color4.White;
        }
    }
}
