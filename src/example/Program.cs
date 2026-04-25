// OsuUiKit 控件展示程序入口 (OsuUiKit Control Gallery Entry Point)
using osu.Framework;
using osu.Framework.Platform;

namespace OsuUiKitDemo;

public static class Program
{
    [System.STAThread]
    public static void Main()
    {
        using GameHost host = Host.GetSuitableDesktopHost("OsuUiKitDemo");
        using var game = new OsuUiKitDemoGame();
        host.Run(game);
    }
}
