using OsuUiKit;
using OsuUiKit.Containers;
using OsuUiKit.Sprites;
using System.Drawing;
using System.Reflection;
using osu.Framework;
using osu.Framework.Allocation;
using osu.Framework.Configuration;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Platform;
using osuTK;
using osuTK.Graphics;

namespace listapp;

public static class Program
{
    public static void Main()
    {
        using GameHost host = Host.GetSuitableDesktopHost("osu-uikit-listapp");

        FrameworkConfigManager frameworkConfig = host.Dependencies.Get<FrameworkConfigManager>();
        frameworkConfig.SetValue(FrameworkSetting.WindowMode, WindowMode.Windowed);
        frameworkConfig.SetValue(FrameworkSetting.WindowedSize, new Size(1280, 720));

        if (host.Window != null)
            host.Window.Title = "OsuUiKit Controls List";

        host.Run(new ControlsListGame());
    }
}

public partial class ControlsListGame : Game
{
    [BackgroundDependencyLoader]
    private void load()
    {
        FillFlowContainer listFlow = new FillFlowContainer
        {
            RelativeSizeAxes = Axes.X,
            AutoSizeAxes = Axes.Y,
            Direction = FillDirection.Vertical,
            Spacing = new Vector2(0, 8),
            Padding = new MarginPadding(12),
        };

        foreach (var entry in ControlFactory.CreateAll())
            listFlow.Add(new ControlRow(entry));

        AddInternal(new Box
        {
            RelativeSizeAxes = Axes.Both,
            Colour = new Color4(28, 28, 32, 255)
        });

        AddInternal(new OsuScrollContainer
        {
            RelativeSizeAxes = Axes.Both,
            ScrollbarVisible = true,
            Child = listFlow
        });
    }
}

public partial class ControlRow : CompositeDrawable
{
    public ControlRow(ControlEntry entry)
    {
        RelativeSizeAxes = Axes.X;
        Height = 124;

        InternalChild = new GridContainer
        {
            RelativeSizeAxes = Axes.Both,
            ColumnDimensions =
            [
                new Dimension(GridSizeMode.Absolute, 360),
                new Dimension(),
            ],
            Content = new[]
            {
                new Drawable[]
                {
                    createLabelPanel(entry.DisplayName),
                    createPreviewPanel(entry.Drawable),
                }
            }
        };
    }

    private static Drawable createLabelPanel(string displayName)
        => new Container
        {
            RelativeSizeAxes = Axes.Both,
            Masking = true,
            CornerRadius = 8,
            BorderThickness = 1,
            BorderColour = new Color4(70, 70, 84, 255),
            Children =
            [
                new Box
                {
                    RelativeSizeAxes = Axes.Both,
                    Colour = new Color4(40, 40, 50, 255)
                },
                new OsuSpriteText
                {
                    Anchor = Anchor.CentreLeft,
                    Origin = Anchor.CentreLeft,
                    X = 12,
                    Font = OsuFont.GetFont(size: 20, weight: FontWeight.SemiBold),
                    Text = displayName,
                    Colour = Color4.White,
                }
            ]
        };

    private static Drawable createPreviewPanel(Drawable drawable)
        => new Container
        {
            RelativeSizeAxes = Axes.Both,
            Padding = new MarginPadding { Left = 12 },
            Child = new Container
            {
                RelativeSizeAxes = Axes.Both,
                Masking = true,
                CornerRadius = 8,
                BorderThickness = 1,
                BorderColour = new Color4(70, 70, 84, 255),
                Children =
                [
                    new Box
                    {
                        RelativeSizeAxes = Axes.Both,
                        Colour = new Color4(36, 36, 44, 255)
                    },
                    new Container
                    {
                        AutoSizeAxes = Axes.Both,
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                        Child = drawable
                    }
                ]
            }
        };
}

public readonly record struct ControlEntry(string DisplayName, Drawable Drawable);

public static class ControlFactory
{
    private static readonly Type[] genericTypeFallbacks =
    [
        typeof(int),
        typeof(string),
        typeof(float),
        typeof(double),
        typeof(bool),
    ];

    public static IReadOnlyList<ControlEntry> CreateAll()
    {
        var result = new List<ControlEntry>();
        var assembly = typeof(OsuColour).Assembly;

        var controlTypes = assembly.GetExportedTypes()
                                   .Where(t => typeof(Drawable).IsAssignableFrom(t) && !t.IsAbstract)
                                   .OrderBy(getDisplayName)
                                   .ToArray();

        foreach (Type type in controlTypes)
        {
            Type? concreteType = closeGenericType(type);
            if (concreteType == null)
                continue;

            ConstructorInfo? ctor = concreteType.GetConstructor(Type.EmptyTypes);
            if (ctor == null)
                continue;

            Drawable drawable;

            try
            {
                drawable = (Drawable?)Activator.CreateInstance(concreteType)
                           ?? throw new InvalidOperationException("创建实例返回 null");
            }
            catch (Exception ex)
            {
                drawable = new OsuSpriteText
                {
                    Font = OsuFont.GetFont(size: 18, weight: FontWeight.SemiBold),
                    Colour = Color4.OrangeRed,
                    Text = $"创建失败: {ex.GetBaseException().Message}",
                };
            }

            result.Add(new ControlEntry(getDisplayName(type), drawable));
        }

        return result;
    }

    private static string getDisplayName(Type type)
    {
        string name = trimArity(type.Name);

        if (type.IsNested && type.DeclaringType != null)
            return $"{getDisplayName(type.DeclaringType)}.{name}";

        if (!type.IsGenericType)
            return name;

        string[] genericArguments = type.GetGenericArguments()
                                        .Select(t => t.Name)
                                        .Distinct()
                                        .ToArray();

        if (genericArguments.Length == 0)
            return name;

        return $"{name}<{string.Join(", ", genericArguments)}>";
    }

    private static Type? closeGenericType(Type type)
    {
        if (!type.ContainsGenericParameters)
            return type;

        Type genericTypeDefinition;

        try
        {
            genericTypeDefinition = type.IsGenericTypeDefinition ? type : type.GetGenericTypeDefinition();
        }
        catch
        {
            return null;
        }

        Type[] genericArguments = genericTypeDefinition.GetGenericArguments();
        Type[] replacements = new Type[genericArguments.Length];

        for (int i = 0; i < replacements.Length; i++)
            replacements[i] = genericTypeFallbacks[i % genericTypeFallbacks.Length];

        try
        {
            Type concreteType = genericTypeDefinition.MakeGenericType(replacements);
            return concreteType.ContainsGenericParameters ? null : concreteType;
        }
        catch
        {
            return null;
        }
    }

    private static string trimArity(string name)
    {
        int index = name.IndexOf('`');
        return index >= 0 ? name[..index] : name;
    }
}
