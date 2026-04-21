// =============================================================================
// OsuUiKit — Extracted from ppy/osu (MIT Licence)
// SOURCE: osu.Game/Graphics/Containers/Markdown/Extensions/OsuMarkdownExtensions.cs
// EXTRACTED: 2026-04-21
// DEPENDENCIES: ppy.osu.Framework, ppy.osu.Game.Resources
// SEE ALSO: https://github.com/ppy/osu
// =============================================================================
// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using Markdig;

namespace OsuUiKit.Containers.Markdown.Extensions
{
    public static class OsuMarkdownExtensions
    {
        /// <summary>
        /// Uses the block attributes extension.
        /// </summary>
        /// <param name="pipeline">The pipeline.</param>
        /// <returns>The modified pipeline.</returns>
        public static MarkdownPipelineBuilder UseBlockAttributes(this MarkdownPipelineBuilder pipeline)
        {
            pipeline.Extensions.AddIfNotAlready<BlockAttributeExtension>();
            return pipeline;
        }
    }
}
