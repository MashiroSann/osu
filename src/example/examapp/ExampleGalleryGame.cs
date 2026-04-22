using System.Drawing;
using System.Reflection;
using System.Text.RegularExpressions;
using osu.Framework.Allocation;
using osu.Framework.Configuration;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Platform;
using OsuUiKit;
using OsuUiKit.Sprites;
using osuTK;
using osuTK.Graphics;

namespace OsuUiKit.ExamApp;

public partial class ExampleGalleryGame : osu.Framework.Game
{
    private const float left_column_width = 420;

    protected override IDictionary<FrameworkSetting, object> GetFrameworkConfigDefaults() => new Dictionary<FrameworkSetting, object>
    {
        [FrameworkSetting.WindowMode] = WindowMode.Windowed,
        [FrameworkSetting.WindowedSize] = new Size(1280, 720),
    };

    [BackgroundDependencyLoader]
    private void load()
    {
        AddInternal(new Box
        {
            RelativeSizeAxes = Axes.Both,
            Colour = new Color4(24, 26, 27, 255),
        });

        var items = loadExampleTypes();

        var rows = new Drawable[items.Count + 1];

        rows[0] = createHeaderRow();

        for (int i = 0; i < items.Count; i++)
            rows[i + 1] = createRow(items[i]);

        AddInternal(new BasicScrollContainer
        {
            RelativeSizeAxes = Axes.Both,
            Padding = new MarginPadding(20),
            Child = new FillFlowContainer
            {
                RelativeSizeAxes = Axes.X,
                AutoSizeAxes = Axes.Y,
                Direction = FillDirection.Vertical,
                Spacing = new Vector2(0, 8),
                Children = rows,
            },
        });
    }

    private Drawable createHeaderRow() => new GridContainer
    {
        RelativeSizeAxes = Axes.X,
        AutoSizeAxes = Axes.Y,
        ColumnDimensions =
        [
            new Dimension(GridSizeMode.Absolute, left_column_width),
            new Dimension(),
        ],
        Content = new[]
        {
            new Drawable[]
            {
                createCellBackground(new OsuSpriteText
                {
                    Text = "控件名",
                    Font = OsuFont.GetFont(size: 22, weight: FontWeight.Bold),
                    Colour = Color4.White,
                    Margin = new MarginPadding(10),
                }, new Color4(48, 51, 54, 255)),
                createCellBackground(new OsuSpriteText
                {
                    Text = "控件预览",
                    Font = OsuFont.GetFont(size: 22, weight: FontWeight.Bold),
                    Colour = Color4.White,
                    Margin = new MarginPadding(10),
                }, new Color4(48, 51, 54, 255)),
            },
        },
    };

    private Drawable createRow((string Name, Type? Type) item)
    {
        Drawable preview = createPreview(item.Type);

        return new GridContainer
        {
            RelativeSizeAxes = Axes.X,
            AutoSizeAxes = Axes.Y,
            ColumnDimensions =
            [
                new Dimension(GridSizeMode.Absolute, left_column_width),
                new Dimension(),
            ],
            Content = new[]
            {
                new Drawable[]
                {
                    createCellBackground(new OsuSpriteText
                    {
                        Text = item.Name,
                        Font = OsuFont.GetFont(size: 18),
                        Colour = Color4.White,
                        Margin = new MarginPadding(10),
                    }),
                    createCellBackground(new Container
                    {
                        RelativeSizeAxes = Axes.X,
                        AutoSizeAxes = Axes.Y,
                        Padding = new MarginPadding(10),
                        Child = preview,
                    }),
                },
            },
        };
    }

    private static Container createCellBackground(Drawable content, Color4? colour = null) => new()
    {
        RelativeSizeAxes = Axes.X,
        AutoSizeAxes = Axes.Y,
        Masking = true,
        CornerRadius = 6,
        Child = new Container
        {
            RelativeSizeAxes = Axes.Both,
            AutoSizeAxes = Axes.Y,
            Children =
            [
                new Box
                {
                    RelativeSizeAxes = Axes.Both,
                    Colour = colour ?? new Color4(33, 36, 39, 255),
                },
                content,
            ],
        },
    };

    private static Drawable createPreview(Type? controlType)
    {
        if (controlType is null)
            return unavailableLabel("类型未找到");

        try
        {
            object? instance = Activator.CreateInstance(controlType);

            if (instance is Drawable drawable)
                return drawable;

            return unavailableLabel($"已实例化（非Drawable）: {controlType.Name}");
        }
        catch (Exception ex)
        {
            return unavailableLabel($"实例化失败: {ex.GetType().Name}");
        }
    }

    private static OsuSpriteText unavailableLabel(string text) => new()
    {
        Text = text,
        Font = OsuFont.GetFont(size: 16),
        Colour = Color4.OrangeRed,
    };

    private static List<(string Name, Type? Type)> loadExampleTypes()
    {
        string? readmePath = findExampleReadmePath();
        if (readmePath is null)
            return [];

        string markdown = File.ReadAllText(readmePath);
        var matches = Regex.Matches(markdown, "\\|\\s*`([^`]+)`\\s*\\|");

        var names = new HashSet<string>(StringComparer.Ordinal);
        var result = new List<(string Name, Type? Type)>();
        Assembly assembly = typeof(OsuFont).Assembly;

        foreach (Match match in matches)
        {
            string name = match.Groups[1].Value.Trim();
            if (!names.Add(name))
                continue;

            Type? type = assembly.GetType(name, throwOnError: false, ignoreCase: false);
            result.Add((name, type));
        }

        return result;
    }

    private static string? findExampleReadmePath()
    {
        DirectoryInfo? current = new(AppContext.BaseDirectory);

        while (current is not null)
        {
            string candidate = Path.Combine(current.FullName, "src", "example", "README.md");
            if (File.Exists(candidate))
                return candidate;

            current = current.Parent;
        }

        return null;
    }
}
