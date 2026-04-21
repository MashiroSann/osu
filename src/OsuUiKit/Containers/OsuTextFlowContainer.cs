// =============================================================================
// OsuUiKit — Extracted from ppy/osu (MIT Licence)
// SOURCE: osu.Game/Graphics/Containers/OsuTextFlowContainer.cs
// EXTRACTED: 2026-04-21
// DEPENDENCIES: ppy.osu.Framework, ppy.osu.Game.Resources
// SEE ALSO: https://github.com/ppy/osu
// =============================================================================
﻿// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;
using osu.Framework.Extensions.IEnumerableExtensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using OsuUiKit.Sprites;

namespace OsuUiKit.Containers
{
    public partial class OsuTextFlowContainer : TextFlowContainer
    {
        public OsuTextFlowContainer(Action<SpriteText>? defaultCreationParameters = null)
            : base(defaultCreationParameters)
        {
        }

        protected override SpriteText CreateSpriteText() => new OsuSpriteText();

        public ITextPart AddArbitraryDrawable(Drawable drawable) => AddPart(new TextPartManual(new ArbitraryDrawableWrapper(drawable).Yield()));

        public ITextPart AddIcon(IconUsage icon, Action<SpriteText>? creationParameters = null) => AddText(icon.Icon.ToString(), creationParameters);

        private partial class ArbitraryDrawableWrapper : Container, IHasLineBaseHeight
        {
            private readonly IHasLineBaseHeight? lineBaseHeightSource;

            public float LineBaseHeight => lineBaseHeightSource?.LineBaseHeight ?? DrawHeight;

            public ArbitraryDrawableWrapper(Drawable drawable)
            {
                Child = drawable;
                lineBaseHeightSource = drawable as IHasLineBaseHeight;
                AutoSizeAxes = Axes.Both;
            }
        }
    }
}
