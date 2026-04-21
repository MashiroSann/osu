// =============================================================================
// OsuUiKit — Extracted from ppy/osu (MIT Licence)
// SOURCE: osu.Game/Graphics/Containers/Markdown/Extensions/BlockAttributeExtension.cs
// EXTRACTED: 2026-04-21
// DEPENDENCIES: ppy.osu.Framework, ppy.osu.Game.Resources
// SEE ALSO: https://github.com/ppy/osu
// =============================================================================
// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using Markdig;
using Markdig.Extensions.GenericAttributes;
using Markdig.Renderers;
using Markdig.Syntax;

namespace OsuUiKit.Containers.Markdown.Extensions
{
    /// <summary>
    /// A variant of <see cref="Markdig.Extensions.GenericAttributes.GenericAttributesExtension"/>
    /// which only handles generic attributes in the current markdown <see cref="Block"/> and ignores inline generic attributes.
    /// </summary>
    /// <remarks>
    /// For rationale, see implementation of <see cref="Setup(Markdig.MarkdownPipelineBuilder)"/>.
    /// </remarks>
    public class BlockAttributeExtension : IMarkdownExtension
    {
        private readonly GenericAttributesExtension genericAttributesExtension = new GenericAttributesExtension();

        public void Setup(MarkdownPipelineBuilder pipeline)
        {
            genericAttributesExtension.Setup(pipeline);

            // GenericAttributesExtension registers a GenericAttributesParser in pipeline.InlineParsers.
            // this conflicts with the CustomContainerExtension, leading to some custom containers (e.g. flags) not displaying.
            // as a workaround, remove the inline parser here before it can do damage.
            pipeline.InlineParsers.RemoveAll(parser => parser is GenericAttributesParser);
        }

        public void Setup(MarkdownPipeline pipeline, IMarkdownRenderer renderer) => genericAttributesExtension.Setup(pipeline, renderer);
    }
}
