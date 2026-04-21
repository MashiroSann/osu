# OsuUiKit Migration Map

## Overview

OsuUiKit extracts the reusable UI layer from [ppy/osu](https://github.com/ppy/osu) into a standalone
library that can be referenced by third-party osu-framework projects without pulling in the entire game.

All source files are distributed under the **MIT Licence** as found in the upstream repository. You must
preserve the original copyright notice in every file:

```
// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.
```

## Brand Notice

`osu!` and `ppy` are registered trademarks of ppy Pty Ltd. **Do not** use these names as application
branding, product names, or in a way that implies official endorsement.

## Resource Licence Warning

Game resources (audio samples, images, textures) distributed via `ppy.osu.Game.Resources` are covered
by a **separate, more restrictive licence** from ppy/osu-resources. Before shipping any product built on
OsuUiKit, audit every asset reference and replace or obtain proper permission for each asset. When in
doubt, substitute with freely-licensed alternatives (e.g. CC0 sounds from freesound.org).

## File Mapping Table

| Original Path | OsuUiKit Path | Coupling Notes |
|---|---|---|
| `osu.Game/Graphics/DateTooltip.cs` | `src/OsuUiKit/DateTooltip.cs` | — |
| `osu.Game/Graphics/DrawableDate.cs` | `src/OsuUiKit/DrawableDate.cs` | — |
| `osu.Game/Graphics/ErrorTextFlowContainer.cs` | `src/OsuUiKit/ErrorTextFlowContainer.cs` | — |
| `osu.Game/Graphics/GhostIcon.cs` | `src/OsuUiKit/GhostIcon.cs` | — |
| `osu.Game/Graphics/HSPAColour.cs` | `src/OsuUiKit/HSPAColour.cs` | — |
| `osu.Game/Graphics/IHasAccentColour.cs` | `src/OsuUiKit/IHasAccentColour.cs` | — |
| `osu.Game/Graphics/InputBlockingContainer.cs` | `src/OsuUiKit/InputBlockingContainer.cs` | — |
| `osu.Game/Graphics/OsuColour.cs` | `src/OsuUiKit/OsuColour.cs` | TODO(coupling): Beatmaps, Online, Rulesets, Scoring |
| `osu.Game/Graphics/OsuFont.cs` | `src/OsuUiKit/OsuFont.cs` | — |
| `osu.Game/Graphics/OsuIcon.cs` | `src/OsuUiKit/OsuIcon.cs` | — |
| `osu.Game/Graphics/ParticleSpewer.cs` | `src/OsuUiKit/ParticleSpewer.cs` | — |
| `osu.Game/Graphics/Containers/BeatSyncedContainer.cs` | `src/OsuUiKit/Containers/BeatSyncedContainer.cs` | TODO(coupling): Beatmaps |
| `osu.Game/Graphics/Containers/ConstrainedIconContainer.cs` | `src/OsuUiKit/Containers/ConstrainedIconContainer.cs` | — |
| `osu.Game/Graphics/Containers/ExpandingContainer.cs` | `src/OsuUiKit/Containers/ExpandingContainer.cs` | — |
| `osu.Game/Graphics/Containers/HoldToConfirmContainer.cs` | `src/OsuUiKit/Containers/HoldToConfirmContainer.cs` | — |
| `osu.Game/Graphics/Containers/IExpandable.cs` | `src/OsuUiKit/Containers/IExpandable.cs` | — |
| `osu.Game/Graphics/Containers/IExpandingContainer.cs` | `src/OsuUiKit/Containers/IExpandingContainer.cs` | — |
| `osu.Game/Graphics/Containers/LinkFlowContainer.cs` | `src/OsuUiKit/Containers/LinkFlowContainer.cs` | TODO(coupling): Online |
| `osu.Game/Graphics/Containers/LogoTrackingContainer.cs` | `src/OsuUiKit/Containers/LogoTrackingContainer.cs` | — |
| `osu.Game/Graphics/Containers/OsuClickableContainer.cs` | `src/OsuUiKit/Containers/OsuClickableContainer.cs` | — |
| `osu.Game/Graphics/Containers/OsuFocusedOverlayContainer.cs` | `src/OsuUiKit/Containers/OsuFocusedOverlayContainer.cs` | — |
| `osu.Game/Graphics/Containers/OsuHoverContainer.cs` | `src/OsuUiKit/Containers/OsuHoverContainer.cs` | — |
| `osu.Game/Graphics/Containers/OsuRearrangeableListContainer.cs` | `src/OsuUiKit/Containers/OsuRearrangeableListContainer.cs` | — |
| `osu.Game/Graphics/Containers/OsuRearrangeableListItem.cs` | `src/OsuUiKit/Containers/OsuRearrangeableListItem.cs` | — |
| `osu.Game/Graphics/Containers/OsuScrollContainer.cs` | `src/OsuUiKit/Containers/OsuScrollContainer.cs` | — |
| `osu.Game/Graphics/Containers/OsuTextFlowContainer.cs` | `src/OsuUiKit/Containers/OsuTextFlowContainer.cs` | — |
| `osu.Game/Graphics/Containers/ParallaxContainer.cs` | `src/OsuUiKit/Containers/ParallaxContainer.cs` | — |
| `osu.Game/Graphics/Containers/ReverseChildIDFillFlowContainer.cs` | `src/OsuUiKit/Containers/ReverseChildIDFillFlowContainer.cs` | — |
| `osu.Game/Graphics/Containers/ScalingContainer.cs` | `src/OsuUiKit/Containers/ScalingContainer.cs` | — |
| `osu.Game/Graphics/Containers/SectionsContainer.cs` | `src/OsuUiKit/Containers/SectionsContainer.cs` | — |
| `osu.Game/Graphics/Containers/SelectionCycleFillFlowContainer.cs` | `src/OsuUiKit/Containers/SelectionCycleFillFlowContainer.cs` | — |
| `osu.Game/Graphics/Containers/ShakeContainer.cs` | `src/OsuUiKit/Containers/ShakeContainer.cs` | — |
| `osu.Game/Graphics/Containers/ShearAligningWrapper.cs` | `src/OsuUiKit/Containers/ShearAligningWrapper.cs` | — |
| `osu.Game/Graphics/Containers/UprightAspectMaintainingContainer.cs` | `src/OsuUiKit/Containers/UprightAspectMaintainingContainer.cs` | — |
| `osu.Game/Graphics/Containers/UserDimContainer.cs` | `src/OsuUiKit/Containers/UserDimContainer.cs` | — |
| `osu.Game/Graphics/Containers/UserTrackingScrollContainer.cs` | `src/OsuUiKit/Containers/UserTrackingScrollContainer.cs` | — |
| `osu.Game/Graphics/Containers/WaveContainer.cs` | `src/OsuUiKit/Containers/WaveContainer.cs` | — |
| `osu.Game/Graphics/Containers/Markdown/OsuMarkdownCodeBlock.cs` | `src/OsuUiKit/Containers/Markdown/OsuMarkdownCodeBlock.cs` | — |
| `osu.Game/Graphics/Containers/Markdown/OsuMarkdownContainer.cs` | `src/OsuUiKit/Containers/Markdown/OsuMarkdownContainer.cs` | — |
| `osu.Game/Graphics/Containers/Markdown/OsuMarkdownContainerOptions.cs` | `src/OsuUiKit/Containers/Markdown/OsuMarkdownContainerOptions.cs` | — |
| `osu.Game/Graphics/Containers/Markdown/OsuMarkdownHeading.cs` | `src/OsuUiKit/Containers/Markdown/OsuMarkdownHeading.cs` | — |
| `osu.Game/Graphics/Containers/Markdown/OsuMarkdownImage.cs` | `src/OsuUiKit/Containers/Markdown/OsuMarkdownImage.cs` | — |
| `osu.Game/Graphics/Containers/Markdown/OsuMarkdownLinkText.cs` | `src/OsuUiKit/Containers/Markdown/OsuMarkdownLinkText.cs` | TODO(coupling): Online |
| `osu.Game/Graphics/Containers/Markdown/OsuMarkdownListItem.cs` | `src/OsuUiKit/Containers/Markdown/OsuMarkdownListItem.cs` | — |
| `osu.Game/Graphics/Containers/Markdown/OsuMarkdownOrderedListItem.cs` | `src/OsuUiKit/Containers/Markdown/OsuMarkdownOrderedListItem.cs` | — |
| `osu.Game/Graphics/Containers/Markdown/OsuMarkdownQuoteBlock.cs` | `src/OsuUiKit/Containers/Markdown/OsuMarkdownQuoteBlock.cs` | — |
| `osu.Game/Graphics/Containers/Markdown/OsuMarkdownSeparator.cs` | `src/OsuUiKit/Containers/Markdown/OsuMarkdownSeparator.cs` | — |
| `osu.Game/Graphics/Containers/Markdown/OsuMarkdownTable.cs` | `src/OsuUiKit/Containers/Markdown/OsuMarkdownTable.cs` | — |
| `osu.Game/Graphics/Containers/Markdown/OsuMarkdownTableCell.cs` | `src/OsuUiKit/Containers/Markdown/OsuMarkdownTableCell.cs` | — |
| `osu.Game/Graphics/Containers/Markdown/OsuMarkdownTextFlowContainer.cs` | `src/OsuUiKit/Containers/Markdown/OsuMarkdownTextFlowContainer.cs` | — |
| `osu.Game/Graphics/Containers/Markdown/OsuMarkdownUnorderedListItem.cs` | `src/OsuUiKit/Containers/Markdown/OsuMarkdownUnorderedListItem.cs` | — |
| `osu.Game/Graphics/Containers/Markdown/Extensions/BlockAttributeExtension.cs` | `src/OsuUiKit/Containers/Markdown/Extensions/BlockAttributeExtension.cs` | — |
| `osu.Game/Graphics/Containers/Markdown/Extensions/OsuMarkdownExtensions.cs` | `src/OsuUiKit/Containers/Markdown/Extensions/OsuMarkdownExtensions.cs` | — |
| `osu.Game/Graphics/Containers/Markdown/Footnotes/OsuMarkdownFootnote.cs` | `src/OsuUiKit/Containers/Markdown/Footnotes/OsuMarkdownFootnote.cs` | — |
| `osu.Game/Graphics/Containers/Markdown/Footnotes/OsuMarkdownFootnoteBacklink.cs` | `src/OsuUiKit/Containers/Markdown/Footnotes/OsuMarkdownFootnoteBacklink.cs` | — |
| `osu.Game/Graphics/Containers/Markdown/Footnotes/OsuMarkdownFootnoteLink.cs` | `src/OsuUiKit/Containers/Markdown/Footnotes/OsuMarkdownFootnoteLink.cs` | — |
| `osu.Game/Graphics/Containers/Markdown/Footnotes/OsuMarkdownFootnoteTooltip.cs` | `src/OsuUiKit/Containers/Markdown/Footnotes/OsuMarkdownFootnoteTooltip.cs` | — |
| `osu.Game/Graphics/Sprites/GlowingDrawable.cs` | `src/OsuUiKit/Sprites/GlowingDrawable.cs` | — |
| `osu.Game/Graphics/Sprites/GlowingSpriteText.cs` | `src/OsuUiKit/Sprites/GlowingSpriteText.cs` | — |
| `osu.Game/Graphics/Sprites/LogoAnimation.cs` | `src/OsuUiKit/Sprites/LogoAnimation.cs` | — |
| `osu.Game/Graphics/Sprites/OsuSpriteText.cs` | `src/OsuUiKit/Sprites/OsuSpriteText.cs` | — |
| `osu.Game/Graphics/Sprites/SizePreservingSpriteText.cs` | `src/OsuUiKit/Sprites/SizePreservingSpriteText.cs` | — |
| `osu.Game/Graphics/Sprites/SpriteIconWithTooltip.cs` | `src/OsuUiKit/Sprites/SpriteIconWithTooltip.cs` | — |
| `osu.Game/Graphics/Sprites/SpriteTextWithTooltip.cs` | `src/OsuUiKit/Sprites/SpriteTextWithTooltip.cs` | — |
| `osu.Game/Graphics/Sprites/TruncatingSpriteText.cs` | `src/OsuUiKit/Sprites/TruncatingSpriteText.cs` | — |
| `osu.Game/Graphics/UserInterface/BackButton.cs` | `src/OsuUiKit/UserInterface/BackButton.cs` | — |
| `osu.Game/Graphics/UserInterface/Bar.cs` | `src/OsuUiKit/UserInterface/Bar.cs` | — |
| `osu.Game/Graphics/UserInterface/BarGraph.cs` | `src/OsuUiKit/UserInterface/BarGraph.cs` | — |
| `osu.Game/Graphics/UserInterface/BasicSearchTextBox.cs` | `src/OsuUiKit/UserInterface/BasicSearchTextBox.cs` | — |
| `osu.Game/Graphics/UserInterface/BreadcrumbControl.cs` | `src/OsuUiKit/UserInterface/BreadcrumbControl.cs` | — |
| `osu.Game/Graphics/UserInterface/CommaSeparatedScoreCounter.cs` | `src/OsuUiKit/UserInterface/CommaSeparatedScoreCounter.cs` | — |
| `osu.Game/Graphics/UserInterface/DangerousRoundedButton.cs` | `src/OsuUiKit/UserInterface/DangerousRoundedButton.cs` | — |
| `osu.Game/Graphics/UserInterface/DialogButton.cs` | `src/OsuUiKit/UserInterface/DialogButton.cs` | — |
| `osu.Game/Graphics/UserInterface/DownloadButton.cs` | `src/OsuUiKit/UserInterface/DownloadButton.cs` | TODO(coupling): Online |
| `osu.Game/Graphics/UserInterface/DrawableOsuMenuItem.cs` | `src/OsuUiKit/UserInterface/DrawableOsuMenuItem.cs` | — |
| `osu.Game/Graphics/UserInterface/DrawableStatefulMenuItem.cs` | `src/OsuUiKit/UserInterface/DrawableStatefulMenuItem.cs` | — |
| `osu.Game/Graphics/UserInterface/ExpandableSlider.cs` | `src/OsuUiKit/UserInterface/ExpandableSlider.cs` | — |
| `osu.Game/Graphics/UserInterface/ExpandingBar.cs` | `src/OsuUiKit/UserInterface/ExpandingBar.cs` | — |
| `osu.Game/Graphics/UserInterface/ExternalLinkButton.cs` | `src/OsuUiKit/UserInterface/ExternalLinkButton.cs` | — |
| `osu.Game/Graphics/UserInterface/FPSCounter.cs` | `src/OsuUiKit/UserInterface/FPSCounter.cs` | — |
| `osu.Game/Graphics/UserInterface/FPSCounterTooltip.cs` | `src/OsuUiKit/UserInterface/FPSCounterTooltip.cs` | — |
| `osu.Game/Graphics/UserInterface/FocusedTextBox.cs` | `src/OsuUiKit/UserInterface/FocusedTextBox.cs` | — |
| `osu.Game/Graphics/UserInterface/GradientLineTabControl.cs` | `src/OsuUiKit/UserInterface/GradientLineTabControl.cs` | — |
| `osu.Game/Graphics/UserInterface/GrayButton.cs` | `src/OsuUiKit/UserInterface/GrayButton.cs` | — |
| `osu.Game/Graphics/UserInterface/HistoryTextBox.cs` | `src/OsuUiKit/UserInterface/HistoryTextBox.cs` | — |
| `osu.Game/Graphics/UserInterface/Hotkey.cs` | `src/OsuUiKit/UserInterface/Hotkey.cs` | — |
| `osu.Game/Graphics/UserInterface/HotkeyDisplay.cs` | `src/OsuUiKit/UserInterface/HotkeyDisplay.cs` | — |
| `osu.Game/Graphics/UserInterface/HoverClickSounds.cs` | `src/OsuUiKit/UserInterface/HoverClickSounds.cs` | — |
| `osu.Game/Graphics/UserInterface/HoverSampleDebounceComponent.cs` | `src/OsuUiKit/UserInterface/HoverSampleDebounceComponent.cs` | — |
| `osu.Game/Graphics/UserInterface/HoverSampleSet.cs` | `src/OsuUiKit/UserInterface/HoverSampleSet.cs` | — |
| `osu.Game/Graphics/UserInterface/HoverSounds.cs` | `src/OsuUiKit/UserInterface/HoverSounds.cs` | — |
| `osu.Game/Graphics/UserInterface/IconButton.cs` | `src/OsuUiKit/UserInterface/IconButton.cs` | — |
| `osu.Game/Graphics/UserInterface/LineGraph.cs` | `src/OsuUiKit/UserInterface/LineGraph.cs` | — |
| `osu.Game/Graphics/UserInterface/LoadingButton.cs` | `src/OsuUiKit/UserInterface/LoadingButton.cs` | — |
| `osu.Game/Graphics/UserInterface/LoadingLayer.cs` | `src/OsuUiKit/UserInterface/LoadingLayer.cs` | — |
| `osu.Game/Graphics/UserInterface/LoadingSpinner.cs` | `src/OsuUiKit/UserInterface/LoadingSpinner.cs` | — |
| `osu.Game/Graphics/UserInterface/MenuItemType.cs` | `src/OsuUiKit/UserInterface/MenuItemType.cs` | — |
| `osu.Game/Graphics/UserInterface/Nub.cs` | `src/OsuUiKit/UserInterface/Nub.cs` | — |
| `osu.Game/Graphics/UserInterface/OsuAnimatedButton.cs` | `src/OsuUiKit/UserInterface/OsuAnimatedButton.cs` | — |
| `osu.Game/Graphics/UserInterface/OsuButton.cs` | `src/OsuUiKit/UserInterface/OsuButton.cs` | — |
| `osu.Game/Graphics/UserInterface/OsuCheckbox.cs` | `src/OsuUiKit/UserInterface/OsuCheckbox.cs` | — |
| `osu.Game/Graphics/UserInterface/OsuContextMenu.cs` | `src/OsuUiKit/UserInterface/OsuContextMenu.cs` | — |
| `osu.Game/Graphics/UserInterface/OsuDropdown.cs` | `src/OsuUiKit/UserInterface/OsuDropdown.cs` | — |
| `osu.Game/Graphics/UserInterface/OsuEnumDropdown.cs` | `src/OsuUiKit/UserInterface/OsuEnumDropdown.cs` | — |
| `osu.Game/Graphics/UserInterface/OsuMenu.cs` | `src/OsuUiKit/UserInterface/OsuMenu.cs` | — |
| `osu.Game/Graphics/UserInterface/OsuMenuItem.cs` | `src/OsuUiKit/UserInterface/OsuMenuItem.cs` | — |
| `osu.Game/Graphics/UserInterface/OsuMenuItemSpacer.cs` | `src/OsuUiKit/UserInterface/OsuMenuItemSpacer.cs` | — |
| `osu.Game/Graphics/UserInterface/OsuMenuSamples.cs` | `src/OsuUiKit/UserInterface/OsuMenuSamples.cs` | — |
| `osu.Game/Graphics/UserInterface/OsuNumberBox.cs` | `src/OsuUiKit/UserInterface/OsuNumberBox.cs` | — |
| `osu.Game/Graphics/UserInterface/OsuPasswordTextBox.cs` | `src/OsuUiKit/UserInterface/OsuPasswordTextBox.cs` | — |
| `osu.Game/Graphics/UserInterface/OsuSliderBar.cs` | `src/OsuUiKit/UserInterface/OsuSliderBar.cs` | — |
| `osu.Game/Graphics/UserInterface/OsuTabControl.cs` | `src/OsuUiKit/UserInterface/OsuTabControl.cs` | — |
| `osu.Game/Graphics/UserInterface/OsuTabControlCheckbox.cs` | `src/OsuUiKit/UserInterface/OsuTabControlCheckbox.cs` | — |
| `osu.Game/Graphics/UserInterface/OsuTabDropdown.cs` | `src/OsuUiKit/UserInterface/OsuTabDropdown.cs` | — |
| `osu.Game/Graphics/UserInterface/OsuTextBox.cs` | `src/OsuUiKit/UserInterface/OsuTextBox.cs` | TODO(coupling): Beatmaps |
| `osu.Game/Graphics/UserInterface/PageTabControl.cs` | `src/OsuUiKit/UserInterface/PageTabControl.cs` | — |
| `osu.Game/Graphics/UserInterface/PercentageCounter.cs` | `src/OsuUiKit/UserInterface/PercentageCounter.cs` | — |
| `osu.Game/Graphics/UserInterface/ProgressBar.cs` | `src/OsuUiKit/UserInterface/ProgressBar.cs` | — |
| `osu.Game/Graphics/UserInterface/RangeSlider.cs` | `src/OsuUiKit/UserInterface/RangeSlider.cs` | — |
| `osu.Game/Graphics/UserInterface/RollingCounter.cs` | `src/OsuUiKit/UserInterface/RollingCounter.cs` | — |
| `osu.Game/Graphics/UserInterface/RoundedSliderBar.cs` | `src/OsuUiKit/UserInterface/RoundedSliderBar.cs` | — |
| `osu.Game/Graphics/UserInterface/ScoreCounter.cs` | `src/OsuUiKit/UserInterface/ScoreCounter.cs` | — |
| `osu.Game/Graphics/UserInterface/SearchTextBox.cs` | `src/OsuUiKit/UserInterface/SearchTextBox.cs` | — |
| `osu.Game/Graphics/UserInterface/SectionHeader.cs` | `src/OsuUiKit/UserInterface/SectionHeader.cs` | — |
| `osu.Game/Graphics/UserInterface/SeekLimitedSearchTextBox.cs` | `src/OsuUiKit/UserInterface/SeekLimitedSearchTextBox.cs` | — |
| `osu.Game/Graphics/UserInterface/SegmentedGraph.cs` | `src/OsuUiKit/UserInterface/SegmentedGraph.cs` | — |
| `osu.Game/Graphics/UserInterface/SelectionState.cs` | `src/OsuUiKit/UserInterface/SelectionState.cs` | — |
| `osu.Game/Graphics/UserInterface/ShearedButton.cs` | `src/OsuUiKit/UserInterface/ShearedButton.cs` | — |
| `osu.Game/Graphics/UserInterface/ShearedFilterTextBox.cs` | `src/OsuUiKit/UserInterface/ShearedFilterTextBox.cs` | — |
| `osu.Game/Graphics/UserInterface/ShearedNub.cs` | `src/OsuUiKit/UserInterface/ShearedNub.cs` | — |
| `osu.Game/Graphics/UserInterface/ShearedOverlayHeader.cs` | `src/OsuUiKit/UserInterface/ShearedOverlayHeader.cs` | — |
| `osu.Game/Graphics/UserInterface/ShearedRangeSlider.cs` | `src/OsuUiKit/UserInterface/ShearedRangeSlider.cs` | — |
| `osu.Game/Graphics/UserInterface/ShearedSearchTextBox.cs` | `src/OsuUiKit/UserInterface/ShearedSearchTextBox.cs` | — |
| `osu.Game/Graphics/UserInterface/ShearedSliderBar.cs` | `src/OsuUiKit/UserInterface/ShearedSliderBar.cs` | — |
| `osu.Game/Graphics/UserInterface/ShearedToggleButton.cs` | `src/OsuUiKit/UserInterface/ShearedToggleButton.cs` | — |
| `osu.Game/Graphics/UserInterface/ShowMoreButton.cs` | `src/OsuUiKit/UserInterface/ShowMoreButton.cs` | — |
| `osu.Game/Graphics/UserInterface/SlimEnumDropdown.cs` | `src/OsuUiKit/UserInterface/SlimEnumDropdown.cs` | — |
| `osu.Game/Graphics/UserInterface/StarCounter.cs` | `src/OsuUiKit/UserInterface/StarCounter.cs` | — |
| `osu.Game/Graphics/UserInterface/StatefulMenuItem.cs` | `src/OsuUiKit/UserInterface/StatefulMenuItem.cs` | — |
| `osu.Game/Graphics/UserInterface/TernaryState.cs` | `src/OsuUiKit/UserInterface/TernaryState.cs` | — |
| `osu.Game/Graphics/UserInterface/TernaryStateMenuItem.cs` | `src/OsuUiKit/UserInterface/TernaryStateMenuItem.cs` | — |
| `osu.Game/Graphics/UserInterface/TernaryStateRadioMenuItem.cs` | `src/OsuUiKit/UserInterface/TernaryStateRadioMenuItem.cs` | — |
| `osu.Game/Graphics/UserInterface/TernaryStateToggleMenuItem.cs` | `src/OsuUiKit/UserInterface/TernaryStateToggleMenuItem.cs` | — |
| `osu.Game/Graphics/UserInterface/TimeSlider.cs` | `src/OsuUiKit/UserInterface/TimeSlider.cs` | — |
| `osu.Game/Graphics/UserInterface/ToggleMenuItem.cs` | `src/OsuUiKit/UserInterface/ToggleMenuItem.cs` | — |
| `osu.Game/Graphics/UserInterface/TwoLayerButton.cs` | `src/OsuUiKit/UserInterface/TwoLayerButton.cs` | TODO(coupling): Beatmaps |
| `osu.Game/Graphics/UserInterface/PageSelector/PageEllipsis.cs` | `src/OsuUiKit/UserInterface/PageSelector/PageEllipsis.cs` | — |
| `osu.Game/Graphics/UserInterface/PageSelector/PageSelector.cs` | `src/OsuUiKit/UserInterface/PageSelector/PageSelector.cs` | — |
| `osu.Game/Graphics/UserInterface/PageSelector/PageSelectorButton.cs` | `src/OsuUiKit/UserInterface/PageSelector/PageSelectorButton.cs` | — |
| `osu.Game/Graphics/UserInterface/PageSelector/PageSelectorPageButton.cs` | `src/OsuUiKit/UserInterface/PageSelector/PageSelectorPageButton.cs` | — |
| `osu.Game/Graphics/UserInterface/PageSelector/PageSelectorPrevNextButton.cs` | `src/OsuUiKit/UserInterface/PageSelector/PageSelectorPrevNextButton.cs` | — |
| `osu.Game/Graphics/UserInterfaceV2/ColourDisplay.cs` | `src/OsuUiKit/UserInterfaceV2/ColourDisplay.cs` | — |
| `osu.Game/Graphics/UserInterfaceV2/ColourPalette.cs` | `src/OsuUiKit/UserInterfaceV2/ColourPalette.cs` | — |
| `osu.Game/Graphics/UserInterfaceV2/FormButton.cs` | `src/OsuUiKit/UserInterfaceV2/FormButton.cs` | — |
| `osu.Game/Graphics/UserInterfaceV2/FormCheckBox.cs` | `src/OsuUiKit/UserInterfaceV2/FormCheckBox.cs` | — |
| `osu.Game/Graphics/UserInterfaceV2/FormColourPalette.cs` | `src/OsuUiKit/UserInterfaceV2/FormColourPalette.cs` | — |
| `osu.Game/Graphics/UserInterfaceV2/FormControlBackground.cs` | `src/OsuUiKit/UserInterfaceV2/FormControlBackground.cs` | — |
| `osu.Game/Graphics/UserInterfaceV2/FormDropdown.cs` | `src/OsuUiKit/UserInterfaceV2/FormDropdown.cs` | — |
| `osu.Game/Graphics/UserInterfaceV2/FormFieldCaption.cs` | `src/OsuUiKit/UserInterfaceV2/FormFieldCaption.cs` | — |
| `osu.Game/Graphics/UserInterfaceV2/FormFileSelector.cs` | `src/OsuUiKit/UserInterfaceV2/FormFileSelector.cs` | — |
| `osu.Game/Graphics/UserInterfaceV2/FormNumberBox.cs` | `src/OsuUiKit/UserInterfaceV2/FormNumberBox.cs` | — |
| `osu.Game/Graphics/UserInterfaceV2/FormSliderBar.cs` | `src/OsuUiKit/UserInterfaceV2/FormSliderBar.cs` | — |
| `osu.Game/Graphics/UserInterfaceV2/FormTextBox.cs` | `src/OsuUiKit/UserInterfaceV2/FormTextBox.cs` | — |
| `osu.Game/Graphics/UserInterfaceV2/IFormControl.cs` | `src/OsuUiKit/UserInterfaceV2/IFormControl.cs` | — |
| `osu.Game/Graphics/UserInterfaceV2/LabelledColourPalette.cs` | `src/OsuUiKit/UserInterfaceV2/LabelledColourPalette.cs` | — |
| `osu.Game/Graphics/UserInterfaceV2/LabelledComponent.cs` | `src/OsuUiKit/UserInterfaceV2/LabelledComponent.cs` | — |
| `osu.Game/Graphics/UserInterfaceV2/LabelledDrawable.cs` | `src/OsuUiKit/UserInterfaceV2/LabelledDrawable.cs` | — |
| `osu.Game/Graphics/UserInterfaceV2/LabelledDropdown.cs` | `src/OsuUiKit/UserInterfaceV2/LabelledDropdown.cs` | — |
| `osu.Game/Graphics/UserInterfaceV2/LabelledEnumDropdown.cs` | `src/OsuUiKit/UserInterfaceV2/LabelledEnumDropdown.cs` | — |
| `osu.Game/Graphics/UserInterfaceV2/LabelledNumberBox.cs` | `src/OsuUiKit/UserInterfaceV2/LabelledNumberBox.cs` | — |
| `osu.Game/Graphics/UserInterfaceV2/LabelledSliderBar.cs` | `src/OsuUiKit/UserInterfaceV2/LabelledSliderBar.cs` | — |
| `osu.Game/Graphics/UserInterfaceV2/LabelledSwitchButton.cs` | `src/OsuUiKit/UserInterfaceV2/LabelledSwitchButton.cs` | — |
| `osu.Game/Graphics/UserInterfaceV2/LabelledTextBox.cs` | `src/OsuUiKit/UserInterfaceV2/LabelledTextBox.cs` | — |
| `osu.Game/Graphics/UserInterfaceV2/OsuColourPicker.cs` | `src/OsuUiKit/UserInterfaceV2/OsuColourPicker.cs` | — |
| `osu.Game/Graphics/UserInterfaceV2/OsuDirectorySelector.cs` | `src/OsuUiKit/UserInterfaceV2/OsuDirectorySelector.cs` | — |
| `osu.Game/Graphics/UserInterfaceV2/OsuFileSelector.cs` | `src/OsuUiKit/UserInterfaceV2/OsuFileSelector.cs` | — |
| `osu.Game/Graphics/UserInterfaceV2/OsuHSVColourPicker.cs` | `src/OsuUiKit/UserInterfaceV2/OsuHSVColourPicker.cs` | — |
| `osu.Game/Graphics/UserInterfaceV2/OsuHexColourPicker.cs` | `src/OsuUiKit/UserInterfaceV2/OsuHexColourPicker.cs` | — |
| `osu.Game/Graphics/UserInterfaceV2/OsuPopover.cs` | `src/OsuUiKit/UserInterfaceV2/OsuPopover.cs` | — |
| `osu.Game/Graphics/UserInterfaceV2/ReportPopover.cs` | `src/OsuUiKit/UserInterfaceV2/ReportPopover.cs` | — |
| `osu.Game/Graphics/UserInterfaceV2/RoundedButton.cs` | `src/OsuUiKit/UserInterfaceV2/RoundedButton.cs` | — |
| `osu.Game/Graphics/UserInterfaceV2/ShearedDropdown.cs` | `src/OsuUiKit/UserInterfaceV2/ShearedDropdown.cs` | — |
| `osu.Game/Graphics/UserInterfaceV2/SwitchButton.cs` | `src/OsuUiKit/UserInterfaceV2/SwitchButton.cs` | — |
| `osu.Game/Graphics/UserInterfaceV2/FileSelection/BackgroundLayer.cs` | `src/OsuUiKit/UserInterfaceV2/FileSelection/BackgroundLayer.cs` | — |
| `osu.Game/Graphics/UserInterfaceV2/FileSelection/HiddenFilesToggleCheckbox.cs` | `src/OsuUiKit/UserInterfaceV2/FileSelection/HiddenFilesToggleCheckbox.cs` | — |
| `osu.Game/Graphics/UserInterfaceV2/FileSelection/OsuDirectorySelectorBreadcrumbDisplay.cs` | `src/OsuUiKit/UserInterfaceV2/FileSelection/OsuDirectorySelectorBreadcrumbDisplay.cs` | — |
| `osu.Game/Graphics/UserInterfaceV2/FileSelection/OsuDirectorySelectorDirectory.cs` | `src/OsuUiKit/UserInterfaceV2/FileSelection/OsuDirectorySelectorDirectory.cs` | — |
| `osu.Game/Graphics/UserInterfaceV2/FileSelection/OsuDirectorySelectorParentDirectory.cs` | `src/OsuUiKit/UserInterfaceV2/FileSelection/OsuDirectorySelectorParentDirectory.cs` | — |

## Known Coupling Issues

Many controls use `[BackgroundDependencyLoader]` to receive framework-level or game-level services at
runtime. The most common dependencies are:

- **OsuColour** — centralised colour palette. Available in any osu-framework DI tree that registers it.
- **AudioManager** — sample/track playback. Provided automatically by the osu-framework `Game` host.
- **OverlayColourProvider** — contextual colour theming for overlays. Provided by `OsuGame` itself.
- **OsuGame** — top-level game object. Tightly coupled to the main game; hard to replace.
- **ISamplePlaybackDisabler** — pauses UI sounds during gameplay. Provided by `OsuGame`.

Files that reference `osu.Game.Beatmaps`, `osu.Game.Online`, `osu.Game.Rulesets`, or `osu.Game.Scoring`
are flagged `TODO(coupling)` in the table above. These files depend on game-specific domain objects and
require the most work to decouple.

## Recommended Decoupling Steps

1. **Run the coupling checker** — execute `bash src/OsuUiKit/check-coupling.sh` from the repo root to
   get an up-to-date list of all remaining `osu.Game.*` references.
2. **Replace `OsuColour` usages** — extract the colour constants you need into a local `ThemeColours`
   class so you don't depend on the full `OsuColour` graph.
3. **Stub `OverlayColourProvider`** — create a minimal implementation that returns sensible defaults;
   register it in your DI container before building the UI.
4. **Eliminate `osu.Game.Audio` dependencies** — replace `HitSampleInfo` references with framework-
   native `ISample` lookups from `AudioManager`.
5. **Remove `osu.Game.Beatmaps.ControlPoints` references** — `BeatSyncedContainer` reads beat timing
   from a running `IBeatSyncProvider`. Provide your own timing source or remove the component.
6. **Isolate Online/Chat components** — `LinkFlowContainer` and related classes reference
   `osu.Game.Online.Chat`. Either replace the link-handling logic or provide a stub `ILinkHandler`.
7. **Validate each TODO(coupling) file individually** — some files only import a type for a single
   feature; removing that feature may eliminate the dependency entirely.

