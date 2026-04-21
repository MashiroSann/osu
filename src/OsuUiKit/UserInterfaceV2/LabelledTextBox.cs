// =============================================================================
// OsuUiKit — Extracted from ppy/osu (MIT Licence)
// SOURCE: osu.Game/Graphics/UserInterfaceV2/LabelledTextBox.cs
// EXTRACTED: 2026-04-21
// DEPENDENCIES: ppy.osu.Framework, ppy.osu.Game.Resources
// SEE ALSO: https://github.com/ppy/osu
// =============================================================================
﻿// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

#nullable disable

using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.UserInterface;
using osu.Framework.Input.Events;
using osu.Framework.Localisation;
using OsuUiKit.UserInterface;

namespace OsuUiKit.UserInterfaceV2
{
    public partial class LabelledTextBox : LabelledComponent<OsuTextBox, string>
    {
        public event TextBox.OnCommitHandler OnCommit;

        public LabelledTextBox()
            : base(false)
        {
        }

        public bool ReadOnly
        {
            get => Component.ReadOnly;
            set => Component.ReadOnly = value;
        }

        public bool SelectAllOnFocus
        {
            get => Component.SelectAllOnFocus;
            set => Component.SelectAllOnFocus = value;
        }

        public LocalisableString PlaceholderText
        {
            set => Component.PlaceholderText = value;
        }

        public string Text
        {
            get => Component.Text;
            set => Component.Text = value;
        }

        public CompositeDrawable TabbableContentContainer
        {
            set => Component.TabbableContentContainer = value;
        }

        [BackgroundDependencyLoader]
        private void load(OsuColour colours)
        {
            Component.BorderColour = colours.Blue;
        }

        public bool SelectAll() => Component.SelectAll();

        protected virtual OsuTextBox CreateTextBox() => new OsuTextBox();

        public override bool AcceptsFocus => true;

        protected override void OnFocus(FocusEvent e)
        {
            base.OnFocus(e);
            GetContainingFocusManager()!.ChangeFocus(Component);
        }

        protected override OsuTextBox CreateComponent() => CreateTextBox().With(t =>
        {
            t.CommitOnFocusLost = true;
            t.Anchor = Anchor.Centre;
            t.Origin = Anchor.Centre;
            t.RelativeSizeAxes = Axes.X;
            t.CornerRadius = CORNER_RADIUS;

            t.OnCommit += (sender, newText) => OnCommit?.Invoke(sender, newText);
        });
    }
}
