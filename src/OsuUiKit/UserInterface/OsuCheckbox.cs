// =============================================================================
// OsuUiKit — Extracted from ppy/osu (MIT Licence)
// SOURCE: osu.Game/Graphics/UserInterface/OsuCheckbox.cs
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
using osu.Framework.Graphics;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.UserInterface;
using osu.Framework.Input.Events;
using osu.Framework.Localisation;
using OsuUiKit.Containers;

namespace OsuUiKit.UserInterface
{
    /// <summary>
    /// Checkbox control styled for the osu! UI theme.
    /// </summary>
    /// <remarks>Extracted from ppy/osu. May have coupling to osu!-specific services via [BackgroundDependencyLoader].</remarks>
    public partial class OsuCheckbox : Checkbox
    {
        /// <summary>
        /// Whether to play sounds when the state changes as a result of user interaction.
        /// </summary>
        protected virtual bool PlaySoundsOnUserChange => true;

        public LocalisableString LabelText
        {
            set
            {
                if (LabelTextFlowContainer != null)
                    LabelTextFlowContainer.Text = value;
            }
        }

        public MarginPadding LabelPadding
        {
            get => LabelTextFlowContainer?.Padding ?? new MarginPadding();
            set
            {
                if (LabelTextFlowContainer != null)
                    LabelTextFlowContainer.Padding = value;
            }
        }

        protected readonly Nub Nub;

        protected readonly OsuTextFlowContainer LabelTextFlowContainer;
        private Sample sampleChecked;
        private Sample sampleUnchecked;

        public OsuCheckbox(bool nubOnRight = true, float nubSize = Nub.DEFAULT_EXPANDED_SIZE)
        {
            AutoSizeAxes = Axes.Y;
            RelativeSizeAxes = Axes.X;

            Children = new Drawable[]
            {
                LabelTextFlowContainer = new OsuTextFlowContainer(ApplyLabelParameters)
                {
                    AutoSizeAxes = Axes.Y,
                    RelativeSizeAxes = Axes.X,
                },
                Nub = new Nub(nubSize),
                new HoverSounds()
            };

            if (nubOnRight)
            {
                Nub.Anchor = Anchor.CentreRight;
                Nub.Origin = Anchor.CentreRight;
                LabelTextFlowContainer.Padding = new MarginPadding { Right = Nub.DEFAULT_EXPANDED_SIZE + 10f };
            }
            else
            {
                Nub.Anchor = Anchor.CentreLeft;
                Nub.Origin = Anchor.CentreLeft;
                LabelTextFlowContainer.Padding = new MarginPadding { Left = Nub.DEFAULT_EXPANDED_SIZE + 10f };
            }

            Nub.Current.BindTo(Current);

            Current.DisabledChanged += disabled => LabelTextFlowContainer.Alpha = Nub.Alpha = disabled ? 0.3f : 1;
        }

        /// <summary>
        /// A function which can be overridden to change the parameters of the label's text.
        /// </summary>
        protected virtual void ApplyLabelParameters(SpriteText text)
        {
        }

        [BackgroundDependencyLoader]
        private void load(AudioManager audio)
        {
            sampleChecked = audio.Samples.Get(@"UI/check-on");
            sampleUnchecked = audio.Samples.Get(@"UI/check-off");
        }

        protected override bool OnHover(HoverEvent e)
        {
            Nub.Glowing = true;
            return base.OnHover(e);
        }

        protected override void OnHoverLost(HoverLostEvent e)
        {
            Nub.Glowing = false;
            base.OnHoverLost(e);
        }

        protected override void OnUserChange(bool value)
        {
            base.OnUserChange(value);

            if (PlaySoundsOnUserChange)
            {
                if (value)
                    sampleChecked?.Play();
                else
                    sampleUnchecked?.Play();
            }
        }
    }
}
