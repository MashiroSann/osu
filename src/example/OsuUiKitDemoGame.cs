// OsuUiKit 控件展示主程序 (OsuUiKit Control Gallery Main Program)
// 窗体大小: 1280×720 (16:9)
// 左侧显示控件名称，右侧显示控件预览，支持鼠标滚轮滚动

using System;
using System.Collections.Generic;
using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Configuration;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.IO.Stores;
using osu.Game.Overlays;
using osuTK;
using osuTK.Graphics;
using OsuUiKit;
using OsuUiKit.Containers;
using OsuUiKit.Containers.Markdown;
using OsuUiKit.Sprites;
using OsuUiKit.UserInterface;
using OsuUiKit.UserInterface.PageSelector;
using OsuUiKit.UserInterfaceV2;
using Colour4 = osu.Framework.Graphics.Colour4;
using FontUsage = osu.Framework.Graphics.Sprites.FontUsage;

namespace OsuUiKitDemo
{
    /// <summary>演示用枚举，用于展示枚举下拉菜单控件。</summary>
    public enum DemoOption
    {
        [System.ComponentModel.Description("选项一 Option1")]
        Option1,
        [System.ComponentModel.Description("选项二 Option2")]
        Option2,
        [System.ComponentModel.Description("选项三 Option3")]
        Option3,
    }

    /// <summary>
    /// OsuUiKit 控件展示程序。
    /// 窗体默认 1280×720，展示 OsuUiKit 中的所有 UI 控件。
    /// </summary>
    public partial class OsuUiKitDemoGame : osu.Framework.Game
    {
        // ── 依赖注入：向整个 DI 容器提供 OsuColour 和 OverlayColourProvider ──────
        protected override IReadOnlyDependencyContainer CreateChildDependencies(IReadOnlyDependencyContainer parent)
        {
            var deps = new osu.Framework.Allocation.DependencyContainer(base.CreateChildDependencies(parent));
            deps.Cache(new OsuColour());
            deps.Cache(new OverlayColourProvider(OverlayColourScheme.Blue));
            return deps;
        }

        [BackgroundDependencyLoader]
        private void load()
        {
            // 加载 osu! 字体资源 (Torus / Venera)
            try
            {
                var store = new NamespacedResourceStore<byte[]>(
                    new DllResourceStore(typeof(osu.Game.Resources.OsuResources).Assembly),
                    "Resources");
                Resources.AddStore(store);

                AddFont(Resources, @"Fonts/Torus/Torus-Regular");
                AddFont(Resources, @"Fonts/Torus/Torus-Light");
                AddFont(Resources, @"Fonts/Torus/Torus-SemiBold");
                AddFont(Resources, @"Fonts/Torus/Torus-Bold");
                AddFont(Resources, @"Fonts/TorusAlternate/TorusAlternate-Regular");
                AddFont(Resources, @"Fonts/TorusAlternate/TorusAlternate-Light");
                AddFont(Resources, @"Fonts/TorusAlternate/TorusAlternate-SemiBold");
                AddFont(Resources, @"Fonts/TorusAlternate/TorusAlternate-Bold");
                AddFont(Resources, @"Fonts/Venera/Venera-100");
                AddFont(Resources, @"Fonts/Venera/Venera-300");
                AddFont(Resources, @"Fonts/Venera/Venera-900");
            }
            catch
            {
                // 字体加载失败时使用系统默认字体
            }

            Child = new ControlGallery { RelativeSizeAxes = Axes.Both };
        }

        [Resolved]
        private FrameworkConfigManager frameworkConfig { get; set; } = null!;

        protected override void LoadComplete()
        {
            base.LoadComplete();
            frameworkConfig.SetValue(FrameworkSetting.WindowedSize, new System.Drawing.Size(1280, 720));
            if (Window != null)
                Window.Title = "OsuUiKit 控件展示 (Control Gallery)  |  1280×720";
        }
    }

    // ════════════════════════════════════════════════════════════════════════════
    //  ControlGallery  —— 滚动式两列控件展示界面
    // ════════════════════════════════════════════════════════════════════════════

    /// <summary>
    /// 控件画廊：左列显示控件名称，右列显示控件预览，可通过鼠标滚轮上下滚动。
    /// </summary>
    public partial class ControlGallery : CompositeDrawable
    {
        // 左侧名称列宽度
        private const float NAME_COL = 270f;
        // 分隔线宽度
        private const float SEP = 2f;
        // 内边距
        private const float PAD = 10f;
        // 默认行高
        private const float ROW_H = 70f;

        // 背景色（深色主题）
        private static readonly Color4 BG = new Color4(18, 18, 28, 255);
        // 名称列背景色
        private static readonly Color4 NAME_BG = new Color4(38, 38, 56, 255);
        // 分隔线颜色
        private static readonly Color4 SEP_COL = new Color4(65, 65, 90, 255);
        // 分类标题背景色
        private static readonly Color4 CAT_BG = new Color4(32, 32, 48, 255);
        // 名称文字颜色
        private static readonly Color4 NAME_FG = new Color4(220, 220, 235, 255);
        // 分类标题文字颜色（金色）
        private static readonly Color4 CAT_FG = new Color4(255, 200, 80, 255);
        // 列头颜色
        private static readonly Color4 HDR_FG = new Color4(160, 160, 190, 255);

        [BackgroundDependencyLoader]
        private void load()
        {
            InternalChildren = new Drawable[]
            {
                new Box { RelativeSizeAxes = Axes.Both, Colour = BG },
                new OsuScrollContainer
                {
                    RelativeSizeAxes = Axes.Both,
                    ScrollbarVisible = true,
                    Child = buildGalleryContent(),
                },
            };
        }

        // ── 主内容构建 ────────────────────────────────────────────────────────

        private Drawable buildGalleryContent()
        {
            var flow = new FillFlowContainer
            {
                RelativeSizeAxes = Axes.X,
                AutoSizeAxes = Axes.Y,
                Direction = FillDirection.Vertical,
                Padding = new MarginPadding { Horizontal = 8, Vertical = 10 },
                Spacing = new Vector2(0, 2),
            };

            // ── 标题 ──
            flow.Add(new OsuSpriteText
            {
                Text = "OsuUiKit 控件展示  (Control Gallery)",
                Font = OsuFont.GetFont(size: 24, weight: FontWeight.Bold),
                Colour = Color4.White,
                Margin = new MarginPadding { Bottom = 4 },
            });

            flow.Add(new OsuSpriteText
            {
                Text = "左列：控件名称  |  右列：控件预览  |  使用鼠标滚轮或拖拽滚动查看全部控件",
                Font = OsuFont.GetFont(size: 12),
                Colour = new Color4(150, 150, 180, 255),
                Margin = new MarginPadding { Bottom = 6 },
            });

            // ── 列头 ──
            flow.Add(buildColumnHeader());
            flow.Add(new Box
            {
                RelativeSizeAxes = Axes.X,
                Height = 1,
                Colour = SEP_COL,
                Margin = new MarginPadding { Vertical = 3 },
            });

            // ════ 容器类 Containers ════════════════════════════════════════════
            flow.Add(buildCat("容器类 (Containers)"));

            flow.Add(buildRow("BeatSyncedContainer",
                () => new BeatSyncedContainer
                {
                    Size = new Vector2(160, 44),
                    Child = new Box { RelativeSizeAxes = Axes.Both, Colour = new Color4(30, 55, 130, 210) },
                }));

            flow.Add(buildRow("ConstrainedIconContainer",
                () => new ConstrainedIconContainer
                {
                    Size = new Vector2(36, 36),
                    Icon = new SpriteIcon { Icon = FontAwesome.Solid.Star, RelativeSizeAxes = Axes.Both },
                }));

            flow.Add(buildRow("LogoTrackingContainer",
                () => new LogoTrackingContainer
                {
                    Size = new Vector2(160, 44),
                    Child = new Box { RelativeSizeAxes = Axes.Both, Colour = new Color4(70, 30, 100, 200) },
                }));

            flow.Add(buildRow("OsuMarkdownContainer",
                () =>
                {
                    var c = new OsuMarkdownContainer { RelativeSizeAxes = Axes.X, AutoSizeAxes = Axes.Y };
                    c.Text = "**粗体** *斜体* `代码块` [链接](https://osu.ppy.sh)";
                    return c;
                }, 80));

            flow.Add(buildRow("OsuMarkdownSeparator",
                () => new OsuMarkdownSeparator { RelativeSizeAxes = Axes.X, Height = 2 }));

            flow.Add(buildRow("OsuMarkdownTextFlowContainer",
                () =>
                {
                    var tf = new OsuMarkdownTextFlowContainer { RelativeSizeAxes = Axes.X, AutoSizeAxes = Axes.Y };
                    tf.AddText("Markdown 文本流容器示例 text-flow container demo");
                    return tf;
                }));

            flow.Add(buildRow("OsuScrollContainer",
                () => new OsuScrollContainer
                {
                    Size = new Vector2(300, 50),
                    ScrollbarVisible = true,
                    Child = new Box { Width = 700, Height = 30, Colour = Color4.CornflowerBlue },
                }));

            flow.Add(buildRow("ParallaxContainer",
                () => new ParallaxContainer
                {
                    Size = new Vector2(160, 44),
                    Child = new Box { RelativeSizeAxes = Axes.Both, Colour = new Color4(30, 120, 55, 200) },
                }));

            flow.Add(buildRow("ReverseChildIDFillFlowContainer<T>",
                () => new ReverseChildIDFillFlowContainer<Drawable>
                {
                    AutoSizeAxes = Axes.Both,
                    Direction = FillDirection.Horizontal,
                    Spacing = new Vector2(4),
                    Children = new Drawable[]
                    {
                        new Box { Size = new Vector2(44, 30), Colour = Color4.Red },
                        new Box { Size = new Vector2(44, 30), Colour = Color4.Lime },
                        new Box { Size = new Vector2(44, 30), Colour = Color4.Blue },
                    },
                }));

            flow.Add(buildRow("SectionsContainer<T>",
                () => new SectionsContainer<Drawable> { Size = new Vector2(200, 50) }));

            flow.Add(buildRow("SelectionCycleFillFlowContainer<T>",
                () => new SelectionCycleFillFlowContainer<DialogButton>
                {
                    AutoSizeAxes = Axes.Both,
                    Direction = FillDirection.Horizontal,
                    Spacing = new Vector2(4),
                    Children = new[]
                    {
                        new DialogButton
                        {
                            Size = new Vector2(80, 30),
                            Text = "选项A",
                            ButtonColour = Color4.Orange,
                        },
                        new DialogButton
                        {
                            Size = new Vector2(80, 30),
                            Text = "选项B",
                            ButtonColour = Color4.Purple,
                        },
                    },
                }, 50));

            flow.Add(buildRow("ShakeContainer",
                () => new ShakeContainer
                {
                    Size = new Vector2(160, 44),
                    Child = new Box { RelativeSizeAxes = Axes.Both, Colour = new Color4(180, 30, 30, 200) },
                }));

            flow.Add(buildRow("UprightAspectMaintainingContainer",
                () => new UprightAspectMaintainingContainer
                {
                    Size = new Vector2(100, 44),
                    Child = new Box { RelativeSizeAxes = Axes.Both, Colour = new Color4(30, 180, 180, 200) },
                }));

            flow.Add(buildRow("UserTrackingScrollContainer",
                () => new UserTrackingScrollContainer
                {
                    Size = new Vector2(300, 50),
                    Child = new Box { Width = 700, Height = 30, Colour = Color4.ForestGreen },
                }));

            flow.Add(buildRow("UserTrackingScrollContainer<Drawable>",
                () => new UserTrackingScrollContainer<Drawable>
                {
                    Size = new Vector2(300, 50),
                    Child = new Box { Width = 700, Height = 30, Colour = Color4.SeaGreen },
                }));

            flow.Add(buildRow("WaveContainer",
                () => new WaveContainer { Size = new Vector2(160, 50) }));

            // ════ 基础类 Core ══════════════════════════════════════════════════
            flow.Add(buildCat("基础类 (Core)"));

            flow.Add(buildRow("DateTooltip",
                () => new DateTooltip { Size = new Vector2(180, 40) }));

            flow.Add(buildRow("ErrorTextFlowContainer",
                () =>
                {
                    var e = new ErrorTextFlowContainer { RelativeSizeAxes = Axes.X, AutoSizeAxes = Axes.Y };
                    e.AddErrors(new[] { "示例错误提示 Sample Error Message" });
                    return e;
                }));

            flow.Add(buildRow("GhostIcon",
                () => new GhostIcon { Size = new Vector2(40, 40) }));

            flow.Add(buildRow("InputBlockingContainer",
                () => new InputBlockingContainer
                {
                    Size = new Vector2(180, 44),
                    Child = new Box { RelativeSizeAxes = Axes.Both, Colour = new Color4(55, 55, 75, 255) },
                }));

            // ════ 精灵/文本 Sprites ═══════════════════════════════════════════
            flow.Add(buildCat("精灵/文本 (Sprites & Text)"));

            flow.Add(buildRow("GlowingSpriteText",
                () => new GlowingSpriteText
                {
                    Text = "GlowingSpriteText 发光文字",
                    GlowColour = Color4.Cyan,
                    Font = OsuFont.GetFont(size: 18),
                }));

            flow.Add(buildRow("LogoAnimation",
                () => new LogoAnimation { Size = new Vector2(80, 80), AnimationProgress = 0.5f }));

            flow.Add(buildRow("OsuSpriteText",
                () => new OsuSpriteText
                {
                    Text = "OsuSpriteText 示例文字 Sample Text",
                    Font = OsuFont.GetFont(size: 18),
                }));

            flow.Add(buildRow("SpriteIconWithTooltip",
                () => new SpriteIconWithTooltip
                {
                    Icon = FontAwesome.Solid.Music,
                    Size = new Vector2(32),
                    TooltipText = "音乐图标提示 Music Icon Tooltip",
                }));

            flow.Add(buildRow("TruncatingSpriteText",
                () => new TruncatingSpriteText
                {
                    Text = "TruncatingSpriteText — 超出宽度后会被截断显示 truncated when overflows",
                    Width = 320,
                    Font = OsuFont.GetFont(size: 16),
                }));

            // ════ 按钮 Buttons ═════════════════════════════════════════════════
            flow.Add(buildCat("按钮 (Buttons)"));

            flow.Add(buildRow("RoundedButton",
                () => new RoundedButton { Text = "RoundedButton", Size = new Vector2(200, 40) }));

            flow.Add(buildRow("DangerousRoundedButton",
                () => new DangerousRoundedButton { Text = "DangerousButton", Size = new Vector2(200, 40) }));

            flow.Add(buildRow("ShearedButton",
                () => new ShearedButton { Text = "ShearedButton", Width = 200 }));

            flow.Add(buildRow("ShearedToggleButton",
                () => new ShearedToggleButton { Text = "ShearedToggle", Width = 200 }));

            flow.Add(buildRow("DialogButton",
                () => new DialogButton
                {
                    RelativeSizeAxes = Axes.X,
                    Height = 50,
                    Text = "DialogButton 对话框按钮",
                    ButtonColour = new Color4(80, 110, 220, 255),
                }, 60));

            flow.Add(buildRow("TwoLayerButton",
                () => new TwoLayerButton
                {
                    Text = "TwoLayer",
                    Icon = OsuIcon.LeftCircle,
                    BackgroundColour = new Color4(55, 100, 180, 255),
                    HoverColour = new Color4(75, 130, 220, 255),
                }));

            flow.Add(buildRow("BackButton",
                () => new BackButton { State = { Value = Visibility.Visible } }));

            flow.Add(buildRow("ShowMoreButton",
                () => new ShowMoreButton { RelativeSizeAxes = Axes.X, Height = 40 }));

            flow.Add(buildRow("DownloadButton",
                () => new DownloadButton { Size = new Vector2(40, 40) }));

            flow.Add(buildRow("GrayButton (Heart icon)",
                () => new GrayButton(FontAwesome.Solid.Heart) { Size = new Vector2(40, 40) }));

            flow.Add(buildRow("ExternalLinkButton",
                () => new ExternalLinkButton("https://osu.ppy.sh") { Size = new Vector2(16, 16) }));

            flow.Add(buildRow("IconButton",
                () => new IconButton { Icon = FontAwesome.Solid.Search, Size = new Vector2(40, 40) }));

            // ════ 文本输入 Text Input ══════════════════════════════════════════
            flow.Add(buildCat("文本输入 (Text Input)"));

            flow.Add(buildRow("OsuTextBox",
                () => new OsuTextBox
                {
                    PlaceholderText = "普通文本框 OsuTextBox...",
                    RelativeSizeAxes = Axes.X,
                    Height = 40,
                }));

            flow.Add(buildRow("OsuPasswordTextBox",
                () => new OsuPasswordTextBox
                {
                    PlaceholderText = "密码框 PasswordTextBox...",
                    RelativeSizeAxes = Axes.X,
                    Height = 40,
                }));

            flow.Add(buildRow("OsuNumberBox",
                () => new OsuNumberBox
                {
                    PlaceholderText = "数字框 NumberBox...",
                    RelativeSizeAxes = Axes.X,
                    Height = 40,
                }));

            flow.Add(buildRow("SearchTextBox",
                () => new SearchTextBox
                {
                    PlaceholderText = "搜索框 SearchTextBox...",
                    RelativeSizeAxes = Axes.X,
                    Height = 40,
                }));

            flow.Add(buildRow("BasicSearchTextBox",
                () => new BasicSearchTextBox
                {
                    PlaceholderText = "基础搜索 BasicSearch...",
                    RelativeSizeAxes = Axes.X,
                    Height = 40,
                }));

            flow.Add(buildRow("SeekLimitedSearchTextBox",
                () => new SeekLimitedSearchTextBox
                {
                    PlaceholderText = "限速搜索 SeekLimited...",
                    RelativeSizeAxes = Axes.X,
                    Height = 40,
                }));

            flow.Add(buildRow("ShearedSearchTextBox",
                () => new ShearedSearchTextBox
                {
                    PlaceholderText = "斜切搜索 ShearedSearch...",
                    RelativeSizeAxes = Axes.X,
                    Height = 40,
                }));

            flow.Add(buildRow("ShearedFilterTextBox",
                () => new ShearedFilterTextBox
                {
                    PlaceholderText = "斜切筛选 ShearedFilter...",
                    RelativeSizeAxes = Axes.X,
                    Height = 40,
                }));

            flow.Add(buildRow("FocusedTextBox",
                () => new FocusedTextBox
                {
                    PlaceholderText = "聚焦输入框 FocusedTextBox...",
                    RelativeSizeAxes = Axes.X,
                    Height = 40,
                }));

            flow.Add(buildRow("HistoryTextBox",
                () => new HistoryTextBox
                {
                    PlaceholderText = "历史输入框 HistoryTextBox...",
                    RelativeSizeAxes = Axes.X,
                    Height = 40,
                }));

            // ════ 滑条 Sliders ══════════════════════════════════════════════════
            flow.Add(buildCat("滑条 (Sliders)"));

            flow.Add(buildRow("RoundedSliderBar<double>",
                () => new RoundedSliderBar<double>
                {
                    RelativeSizeAxes = Axes.X,
                    Height = 20,
                    Current = new BindableDouble(0.5) { MinValue = 0, MaxValue = 1 },
                }));

            flow.Add(buildRow("ShearedSliderBar<double>",
                () => new ShearedSliderBar<double>
                {
                    RelativeSizeAxes = Axes.X,
                    Height = ShearedNub.HEIGHT,
                    Current = new BindableDouble(0.5) { MinValue = 0, MaxValue = 1 },
                }));

            flow.Add(buildRow("RangeSlider",
                () => new RangeSlider
                {
                    RelativeSizeAxes = Axes.X,
                    Height = 44,
                    Label = "范围",
                    LowerBound = new BindableDouble(0.2) { MinValue = 0, MaxValue = 1 },
                    UpperBound = new BindableDouble(0.8) { MinValue = 0, MaxValue = 1 },
                }, 55));

            flow.Add(buildRow("ShearedRangeSlider",
                () => new ShearedRangeSlider("范围滑条")
                {
                    RelativeSizeAxes = Axes.X,
                    LowerBound = new BindableDouble(0.25) { MinValue = 0, MaxValue = 1 },
                    UpperBound = new BindableDouble(0.75) { MinValue = 0, MaxValue = 1 },
                }));

            flow.Add(buildRow("ExpandableSlider<double>",
                () => new ExpandableSlider<double>
                {
                    RelativeSizeAxes = Axes.X,
                    ContractedLabelText = "速度",
                    ExpandedLabelText = "播放速度 Speed",
                    Current = new BindableDouble(0.5) { MinValue = 0, MaxValue = 2 },
                }, 55));

            flow.Add(buildRow("ExpandableSlider<double, FormSliderBar<double>>",
                () => new ExpandableSlider<double, FormSliderBar<double>>
                {
                    RelativeSizeAxes = Axes.X,
                    ContractedLabelText = "音量",
                    ExpandedLabelText = "音量 Volume",
                    Current = new BindableDouble(0.7) { MinValue = 0, MaxValue = 1 },
                }, 55));

            flow.Add(buildRow("TimeSlider",
                () => new TimeSlider
                {
                    RelativeSizeAxes = Axes.X,
                    Height = 20,
                    Current = new BindableDouble(800) { MinValue = 0, MaxValue = 3000 },
                }));

            // ════ 复选框/开关 Checkboxes/Switches ═══════════════════════════════
            flow.Add(buildCat("复选框/开关 (Checkboxes & Switches)"));

            flow.Add(buildRow("OsuCheckbox",
                () => new OsuCheckbox
                {
                    LabelText = "OsuCheckbox 复选框示例",
                    RelativeSizeAxes = Axes.X,
                }));

            flow.Add(buildRow("OsuTabControlCheckbox",
                () => new OsuTabControlCheckbox { Text = "TabControl 复选框" }));

            flow.Add(buildRow("SwitchButton (V2)",
                () => new SwitchButton()));

            flow.Add(buildRow("LabelledSwitchButton (V2)",
                () => new LabelledSwitchButton
                {
                    RelativeSizeAxes = Axes.X,
                    Label = "带标签开关",
                    Description = "A switch button with label and description text",
                }, 90));

            // ════ 下拉菜单 Dropdowns ════════════════════════════════════════════
            flow.Add(buildCat("下拉菜单 (Dropdowns)"));

            flow.Add(buildRow("OsuDropdown<string>",
                () =>
                {
                    var d = new OsuDropdown<string> { RelativeSizeAxes = Axes.X };
                    d.Items = new[] { "选项一 Option 1", "选项二 Option 2", "选项三 Option 3", "选项四 Option 4" };
                    return d;
                }, 55));

            flow.Add(buildRow("OsuEnumDropdown<DemoOption>",
                () => new OsuEnumDropdown<DemoOption> { RelativeSizeAxes = Axes.X }, 55));

            flow.Add(buildRow("SlimEnumDropdown<DemoOption>",
                () => new SlimEnumDropdown<DemoOption> { Width = 240 }));

            flow.Add(buildRow("OsuTabDropdown<string>",
                () =>
                {
                    var d = new OsuTabDropdown<string> { RelativeSizeAxes = Axes.X };
                    d.Items = new[] { "标签一", "标签二", "标签三", "标签四", "标签五" };
                    return d;
                }, 55));

            // ════ 标签/分页 Tabs/Pagination ═══════════════════════════════════
            flow.Add(buildCat("标签/分页 (Tabs & Pagination)"));

            flow.Add(buildRow("OsuTabControl<string>",
                () =>
                {
                    var tc = new OsuTabControl<string> { RelativeSizeAxes = Axes.X, Height = 32 };
                    tc.AddItem("全部");
                    tc.AddItem("最新");
                    tc.AddItem("热门");
                    tc.AddItem("排名");
                    return tc;
                }));

            flow.Add(buildRow("PageTabControl<string>",
                () =>
                {
                    var tc = new PageTabControl<string> { RelativeSizeAxes = Axes.X, Height = 32 };
                    tc.AddItem("页面A");
                    tc.AddItem("页面B");
                    tc.AddItem("页面C");
                    return tc;
                }));

            flow.Add(buildRow("BreadcrumbControl<string>",
                () =>
                {
                    var bc = new BreadcrumbControl<string> { RelativeSizeAxes = Axes.X, Height = 32 };
                    bc.AddItem("首页");
                    bc.AddItem("分类");
                    bc.AddItem("当前页");
                    return bc;
                }));

            flow.Add(buildRow("PageSelector",
                () => new PageSelector
                {
                    AvailablePages = { Value = 10 },
                    CurrentPage = { Value = 3 },
                }));

            // ════ 图表 Graphs/Charts ════════════════════════════════════════════
            flow.Add(buildCat("图表 (Graphs & Charts)"));

            flow.Add(buildRow("BarGraph",
                () => new BarGraph
                {
                    RelativeSizeAxes = Axes.X,
                    Height = 60,
                    Values = new float[] { 0.3f, 0.8f, 0.5f, 1.0f, 0.6f, 0.4f, 0.9f, 0.2f, 0.7f, 0.55f },
                    Colour = Color4.CornflowerBlue,
                }, 70));

            flow.Add(buildRow("LineGraph",
                () =>
                {
                    var lg = new LineGraph { RelativeSizeAxes = Axes.X, Height = 60, LineColour = Color4.LimeGreen };
                    lg.Values = new float[] { 0.5f, 0.7f, 0.3f, 0.9f, 0.6f, 0.8f, 0.4f, 1.0f, 0.2f };
                    return lg;
                }, 70));

            flow.Add(buildRow("SegmentedGraph<float>",
                () =>
                {
                    var sg = new SegmentedGraph<float>(3)
                    {
                        RelativeSizeAxes = Axes.X,
                        Height = 30,
                        TierColours = new List<Colour4>
                        {
                            Colour4.FromHex("1155CC"),
                            Colour4.FromHex("22AA55"),
                            Colour4.FromHex("FF6633"),
                        },
                    };
                    sg.Values = new float[] { 0f, 0.2f, 0.5f, 0.8f, 1f, 0.7f, 0.35f, 0.9f, 0.45f };
                    return sg;
                }));

            flow.Add(buildRow("StarCounter",
                () => new StarCounter(10) { Current = 7.5f }));

            flow.Add(buildRow("ProgressBar",
                () => new ProgressBar(false)
                {
                    RelativeSizeAxes = Axes.X,
                    Height = 10,
                    EndTime = 100,
                    CurrentTime = 65,
                    FillColour = Color4.DeepSkyBlue,
                    BackgroundColour = new Color4(40, 40, 60, 255),
                }));

            // ════ 加载指示 Loading ══════════════════════════════════════════════
            flow.Add(buildCat("加载指示 (Loading Indicators)"));

            flow.Add(buildRow("LoadingSpinner",
                () =>
                {
                    var s = new LoadingSpinner { Size = new Vector2(44, 44) };
                    s.Show();
                    return s;
                }));

            flow.Add(buildRow("LoadingLayer (fullscreen spinner)",
                () =>
                {
                    var s = new LoadingSpinner(true) { Size = new Vector2(60, 60) };
                    s.Show();
                    return s;
                }));

            // ════ 指示栏 Bars/Indicators ════════════════════════════════════════
            flow.Add(buildCat("指示栏 (Bars & Indicators)"));

            flow.Add(buildRow("Bar",
                () => new Bar
                {
                    RelativeSizeAxes = Axes.X,
                    Height = 14,
                    Length = 0.72f,
                    Direction = BarDirection.LeftToRight,
                    AccentColour = Color4.Orange,
                }));

            flow.Add(buildRow("ExpandingBar",
                () => new ExpandingBar { RelativeSizeAxes = Axes.X, Colour = Color4.HotPink }));

            flow.Add(buildRow("Nub",
                () => new Nub { Width = Nub.DEFAULT_EXPANDED_SIZE, Height = Nub.HEIGHT }));

            flow.Add(buildRow("ShearedNub",
                () => new ShearedNub { Width = ShearedNub.HEIGHT, Height = ShearedNub.HEIGHT }));

            // ════ 叠加层/杂项 Overlay/Misc ════════════════════════════════════
            flow.Add(buildCat("叠加层组件 (Overlay & Misc Components)"));

            flow.Add(buildRow("SectionHeader",
                () => new SectionHeader("区块标题 Section Header") { RelativeSizeAxes = Axes.X }));

            flow.Add(buildRow("ShearedOverlayHeader",
                () => new ShearedOverlayHeader
                {
                    Title = "示例叠加层标题 Overlay Title",
                    Description = "Description text for the sheared overlay header component",
                }, 120));

            flow.Add(buildRow("OsuMenuSamples",
                () => new OsuMenuSamples { Width = 120, Height = 24 }));

            flow.Add(buildRow("FPSCounterTooltip",
                () => new FPSCounterTooltip()));

            // 需要游戏特定服务，显示提示
            flow.Add(buildRow("FPSCounter  ⚠",
                () => buildServiceNote("FPSCounter", "需要 OsuConfigManager（osu! 游戏服务）")));

            flow.Add(buildRow("HotkeyDisplay  ⚠",
                () => buildServiceNote("HotkeyDisplay", "需要 RealmKeyBindingStore（osu! 游戏服务）")));

            // ════ V2 表单控件 Form Controls ═══════════════════════════════════
            flow.Add(buildCat("V2 表单控件 (Form Controls V2)"));

            flow.Add(buildRow("FormTextBox",
                () => new FormTextBox
                {
                    RelativeSizeAxes = Axes.X,
                    Caption = "文本输入 Text Input",
                }));

            flow.Add(buildRow("FormCheckBox",
                () => new FormCheckBox
                {
                    RelativeSizeAxes = Axes.X,
                    Caption = "复选框 CheckBox",
                }));

            flow.Add(buildRow("FormButton",
                () => new FormButton
                {
                    Caption = "操作描述 Action Description",
                    ButtonText = "执行 Execute",
                }));

            flow.Add(buildRow("FormFieldCaption",
                () => new FormFieldCaption
                {
                    Caption = "字段标题 Field Caption",
                    TooltipText = "悬停提示 Hover Tooltip",
                }));

            flow.Add(buildRow("FormControlBackground",
                () => new FormControlBackground { RelativeSizeAxes = Axes.X, Height = 44 }));

            flow.Add(buildRow("FormSliderBar<double>",
                () => new FormSliderBar<double>
                {
                    RelativeSizeAxes = Axes.X,
                    Caption = "数值滑条 Slider",
                    Current = new BindableDouble(0.5) { MinValue = 0, MaxValue = 1 },
                }));

            flow.Add(buildRow("FormDropdown<string>",
                () =>
                {
                    var fd = new FormDropdown<string>
                    {
                        RelativeSizeAxes = Axes.X,
                        Caption = "下拉选择 Dropdown",
                    };
                    fd.Items = new[] { "选项A", "选项B", "选项C" };
                    return fd;
                }, 55));

            flow.Add(buildRow("FormEnumDropdown<DemoOption>",
                () => new FormEnumDropdown<DemoOption>
                {
                    RelativeSizeAxes = Axes.X,
                    Caption = "枚举下拉 Enum Dropdown",
                }, 55));

            // ════ V2 带标签控件 Labelled Controls ═════════════════════════════
            flow.Add(buildCat("V2 带标签控件 (Labelled Controls V2)"));

            flow.Add(buildRow("LabelledTextBox",
                () => new LabelledTextBox
                {
                    RelativeSizeAxes = Axes.X,
                    Label = "文本标签 Label",
                    PlaceholderText = "请在此输入内容...",
                }, 90));

            flow.Add(buildRow("LabelledNumberBox",
                () => new LabelledNumberBox
                {
                    RelativeSizeAxes = Axes.X,
                    Label = "数字标签 Number Label",
                    PlaceholderText = "0",
                }, 90));

            flow.Add(buildRow("LabelledSliderBar<double>",
                () => new LabelledSliderBar<double>
                {
                    RelativeSizeAxes = Axes.X,
                    Label = "滑条标签 Slider Label",
                    Description = "A labelled slider bar component",
                    Current = new BindableDouble(0.5) { MinValue = 0, MaxValue = 1 },
                }, 110));

            flow.Add(buildRow("LabelledSwitchButton",
                () => new LabelledSwitchButton
                {
                    RelativeSizeAxes = Axes.X,
                    Label = "开关标签 Switch Label",
                    Description = "A switch with label and description",
                }, 90));

            flow.Add(buildRow("LabelledEnumDropdown<DemoOption>",
                () => new LabelledEnumDropdown<DemoOption>(false)
                {
                    RelativeSizeAxes = Axes.X,
                    Label = "枚举下拉标签 Enum Dropdown Label",
                }, 90));

            // ════ V2 颜色控件 Colour Controls ═════════════════════════════════
            flow.Add(buildCat("V2 颜色控件 (Colour Controls V2)"));

            flow.Add(buildRow("ColourDisplay",
                () =>
                {
                    var d = new ColourDisplay { Size = new Vector2(80, 44) };
                    d.Current.Value = Colour4.FromHex("4489FF");
                    return d;
                }));

            flow.Add(buildRow("ColourPalette",
                () =>
                {
                    var cp = new ColourPalette { RelativeSizeAxes = Axes.X };
                    cp.Colours.AddRange(new[] { Colour4.Red, Colour4.Orange, Colour4.Yellow, Colour4.Lime, Colour4.Blue, Colour4.Violet });
                    return cp;
                }, 90));

            flow.Add(buildRow("LabelledColourPalette",
                () =>
                {
                    var lcp = new LabelledColourPalette
                    {
                        RelativeSizeAxes = Axes.X,
                        Label = "调色板标签 Colour Palette Label",
                    };
                    lcp.Colours.AddRange(new[] { Colour4.Red, Colour4.Green, Colour4.Blue, Colour4.Yellow });
                    return lcp;
                }, 110));

            flow.Add(buildRow("FormColourPalette",
                () =>
                {
                    var fcp = new FormColourPalette
                    {
                        RelativeSizeAxes = Axes.X,
                        Caption = "表单调色板 Form Colour Palette",
                    };
                    fcp.Colours.AddRange(new[] { Colour4.Red, Colour4.Green, Colour4.Blue });
                    return fcp;
                }, 90));

            flow.Add(buildRow("OsuColourPicker",
                () => new OsuColourPicker { Size = new Vector2(320, 210) }, 230));

            flow.Add(buildRow("OsuHSVColourPicker",
                () => new OsuHSVColourPicker { Size = new Vector2(320, 210) }, 230));

            flow.Add(buildRow("OsuHexColourPicker",
                () => new OsuHexColourPicker { Size = new Vector2(320, 44) }));

            // ════ Markdown 渲染 ════════════════════════════════════════════════
            flow.Add(buildCat("Markdown 渲染 (Markdown Rendering)"));

            flow.Add(buildRow("OsuMarkdownContainer (rich demo)",
                () =>
                {
                    var mc = new OsuMarkdownContainer { RelativeSizeAxes = Axes.X, AutoSizeAxes = Axes.Y };
                    mc.Text = "# 一级标题\n## 二级标题\n**粗体** *斜体* ~~删除线~~\n\n- 列表项 1\n- 列表项 2\n- 列表项 3";
                    return mc;
                }, 200));

            flow.Add(buildRow("OsuMarkdownSeparator (hr line)",
                () => new OsuMarkdownSeparator { RelativeSizeAxes = Axes.X, Height = 2 }));

            // ── 底部间距 ──
            flow.Add(new Box { RelativeSizeAxes = Axes.X, Height = 20, Alpha = 0 });

            return flow;
        }

        // ── 辅助构建方法 ─────────────────────────────────────────────────────

        /// <summary>构建列头行（"控件名称" | "控件预览"）。</summary>
        private Drawable buildColumnHeader()
        {
            return new GridContainer
            {
                RelativeSizeAxes = Axes.X,
                Height = 28,
                ColumnDimensions = new[]
                {
                    new Dimension(GridSizeMode.Absolute, NAME_COL),
                    new Dimension(GridSizeMode.Absolute, SEP),
                    new Dimension(),
                },
                Content = new[]
                {
                    new Drawable[]
                    {
                        makeHeaderCell("控件名称 (Control Name)"),
                        new Box { RelativeSizeAxes = Axes.Both, Colour = SEP_COL },
                        makeHeaderCell("控件预览 (Control Preview)"),
                    },
                },
            };
        }

        private Container makeHeaderCell(string text) =>
            new Container
            {
                RelativeSizeAxes = Axes.Both,
                Padding = new MarginPadding { Horizontal = PAD },
                Child = new SpriteText
                {
                    Text = text,
                    Colour = HDR_FG,
                    Font = FontUsage.Default.With(size: 13, weight: "Bold"),
                    Anchor = Anchor.CentreLeft,
                    Origin = Anchor.CentreLeft,
                },
            };

        /// <summary>构建分类标题行。</summary>
        private Drawable buildCat(string label)
        {
            return new Container
            {
                RelativeSizeAxes = Axes.X,
                Height = 32,
                Margin = new MarginPadding { Top = 8 },
                Children = new Drawable[]
                {
                    new Box { RelativeSizeAxes = Axes.Both, Colour = CAT_BG },
                    new OsuSpriteText
                    {
                        Text = label,
                        Font = OsuFont.GetFont(size: 14, weight: FontWeight.SemiBold),
                        Colour = CAT_FG,
                        Anchor = Anchor.CentreLeft,
                        Origin = Anchor.CentreLeft,
                        Margin = new MarginPadding { Left = PAD },
                    },
                },
            };
        }

        /// <summary>
        /// 构建一个两列展示行：左列显示控件名，右列显示控件预览。
        /// </summary>
        /// <param name="name">控件名称（显示在左列）</param>
        /// <param name="factory">控件工厂函数</param>
        /// <param name="height">行高（默认 70px）</param>
        private Drawable buildRow(string name, Func<Drawable> factory, float height = ROW_H)
        {
            Drawable control;
            try
            {
                control = factory();
            }
            catch (Exception ex)
            {
                control = new SpriteText
                {
                    Text = $"[构建失败 Build failed: {ex.GetType().Name}: {ex.Message}]",
                    Colour = Color4.OrangeRed,
                    Font = FontUsage.Default.With(size: 12),
                };
            }

            return new GridContainer
            {
                RelativeSizeAxes = Axes.X,
                Height = height,
                Margin = new MarginPadding { Bottom = 2 },
                ColumnDimensions = new[]
                {
                    new Dimension(GridSizeMode.Absolute, NAME_COL),
                    new Dimension(GridSizeMode.Absolute, SEP),
                    new Dimension(),
                },
                Content = new[]
                {
                    new Drawable[]
                    {
                        // ── 左列：名称 ─────────────────────────────────────
                        new Container
                        {
                            RelativeSizeAxes = Axes.Both,
                            Masking = true,
                            Children = new Drawable[]
                            {
                                new Box { RelativeSizeAxes = Axes.Both, Colour = NAME_BG },
                                new SpriteText
                                {
                                    Text = name,
                                    RelativeSizeAxes = Axes.X,
                                    Width = 0.93f,
                                    Colour = NAME_FG,
                                    Font = FontUsage.Default.With(size: 13),
                                    Anchor = Anchor.CentreLeft,
                                    Origin = Anchor.CentreLeft,
                                    Truncate = true,
                                    Margin = new MarginPadding { Left = PAD },
                                },
                            },
                        },
                        // ── 分隔线 ─────────────────────────────────────────
                        new Box { RelativeSizeAxes = Axes.Both, Colour = SEP_COL },
                        // ── 右列：控件预览 ──────────────────────────────────
                        new Container
                        {
                            RelativeSizeAxes = Axes.Both,
                            Padding = new MarginPadding { Horizontal = PAD, Vertical = 6 },
                            Child = new Container
                            {
                                RelativeSizeAxes = Axes.X,
                                AutoSizeAxes = Axes.Y,
                                Anchor = Anchor.CentreLeft,
                                Origin = Anchor.CentreLeft,
                                Child = control,
                            },
                        },
                    },
                },
            };
        }

        /// <summary>为需要额外游戏服务的控件构建占位提示。</summary>
        private static Drawable buildServiceNote(string controlName, string note)
        {
            return new FillFlowContainer
            {
                AutoSizeAxes = Axes.Both,
                Direction = FillDirection.Horizontal,
                Spacing = new Vector2(8),
                Children = new Drawable[]
                {
                    new SpriteIcon
                    {
                        Icon = FontAwesome.Solid.ExclamationTriangle,
                        Size = new Vector2(16),
                        Colour = new Color4(255, 220, 50, 255),
                        Anchor = Anchor.CentreLeft,
                        Origin = Anchor.CentreLeft,
                    },
                    new SpriteText
                    {
                        Text = $"{controlName} — {note}",
                        Colour = new Color4(210, 210, 130, 255),
                        Font = FontUsage.Default.With(size: 13),
                        Anchor = Anchor.CentreLeft,
                        Origin = Anchor.CentreLeft,
                    },
                },
            };
        }
    }
}
