using System.Drawing;
using OsuUiKit.Example;
using OsuUiKit.Sprites;
using osu.Framework.Allocation;
using osu.Framework.Configuration;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osuTK;
using osuTK.Graphics;

namespace OsuUiKit.ListApp;

public partial class ListAppGame : osu.Framework.Game
{
    [Resolved]
    private FrameworkConfigManager frameworkConfig { get; set; } = null!;

    [BackgroundDependencyLoader]
    private void load()
    {
        frameworkConfig.SetValue(FrameworkSetting.WindowMode, WindowMode.Windowed);
        frameworkConfig.SetValue(FrameworkSetting.WindowedSize, new Size(1280, 720));

        const float leftWidth = 360;

        AddInternal(new Box
        {
            RelativeSizeAxes = Axes.Both,
            Colour = new Color4(22, 24, 30, 255),
        });

        AddInternal(new BasicScrollContainer
        {
            RelativeSizeAxes = Axes.Both,
            Child = new FillFlowContainer
            {
                RelativeSizeAxes = Axes.X,
                AutoSizeAxes = Axes.Y,
                Direction = FillDirection.Vertical,
                Spacing = new Vector2(0, 8),
                Padding = new MarginPadding(12),
                ChildrenEnumerable = ControlExamples.GetAllCallableControlExamples().Select(example =>
                    (Drawable)new Container
                    {
                        RelativeSizeAxes = Axes.X,
                        Height = 70,
                        Masking = true,
                        CornerRadius = 8,
                        Children = new Drawable[]
                        {
                            new Box
                            {
                                RelativeSizeAxes = Axes.Both,
                                Colour = new Color4(35, 38, 45, 255),
                            },
                            new Container
                            {
                                RelativeSizeAxes = Axes.Y,
                                Width = leftWidth,
                                Padding = new MarginPadding(10),
                                Child = new OsuSpriteText
                                {
                                    RelativeSizeAxes = Axes.Both,
                                    Text = example.Name,
                                    Colour = Color4.White,
                                }
                            },
                            new Container
                            {
                                RelativeSizeAxes = Axes.Both,
                                Padding = new MarginPadding { Left = leftWidth + 12, Right = 12, Top = 10, Bottom = 10 },
                                Child = ControlExamples.CreateInstance(example.ControlType) ?? new OsuSpriteText
                                {
                                    Text = $"无法实例化: {example.ControlType.Name}",
                                    Colour = Color4.OrangeRed,
                                }
                            }
                        }
                    })
            }
        });
    }

}
