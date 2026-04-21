// =============================================================================
// OsuUiKit — Extracted from ppy/osu (MIT Licence)
// SOURCE: osu.Game/Graphics/InputBlockingContainer.cs
// EXTRACTED: 2026-04-21
// DEPENDENCIES: ppy.osu.Framework, ppy.osu.Game.Resources
// SEE ALSO: https://github.com/ppy/osu
// =============================================================================
// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Framework.Graphics.Containers;
using osu.Framework.Input.Events;

namespace OsuUiKit
{
    /// <summary>
    /// A simple container which blocks input events from travelling through it.
    ///
    /// Note that this will block right clicks as well. Special care needs to be taken to not break context menus from displaying.
    /// </summary>
    public partial class InputBlockingContainer : Container
    {
        protected override bool OnHover(HoverEvent e) => true;

        protected override bool OnMouseDown(MouseDownEvent e) => true;

        protected override bool OnClick(ClickEvent e) => true;
    }
}
