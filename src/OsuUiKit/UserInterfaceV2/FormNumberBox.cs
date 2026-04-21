// =============================================================================
// OsuUiKit — Extracted from ppy/osu (MIT Licence)
// SOURCE: osu.Game/Graphics/UserInterfaceV2/FormNumberBox.cs
// EXTRACTED: 2026-04-21
// DEPENDENCIES: ppy.osu.Framework, ppy.osu.Game.Resources
// SEE ALSO: https://github.com/ppy/osu
// =============================================================================
// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Framework.Input;

namespace OsuUiKit.UserInterfaceV2
{
    public partial class FormNumberBox : FormTextBox
    {
        private readonly bool allowDecimals;

        public FormNumberBox(bool allowDecimals = false)
        {
            this.allowDecimals = allowDecimals;
        }

        internal override InnerTextBox CreateTextBox() => new InnerNumberBox(allowDecimals)
        {
            SelectAllOnFocus = true,
        };

        internal partial class InnerNumberBox : InnerTextBox
        {
            public InnerNumberBox(bool allowDecimals)
            {
                InputProperties = new TextInputProperties(allowDecimals ? TextInputType.Decimal : TextInputType.Number, false);
            }
        }
    }
}
