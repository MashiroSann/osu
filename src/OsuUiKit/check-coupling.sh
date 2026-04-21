#!/usr/bin/env bash
# Scans OsuUiKit source files for references to osu.Game namespaces that indicate
# remaining coupling to the main game logic. Run from repo root.
echo "=== OsuUiKit Coupling Check ==="
echo "Files with remaining osu.Game.* references:"
grep -r "osu\.Game\." src/OsuUiKit --include="*.cs" -l | sort
echo ""
echo "Count by namespace:"
grep -roh "osu\.Game\.[A-Za-z.]*" src/OsuUiKit --include="*.cs" | sort | uniq -c | sort -rn | head -20
