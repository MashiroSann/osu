// =============================================================================
// OsuUiKit — Extracted from ppy/osu (MIT Licence)
// SOURCE: osu.Game/Graphics/Containers/Markdown/OsuMarkdownCodeBlock.cs
// EXTRACTED: 2026-04-21
// DEPENDENCIES: ppy.osu.Framework, ppy.osu.Game.Resources
// SEE ALSO: https://github.com/ppy/osu
// =============================================================================
﻿// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using Markdig.Syntax;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers.Markdown;
using osu.Framework.Graphics.Shapes;
using osu.Game.Overlays;

namespace OsuUiKit.Containers.Markdown
{
    public partial class OsuMarkdownCodeBlock : MarkdownCodeBlock
    {
        // TODO : change to monospace font for this component
        public OsuMarkdownCodeBlock(CodeBlock codeBlock)
            : base(codeBlock)
        {
        }

        protected override Drawable CreateBackground() => new CodeBlockBackground();

        public override MarkdownTextFlowContainer CreateTextFlow() => new CodeBlockTextFlowContainer();

        private partial class CodeBlockBackground : Box
        {
            [BackgroundDependencyLoader]
            private void load(OverlayColourProvider colourProvider)
            {
                RelativeSizeAxes = Axes.Both;
                Colour = colourProvider.Background6;
            }
        }

        private partial class CodeBlockTextFlowContainer : OsuMarkdownTextFlowContainer
        {
            [BackgroundDependencyLoader]
            private void load(OverlayColourProvider colourProvider)
            {
                Colour = colourProvider.Light1;
                Margin = new MarginPadding(10);
            }
        }
    }
}
