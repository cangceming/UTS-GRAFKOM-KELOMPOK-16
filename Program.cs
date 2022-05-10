using System;
using OpenTK.Mathematics;
using OpenTK.Windowing.Desktop;

namespace ProjectGrafkom
{
    class Program
    {
        static void Main(string[] args)
        {
            var ourWindow = new NativeWindowSettings()
            {
                Size = new Vector2i(2000, 1000),
                Title = "UTS Grafika Komputer"
            };

            using (var win = new window(GameWindowSettings.Default, ourWindow))
            {
                win.Run();
            };
        }
    }
}
