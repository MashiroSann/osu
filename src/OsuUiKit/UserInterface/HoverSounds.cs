// =============================================================================
// OsuUiKit — Extracted from ppy/osu (MIT Licence)
// SOURCE: osu.Game/Graphics/UserInterface/HoverSounds.cs
// EXTRACTED: 2026-04-21
// DEPENDENCIES: ppy.osu.Framework, ppy.osu.Game.Resources
// SEE ALSO: https://github.com/ppy/osu
// =============================================================================
﻿// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

#nullable disable

using osu.Framework.Allocation;
using osu.Framework.Audio;
using osu.Framework.Audio.Sample;
using osu.Framework.Bindables;
using osu.Framework.Extensions;
using osu.Framework.Graphics;
using osu.Game.Audio;

namespace OsuUiKit.UserInterface
{
    /// <summary>
    /// Adds hover sounds to a drawable.
    /// Does not draw anything.
    /// </summary>
    public partial class HoverSounds : HoverSampleDebounceComponent
    {
        public readonly Bindable<bool> Enabled = new Bindable<bool>(true);

        private Sample sampleHover;

        protected readonly HoverSampleSet SampleSet;

        public HoverSounds(HoverSampleSet sampleSet = HoverSampleSet.Default)
        {
            SampleSet = sampleSet;
            RelativeSizeAxes = Axes.Both;
        }

        [BackgroundDependencyLoader]
        private void load(AudioManager audio)
        {
            sampleHover = audio.Samples.Get($@"UI/{SampleSet.GetDescription()}-hover")
                          ?? audio.Samples.Get($@"UI/{HoverSampleSet.Default.GetDescription()}-hover");
        }

        public override void PlayHoverSample()
        {
            if (!Enabled.Value)
                return;

            SamplePlaybackHelper.PlayWithRandomPitch(sampleHover, pitchVariation: 0.02);
        }
    }
}
