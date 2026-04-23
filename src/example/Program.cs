using osu.Framework;
using osu.Framework.Platform;

namespace example
{
    internal static class Program
    {
        public static void Main()
        {
            using GameHost host = Host.GetSuitableDesktopHost("example");
            host.Run(new ExampleGame());
        }
    }
}
