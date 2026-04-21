// OsuUiKit Demo — Shows extracted osu! UI components in action.
// Run with: dotnet run --project src/OsuUiKit.Demo

using osu.Framework;
using osu.Framework.Platform;

namespace OsuUiKit.Demo
{
    /// <summary>
    /// Entry point for the OsuUiKit interactive component gallery.
    /// Hosts a minimal osu-framework window and renders sample OsuUiKit controls.
    /// </summary>
    internal static class Program
    {
        public static void Main()
        {
            using GameHost host = Host.GetSuitableDesktopHost("OsuUiKit.Demo");
            host.Run(new OsuUiKitDemoGame());
        }
    }
}
