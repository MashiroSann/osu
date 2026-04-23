# List

本文档列出 `OsuUiKit` 中通过反射提取的“可调用控件”（`public`、`Drawable`、非抽象、含无参构造函数）。

> 说明：若控件是泛型类型，调用示例中的 `T` / `T1` / `T2` 为占位类型参数，请替换为你的实际类型。

## 通用引用
```csharp
using OsuUiKit;
using OsuUiKit.Containers;
using OsuUiKit.Containers.Markdown;
using OsuUiKit.Sprites;
using OsuUiKit.UserInterface;
using OsuUiKit.UserInterface.PageSelector;
using OsuUiKit.UserInterfaceV2;
```

## 控件清单（共 97 项）
| 控件名称 | 调用方式 | 需要引用的命名空间 |
|---|---|---|
| `BeatSyncedContainer` | `var control = new OsuUiKit.Containers.BeatSyncedContainer();` | `using OsuUiKit.Containers;` |
| `ConstrainedIconContainer` | `var control = new OsuUiKit.Containers.ConstrainedIconContainer();` | `using OsuUiKit.Containers;` |
| `LogoTrackingContainer` | `var control = new OsuUiKit.Containers.LogoTrackingContainer();` | `using OsuUiKit.Containers;` |
| `OsuMarkdownContainer` | `var control = new OsuUiKit.Containers.Markdown.OsuMarkdownContainer();` | `using OsuUiKit.Containers.Markdown;` |
| `OsuMarkdownSeparator` | `var control = new OsuUiKit.Containers.Markdown.OsuMarkdownSeparator();` | `using OsuUiKit.Containers.Markdown;` |
| `OsuMarkdownTextFlowContainer` | `var control = new OsuUiKit.Containers.Markdown.OsuMarkdownTextFlowContainer();` | `using OsuUiKit.Containers.Markdown;` |
| `PlaylistItemHandle` | `var control = new OsuUiKit.Containers.OsuRearrangeableListItem<T>.PlaylistItemHandle();` | `using OsuUiKit.Containers;` |
| `OsuScrollContainer` | `var control = new OsuUiKit.Containers.OsuScrollContainer();` | `using OsuUiKit.Containers;` |
| `ParallaxContainer` | `var control = new OsuUiKit.Containers.ParallaxContainer();` | `using OsuUiKit.Containers;` |
| `ReverseChildIDFillFlowContainer<T>` | `var control = new OsuUiKit.Containers.ReverseChildIDFillFlowContainer<T>();` | `using OsuUiKit.Containers;` |
| `SectionsContainer<T>` | `var control = new OsuUiKit.Containers.SectionsContainer<T>();` | `using OsuUiKit.Containers;` |
| `SelectionCycleFillFlowContainer<T>` | `var control = new OsuUiKit.Containers.SelectionCycleFillFlowContainer<T>();` | `using OsuUiKit.Containers;` |
| `ShakeContainer` | `var control = new OsuUiKit.Containers.ShakeContainer();` | `using OsuUiKit.Containers;` |
| `UprightAspectMaintainingContainer` | `var control = new OsuUiKit.Containers.UprightAspectMaintainingContainer();` | `using OsuUiKit.Containers;` |
| `UserTrackingScrollContainer` | `var control = new OsuUiKit.Containers.UserTrackingScrollContainer();` | `using OsuUiKit.Containers;` |
| `UserTrackingScrollContainer<T>` | `var control = new OsuUiKit.Containers.UserTrackingScrollContainer<T>();` | `using OsuUiKit.Containers;` |
| `WaveContainer` | `var control = new OsuUiKit.Containers.WaveContainer();` | `using OsuUiKit.Containers;` |
| `DateTooltip` | `var control = new OsuUiKit.DateTooltip();` | `using OsuUiKit;` |
| `ErrorTextFlowContainer` | `var control = new OsuUiKit.ErrorTextFlowContainer();` | `using OsuUiKit;` |
| `GhostIcon` | `var control = new OsuUiKit.GhostIcon();` | `using OsuUiKit;` |
| `InputBlockingContainer` | `var control = new OsuUiKit.InputBlockingContainer();` | `using OsuUiKit;` |
| `GlowingSpriteText` | `var control = new OsuUiKit.Sprites.GlowingSpriteText();` | `using OsuUiKit.Sprites;` |
| `LogoAnimation` | `var control = new OsuUiKit.Sprites.LogoAnimation();` | `using OsuUiKit.Sprites;` |
| `OsuSpriteText` | `var control = new OsuUiKit.Sprites.OsuSpriteText();` | `using OsuUiKit.Sprites;` |
| `SpriteIconWithTooltip` | `var control = new OsuUiKit.Sprites.SpriteIconWithTooltip();` | `using OsuUiKit.Sprites;` |
| `TruncatingSpriteText` | `var control = new OsuUiKit.Sprites.TruncatingSpriteText();` | `using OsuUiKit.Sprites;` |
| `Bar` | `var control = new OsuUiKit.UserInterface.Bar();` | `using OsuUiKit.UserInterface;` |
| `BarGraph` | `var control = new OsuUiKit.UserInterface.BarGraph();` | `using OsuUiKit.UserInterface;` |
| `BasicSearchTextBox` | `var control = new OsuUiKit.UserInterface.BasicSearchTextBox();` | `using OsuUiKit.UserInterface;` |
| `BreadcrumbControl<T>` | `var control = new OsuUiKit.UserInterface.BreadcrumbControl<T>();` | `using OsuUiKit.UserInterface;` |
| `DangerousRoundedButton` | `var control = new OsuUiKit.UserInterface.DangerousRoundedButton();` | `using OsuUiKit.UserInterface;` |
| `DownloadButton` | `var control = new OsuUiKit.UserInterface.DownloadButton();` | `using OsuUiKit.UserInterface;` |
| `ExpandableSlider<T>` | `var control = new OsuUiKit.UserInterface.ExpandableSlider<T>();` | `using OsuUiKit.UserInterface;` |
| `ExpandableSlider<T1, T2>` | `var control = new OsuUiKit.UserInterface.ExpandableSlider<T1, T2>();` | `using OsuUiKit.UserInterface;` |
| `ExpandingBar` | `var control = new OsuUiKit.UserInterface.ExpandingBar();` | `using OsuUiKit.UserInterface;` |
| `FPSCounter` | `var control = new OsuUiKit.UserInterface.FPSCounter();` | `using OsuUiKit.UserInterface;` |
| `FPSCounterTooltip` | `var control = new OsuUiKit.UserInterface.FPSCounterTooltip();` | `using OsuUiKit.UserInterface;` |
| `FocusedTextBox` | `var control = new OsuUiKit.UserInterface.FocusedTextBox();` | `using OsuUiKit.UserInterface;` |
| `HotkeyDisplay` | `var control = new OsuUiKit.UserInterface.HotkeyDisplay();` | `using OsuUiKit.UserInterface;` |
| `IconButton` | `var control = new OsuUiKit.UserInterface.IconButton();` | `using OsuUiKit.UserInterface;` |
| `LineGraph` | `var control = new OsuUiKit.UserInterface.LineGraph();` | `using OsuUiKit.UserInterface;` |
| `OsuDropdown<T>` | `var control = new OsuUiKit.UserInterface.OsuDropdown<T>();` | `using OsuUiKit.UserInterface;` |
| `OsuDropdownHeader` | `var control = new OsuUiKit.UserInterface.OsuDropdown<T>.OsuDropdownHeader();` | `using OsuUiKit.UserInterface;` |
| `OsuDropdownMenu` | `var control = new OsuUiKit.UserInterface.OsuDropdown<T>.OsuDropdownMenu();` | `using OsuUiKit.UserInterface;` |
| `OsuEnumDropdown<T>` | `var control = new OsuUiKit.UserInterface.OsuEnumDropdown<T>();` | `using OsuUiKit.UserInterface;` |
| `OsuMenuSamples` | `var control = new OsuUiKit.UserInterface.OsuMenuSamples();` | `using OsuUiKit.UserInterface;` |
| `OsuNumberBox` | `var control = new OsuUiKit.UserInterface.OsuNumberBox();` | `using OsuUiKit.UserInterface;` |
| `OsuPasswordTextBox` | `var control = new OsuUiKit.UserInterface.OsuPasswordTextBox();` | `using OsuUiKit.UserInterface;` |
| `OsuTabControlCheckbox` | `var control = new OsuUiKit.UserInterface.OsuTabControlCheckbox();` | `using OsuUiKit.UserInterface;` |
| `OsuTabControl<T>` | `var control = new OsuUiKit.UserInterface.OsuTabControl<T>();` | `using OsuUiKit.UserInterface;` |
| `OsuTabDropdown<T>` | `var control = new OsuUiKit.UserInterface.OsuTabDropdown<T>();` | `using OsuUiKit.UserInterface;` |
| `OsuTextBox` | `var control = new OsuUiKit.UserInterface.OsuTextBox();` | `using OsuUiKit.UserInterface;` |
| `PageSelector` | `var control = new OsuUiKit.UserInterface.PageSelector.PageSelector();` | `using OsuUiKit.UserInterface.PageSelector;` |
| `PageTabControl<T>` | `var control = new OsuUiKit.UserInterface.PageTabControl<T>();` | `using OsuUiKit.UserInterface;` |
| `PercentageCounter` | `var control = new OsuUiKit.UserInterface.PercentageCounter();` | `using OsuUiKit.UserInterface;` |
| `RangeSlider` | `var control = new OsuUiKit.UserInterface.RangeSlider();` | `using OsuUiKit.UserInterface;` |
| `RoundedSliderBar<T>` | `var control = new OsuUiKit.UserInterface.RoundedSliderBar<T>();` | `using OsuUiKit.UserInterface;` |
| `SliderNub` | `var control = new OsuUiKit.UserInterface.RoundedSliderBar<T>.SliderNub();` | `using OsuUiKit.UserInterface;` |
| `SearchTextBox` | `var control = new OsuUiKit.UserInterface.SearchTextBox();` | `using OsuUiKit.UserInterface;` |
| `SeekLimitedSearchTextBox` | `var control = new OsuUiKit.UserInterface.SeekLimitedSearchTextBox();` | `using OsuUiKit.UserInterface;` |
| `ShearedButton` | `var control = new OsuUiKit.UserInterface.ShearedButton();` | `using OsuUiKit.UserInterface;` |
| `ShearedFilterTextBox` | `var control = new OsuUiKit.UserInterface.ShearedFilterTextBox();` | `using OsuUiKit.UserInterface;` |
| `ShearedNub` | `var control = new OsuUiKit.UserInterface.ShearedNub();` | `using OsuUiKit.UserInterface;` |
| `ShearedOverlayHeader` | `var control = new OsuUiKit.UserInterface.ShearedOverlayHeader();` | `using OsuUiKit.UserInterface;` |
| `ShearedSearchTextBox` | `var control = new OsuUiKit.UserInterface.ShearedSearchTextBox();` | `using OsuUiKit.UserInterface;` |
| `ShearedSliderBar<T>` | `var control = new OsuUiKit.UserInterface.ShearedSliderBar<T>();` | `using OsuUiKit.UserInterface;` |
| `ShearedToggleButton` | `var control = new OsuUiKit.UserInterface.ShearedToggleButton();` | `using OsuUiKit.UserInterface;` |
| `ShowMoreButton` | `var control = new OsuUiKit.UserInterface.ShowMoreButton();` | `using OsuUiKit.UserInterface;` |
| `ChevronIcon` | `var control = new OsuUiKit.UserInterface.ShowMoreButton.ChevronIcon();` | `using OsuUiKit.UserInterface;` |
| `SlimEnumDropdown<T>` | `var control = new OsuUiKit.UserInterface.SlimEnumDropdown<T>();` | `using OsuUiKit.UserInterface;` |
| `DefaultStar` | `var control = new OsuUiKit.UserInterface.StarCounter.DefaultStar();` | `using OsuUiKit.UserInterface;` |
| `TimeSlider` | `var control = new OsuUiKit.UserInterface.TimeSlider();` | `using OsuUiKit.UserInterface;` |
| `ColourDisplay` | `var control = new OsuUiKit.UserInterfaceV2.ColourDisplay();` | `using OsuUiKit.UserInterfaceV2;` |
| `ColourPalette` | `var control = new OsuUiKit.UserInterfaceV2.ColourPalette();` | `using OsuUiKit.UserInterfaceV2;` |
| `FormButton` | `var control = new OsuUiKit.UserInterfaceV2.FormButton();` | `using OsuUiKit.UserInterfaceV2;` |
| `Button` | `var control = new OsuUiKit.UserInterfaceV2.FormButton.Button();` | `using OsuUiKit.UserInterfaceV2;` |
| `FormCheckBox` | `var control = new OsuUiKit.UserInterfaceV2.FormCheckBox();` | `using OsuUiKit.UserInterfaceV2;` |
| `FormColourPalette` | `var control = new OsuUiKit.UserInterfaceV2.FormColourPalette();` | `using OsuUiKit.UserInterfaceV2;` |
| `FormControlBackground` | `var control = new OsuUiKit.UserInterfaceV2.FormControlBackground();` | `using OsuUiKit.UserInterfaceV2;` |
| `FormDropdown<T>` | `var control = new OsuUiKit.UserInterfaceV2.FormDropdown<T>();` | `using OsuUiKit.UserInterfaceV2;` |
| `FormEnumDropdown<T>` | `var control = new OsuUiKit.UserInterfaceV2.FormEnumDropdown<T>();` | `using OsuUiKit.UserInterfaceV2;` |
| `FormFieldCaption` | `var control = new OsuUiKit.UserInterfaceV2.FormFieldCaption();` | `using OsuUiKit.UserInterfaceV2;` |
| `FormSliderBar<T>` | `var control = new OsuUiKit.UserInterfaceV2.FormSliderBar<T>();` | `using OsuUiKit.UserInterfaceV2;` |
| `InnerSlider` | `var control = new OsuUiKit.UserInterfaceV2.FormSliderBar<T>.InnerSlider();` | `using OsuUiKit.UserInterfaceV2;` |
| `InnerSliderNub` | `var control = new OsuUiKit.UserInterfaceV2.FormSliderBar<T>.InnerSliderNub();` | `using OsuUiKit.UserInterfaceV2;` |
| `FormTextBox` | `var control = new OsuUiKit.UserInterfaceV2.FormTextBox();` | `using OsuUiKit.UserInterfaceV2;` |
| `LabelledColourPalette` | `var control = new OsuUiKit.UserInterfaceV2.LabelledColourPalette();` | `using OsuUiKit.UserInterfaceV2;` |
| `LabelledNumberBox` | `var control = new OsuUiKit.UserInterfaceV2.LabelledNumberBox();` | `using OsuUiKit.UserInterfaceV2;` |
| `LabelledSliderBar<T>` | `var control = new OsuUiKit.UserInterfaceV2.LabelledSliderBar<T>();` | `using OsuUiKit.UserInterfaceV2;` |
| `LabelledSwitchButton` | `var control = new OsuUiKit.UserInterfaceV2.LabelledSwitchButton();` | `using OsuUiKit.UserInterfaceV2;` |
| `LabelledTextBox` | `var control = new OsuUiKit.UserInterfaceV2.LabelledTextBox();` | `using OsuUiKit.UserInterfaceV2;` |
| `OsuColourPicker` | `var control = new OsuUiKit.UserInterfaceV2.OsuColourPicker();` | `using OsuUiKit.UserInterfaceV2;` |
| `OsuHSVColourPicker` | `var control = new OsuUiKit.UserInterfaceV2.OsuHSVColourPicker();` | `using OsuUiKit.UserInterfaceV2;` |
| `OsuHexColourPicker` | `var control = new OsuUiKit.UserInterfaceV2.OsuHexColourPicker();` | `using OsuUiKit.UserInterfaceV2;` |
| `RoundedButton` | `var control = new OsuUiKit.UserInterfaceV2.RoundedButton();` | `using OsuUiKit.UserInterfaceV2;` |
| `ShearedDropdownHeader` | `var control = new OsuUiKit.UserInterfaceV2.ShearedDropdown<T>.ShearedDropdownHeader();` | `using OsuUiKit.UserInterfaceV2;` |
| `SwitchButton` | `var control = new OsuUiKit.UserInterfaceV2.SwitchButton();` | `using OsuUiKit.UserInterfaceV2;` |
