using osu.Framework;
using osu.Framework.Platform;

namespace OsuUiKit.ListApp;

internal static class Program
{
    public static void Main()
    {
        using GameHost host = Host.GetSuitableDesktopHost("OsuUiKit.ListApp");
        host.Run(new ListAppGame());
    }
}
