using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using osu.Framework.Allocation;
using osu.Framework.Configuration;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.UserInterface;
using OsuUiKit;
using OsuUiKit.Sprites;
using OsuUiKit.UserInterface;
using OsuUiKit.UserInterfaceV2;
using osuTK;
using osuTK.Graphics;

namespace example
{
    public partial class ExampleGame : osu.Framework.Game
    {
        private static readonly IReadOnlyList<string> fallbackControls = new[]
        {
            "ShearedButton",
            "ShearedToggleButton",
            "IconButton",
            "DownloadButton",
            "DangerousRoundedButton",
            "RoundedButton",
            "OsuCheckbox",
            "OsuTextBox",
            "OsuPasswordTextBox",
            "SearchTextBox",
            "BasicSearchTextBox",
            "ShearedSearchTextBox",
            "SwitchButton",
            "FormCheckBox",
            "FormTextBox",
            "LabelledTextBox",
            "LabelledSwitchButton",
        };

        [BackgroundDependencyLoader]
        private void load(FrameworkConfigManager frameworkConfig)
        {
            frameworkConfig.GetBindable<WindowMode>(FrameworkSetting.WindowMode).Value = WindowMode.Windowed;
            frameworkConfig.GetBindable<Size>(FrameworkSetting.WindowedSize).Value = new Size(1280, 720);

            Add(new Box
            {
                RelativeSizeAxes = Axes.Both,
                Colour = new Color4(24, 27, 32, 255),
            });

            Add(new BasicScrollContainer
            {
                RelativeSizeAxes = Axes.Both,
                Padding = new MarginPadding(20),
                Child = createContent(),
            });
        }

        private Drawable createContent()
        {
            var names = loadControlNames();

            return new FillFlowContainer
            {
                RelativeSizeAxes = Axes.X,
                AutoSizeAxes = Axes.Y,
                Direction = FillDirection.Vertical,
                Spacing = new Vector2(0, 10),
                Children = names.Select(createRow).ToArray(),
            };
        }

        private Drawable createRow(string controlName)
        {
            return new Container
            {
                RelativeSizeAxes = Axes.X,
                AutoSizeAxes = Axes.Y,
                CornerRadius = 8,
                Masking = true,
                Children = new Drawable[]
                {
                    new Box
                    {
                        RelativeSizeAxes = Axes.Both,
                        Colour = new Color4(33, 37, 44, 255),
                    },
                    new GridContainer
                    {
                        RelativeSizeAxes = Axes.X,
                        AutoSizeAxes = Axes.Y,
                        ColumnDimensions = new[]
                        {
                            new Dimension(GridSizeMode.Absolute, 330),
                            new Dimension(),
                        },
                        Content = new[]
                        {
                            new Drawable[]
                            {
                                new Container
                                {
                                    RelativeSizeAxes = Axes.X,
                                    AutoSizeAxes = Axes.Y,
                                    Padding = new MarginPadding { Vertical = 22, Horizontal = 16 },
                                    Child = new OsuSpriteText
                                    {
                                        Text = controlName,
                                        Font = OsuFont.GetFont(size: 20, weight: FontWeight.Bold),
                                        Colour = Color4.White,
                                    },
                                },
                                new Container
                                {
                                    RelativeSizeAxes = Axes.X,
                                    AutoSizeAxes = Axes.Y,
                                    Padding = new MarginPadding { Vertical = 12, Horizontal = 16 },
                                    Child = createControlPreview(controlName),
                                },
                            },
                        },
                    },
                },
            };
        }

        private Drawable createControlPreview(string controlName)
        {
            switch (controlName)
            {
                case "ShearedButton":
                    return new ShearedButton { Width = 260, Text = controlName };

                case "ShearedToggleButton":
                    return new ShearedToggleButton { Width = 260, Text = controlName, Active = { Value = true } };

                case "IconButton":
                    return new IconButton { Icon = FontAwesome.Solid.Heart };

                case "DownloadButton":
                    return new DownloadButton();

                case "DangerousRoundedButton":
                    return new DangerousRoundedButton { Width = 260, Text = controlName };

                case "RoundedButton":
                    return new RoundedButton { Width = 260, Text = controlName };

                case "OsuCheckbox":
                    return new OsuCheckbox { Width = 360, LabelText = "OsuCheckbox example" };

                case "OsuTextBox":
                    return new OsuTextBox { Width = 360, PlaceholderText = "OsuTextBox" };

                case "OsuPasswordTextBox":
                    return new OsuPasswordTextBox { Width = 360, PlaceholderText = "OsuPasswordTextBox" };

                case "SearchTextBox":
                    return new SearchTextBox { Width = 360, PlaceholderText = "SearchTextBox" };

                case "BasicSearchTextBox":
                    return new BasicSearchTextBox { Width = 360, PlaceholderText = "BasicSearchTextBox" };

                case "ShearedSearchTextBox":
                    return new ShearedSearchTextBox { Width = 360, PlaceholderText = "ShearedSearchTextBox" };

                case "SwitchButton":
                    return new SwitchButton { Current = { Value = true } };

                case "FormCheckBox":
                    return new FormCheckBox { Width = 500, Caption = "FormCheckBox", HintText = "Example switch control" };

                case "FormTextBox":
                    return new FormTextBox { Width = 500, Caption = "FormTextBox", PlaceholderText = "Enter some text" };

                case "LabelledTextBox":
                    return new LabelledTextBox
                    {
                        Width = 500,
                        Label = "LabelledTextBox",
                        PlaceholderText = "Enter content",
                    };

                case "LabelledSwitchButton":
                    return new LabelledSwitchButton
                    {
                        Width = 500,
                        Label = "LabelledSwitchButton",
                        Current = { Value = true },
                    };

                default:
                    return new OsuSpriteText
                    {
                        Text = $"Not implemented: {controlName}",
                        Font = OsuFont.GetFont(size: 16),
                        Colour = new Color4(255, 140, 140, 255),
                    };
            }
        }

        private static IReadOnlyList<string> loadControlNames()
        {
            string? listFile = findListFile();
            if (listFile == null)
                return fallbackControls;

            List<string> controls = File.ReadLines(listFile)
                                        .Select(l => l.Trim())
                                        .Where(l => l.StartsWith("- ", StringComparison.Ordinal))
                                        .Select(l => l[2..].Trim())
                                        .Where(l => !string.IsNullOrWhiteSpace(l))
                                        .ToList();

            return controls.Count == 0 ? fallbackControls : controls;
        }

        private static string? findListFile()
        {
            DirectoryInfo? current = new DirectoryInfo(AppContext.BaseDirectory);

            while (current != null)
            {
                string candidate = Path.Combine(current.FullName, "List.md");
                if (File.Exists(candidate))
                    return candidate;

                current = current.Parent;
            }

            return null;
        }
    }
}
