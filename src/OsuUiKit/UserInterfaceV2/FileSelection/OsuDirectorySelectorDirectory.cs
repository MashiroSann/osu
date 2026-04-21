// =============================================================================
// OsuUiKit — Extracted from ppy/osu (MIT Licence)
// SOURCE: osu.Game/Graphics/UserInterfaceV2/FileSelection/OsuDirectorySelectorDirectory.cs
// EXTRACTED: 2026-04-21
// DEPENDENCIES: ppy.osu.Framework, ppy.osu.Game.Resources
// SEE ALSO: https://github.com/ppy/osu
// =============================================================================
// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System.IO;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.UserInterface;
using osu.Framework.Localisation;
using OsuUiKit.Sprites;

namespace OsuUiKit.UserInterfaceV2.FileSelection
{
    internal partial class OsuDirectorySelectorDirectory : DirectorySelectorDirectory
    {
        public OsuDirectorySelectorDirectory(DirectoryInfo directory, LocalisableString? displayName = null)
            : base(directory, displayName)
        {
        }

        [BackgroundDependencyLoader]
        private void load(OsuColour colours)
        {
            Flow.AutoSizeAxes = Axes.X;
            Flow.Height = OsuDirectorySelector.ITEM_HEIGHT;

            AddInternal(new BackgroundLayer());

            Colour = colours.Orange1;
        }

        protected override SpriteText CreateSpriteText() => new OsuSpriteText().With(t => t.Font = OsuFont.Default.With(weight: FontWeight.Bold));

        protected override IconUsage? Icon => Directory.Name.Contains(Path.DirectorySeparatorChar)
            ? FontAwesome.Solid.Database
            : FontAwesome.Regular.Folder;
    }
}
