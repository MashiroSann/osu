// =============================================================================
// OsuUiKit — Extracted from ppy/osu (MIT Licence)
// SOURCE: osu.Game/Graphics/UserInterfaceV2/FileSelection/OsuDirectorySelectorParentDirectory.cs
// EXTRACTED: 2026-04-21
// DEPENDENCIES: ppy.osu.Framework, ppy.osu.Game.Resources
// SEE ALSO: https://github.com/ppy/osu
// =============================================================================
﻿// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System.IO;
using osu.Framework.Allocation;
using osu.Framework.Graphics.Sprites;
using osu.Game.Overlays;

namespace OsuUiKit.UserInterfaceV2.FileSelection
{
    internal partial class OsuDirectorySelectorParentDirectory : OsuDirectorySelectorDirectory
    {
        protected override IconUsage? Icon => FontAwesome.Solid.Folder;

        public OsuDirectorySelectorParentDirectory(DirectoryInfo directory)
            : base(directory, "..")
        {
        }

        [BackgroundDependencyLoader]
        private void load(OverlayColourProvider colourProvider)
        {
            Colour = colourProvider.Content1;
        }
    }
}
