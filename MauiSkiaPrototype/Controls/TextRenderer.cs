using SkiaSharp;
using SkiaSharp.Views.Maui;
using SkiaSharp.Views.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiSkiaPrototype.Controls
{
    public class TextRenderer : SKCanvasView
    {
        private SKCanvas _canvas;

        protected override void OnPaintSurface(SKPaintSurfaceEventArgs e)
        {
            base.OnPaintSurface(e);
            _canvas = e.Surface.Canvas;
            _canvas.Clear();
            _canvas.DrawRect(0, 0, (float)Width, (float)Height, new SKPaint { Color = SKColors.Blue });
        }
    }
}
