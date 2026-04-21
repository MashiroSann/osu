# OsuUiKit Annotation Guide

## Purpose

This guide describes the annotation conventions used throughout OsuUiKit so that contributors and
consumers know where each file came from, what external dependencies it carries, and where remaining
coupling to the main osu! game needs to be resolved.

---

## File-Level Header Format

Every `.cs` file in OsuUiKit carries the following header block **before** the original copyright line:

```csharp
// =============================================================================
// OsuUiKit — Extracted from ppy/osu (MIT Licence)
// SOURCE: osu.Game/Graphics/<RelativePath>
// EXTRACTED: 2026-04-21
// DEPENDENCIES: ppy.osu.Framework, ppy.osu.Game.Resources
// SEE ALSO: https://github.com/ppy/osu
// =============================================================================
```

| Field | Meaning |
|---|---|
| `SOURCE` | Path in the upstream `ppy/osu` repository this file was copied from. |
| `EXTRACTED` | ISO-8601 date the file was last synchronised with upstream. |
| `DEPENDENCIES` | NuGet packages required to compile this file outside the main game. |
| `SEE ALSO` | Canonical upstream repository for diffs and history. |

---

## XML Comment Conventions

Public classes carry standard C# XML doc comments:

```csharp
/// <summary>
/// One-sentence description of what the component renders or does.
/// </summary>
/// <remarks>
/// Extracted from ppy/osu. May have coupling to osu!-specific services via [BackgroundDependencyLoader].
/// </remarks>
public partial class OsuButton : Button
```

- `<summary>` — required on every exported public type.
- `<remarks>` — added by OsuUiKit extraction to flag potential DI coupling. Keep this line even if you
  resolve all coupling, so auditors know the file is an extraction.

---

## TODO(coupling) Convention

A `TODO(coupling)` annotation in `docs/MIGRATION.md` means the file contains at least one `using` or
type reference from one of these problematic namespaces:

| Namespace | Problem |
|---|---|
| `osu.Game.Beatmaps` | Requires game beatmap system; no standalone equivalent. |
| `osu.Game.Online` | Requires network stack and osu! API client. |
| `osu.Game.Rulesets` | Requires ruleset plugin architecture. |
| `osu.Game.Scoring` | Requires score/performance calculation pipeline. |

**How to resolve a TODO(coupling):**

1. Open the flagged file and search for the offending namespace.
2. Determine whether the dependency is on a data type (interface/DTO) or a live service.
3. For data types: copy the minimal interface into OsuUiKit and remove the upstream reference.
4. For live services: inject an abstraction (`IMyService`) via the DI container and provide a stub.
5. Re-run `bash src/OsuUiKit/check-coupling.sh` to confirm the reference is gone.

---

## Common DI Dependencies

The following five services are injected via `[BackgroundDependencyLoader]` in many OsuUiKit components.
They are provided automatically when the component tree is hosted inside a standard osu-framework `Game`.

| Dependency | What it does |
|---|---|
| `OsuColour` | Central colour palette for the osu! visual theme. Provides named colours like `Pink`, `Blue`, `YellowLight`, etc. |
| `AudioManager` | osu-framework service for loading and playing audio samples and tracks. Used to play UI click/hover sounds. |
| `OverlayColourProvider` | Contextual colour theming for overlays (e.g. dark/light overlay backgrounds). Provided by `OsuGame`. |
| `OsuGame` | The top-level game object. Handles screen transitions, notifications, and link opening. Hard to stub. |
| `ISamplePlaybackDisabler` | Interface implemented by `OsuGame` that pauses UI sounds during active gameplay to avoid audio collisions. |

When using OsuUiKit outside the main osu! game, you need to register compatible implementations of these
services in your DI container before constructing any UI components that depend on them.

---

## Example: Fully Annotated Class (OsuButton)

```csharp
// =============================================================================
// OsuUiKit — Extracted from ppy/osu (MIT Licence)
// SOURCE: osu.Game/Graphics/UserInterface/OsuButton.cs
// EXTRACTED: 2026-04-21
// DEPENDENCIES: ppy.osu.Framework, ppy.osu.Game.Resources
// SEE ALSO: https://github.com/ppy/osu
// =============================================================================
// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Framework.Allocation;
using osu.Framework.Audio;
// ... other usings ...

namespace OsuUiKit.UserInterface
{
    /// <summary>
    /// A button with added default sound effects.
    /// </summary>
    /// <remarks>
    /// Extracted from ppy/osu. May have coupling to osu!-specific services via [BackgroundDependencyLoader].
    /// </remarks>
    public abstract partial class OsuButton : Button
    {
        [BackgroundDependencyLoader]
        private void load(AudioManager audio)
        {
            // Loads hover and click samples from osu.Game.Resources.
            // To decouple: pass an IAudioManager abstraction instead.
        }
    }
}
```

Key points demonstrated above:
- Header block precedes the copyright comment.
- Namespace is `OsuUiKit.UserInterface` (transformed from `osu.Game.Graphics.UserInterface`).
- `<summary>` and `<remarks>` are present on the class.
- `[BackgroundDependencyLoader]` is acknowledged in `<remarks>`.
