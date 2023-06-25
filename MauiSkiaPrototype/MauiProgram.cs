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
                    fonts.AddFont("OpenSans-Regular.ttf", "Open Sans Regular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "Open Sans Semibold");
                    /*fonts.AddFont("Roboto-Light.ttf", "Roboto Light");
                    fonts.AddFont("Roboto-Bold.ttf", "Roboto Bold");*/
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