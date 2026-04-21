// =============================================================================
// OsuUiKit — Extracted from ppy/osu (MIT Licence)
// SOURCE: osu.Game/Graphics/Containers/Markdown/OsuMarkdownTable.cs
// EXTRACTED: 2026-04-21
// DEPENDENCIES: ppy.osu.Framework, ppy.osu.Game.Resources
// SEE ALSO: https://github.com/ppy/osu
// =============================================================================
﻿// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using Markdig.Extensions.Tables;
using osu.Framework.Graphics.Containers.Markdown;

namespace OsuUiKit.Containers.Markdown
{
    public partial class OsuMarkdownTable : MarkdownTable
    {
        public OsuMarkdownTable(Table table)
            : base(table)
        {
        }

        protected override MarkdownTableCell CreateTableCell(TableCell cell, TableColumnDefinition definition, bool isHeading) => new OsuMarkdownTableCell(cell, definition, isHeading);
    }
}
