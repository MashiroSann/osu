using osu.Framework;
using osu.Framework.Platform;

namespace OsuUiKit.ExamApp;

internal static class Program
{
    public static void Main()
    {
        using GameHost host = Host.GetSuitableDesktopHost("OsuUiKit.ExamApp");
        host.Run(new ExampleGalleryGame());
    }
}
