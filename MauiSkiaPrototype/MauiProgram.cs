using MauiSkiaPrototype.Controls;
using Microsoft.Extensions.Logging;
using SkiaSharp.Views.Maui.Handlers;

namespace MauiSkiaPrototype
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                .ConfigureMauiHandlers(h =>
                {
                    h.AddHandler<TextRenderer, SKCanvasViewHandler>();
                });

#if DEBUG
		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}