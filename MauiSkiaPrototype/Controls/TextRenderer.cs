using SkiaSharp;
using SkiaSharp.Views.Maui;
using SkiaSharp.Views.Maui.Controls;
using Microsoft.Maui.Graphics.Skia;
using System.Reflection;

namespace MauiSkiaPrototype.Controls
{
    public partial class TextRenderer : SKCanvasView
    {

        public bool ShouldUpdateText { get; private set; }
        public float LastWidth { get; private set; } = 0;
        public int Cols { get; private set; } = 0;
        public int Rows { get; private set; } = 0;

        private string _text;
        private double _fontSize;

        private string _fontFamily;

        public string Text { get { return _text; } set { SetText(value); } }
        public double FontSize { get { return _fontSize; } set { SetFontSize(value); } }
        public string FontFamily { get { return _fontFamily; } set { SetFontFamily(value); } }

        public TextRenderer(): base()
        {
            //Drawable = new TextRendererDrawable(this);
        }

        private void SetFontFamily(string value)
        {
            _fontFamily = value;
            SetUpdateText();
        }

        private void SetFontSize(double value)
        {
            _fontSize = value;
            SetUpdateText();
        }

        private void SetText(string value)
        {
            _text = value;
            SetUpdateText();
        }

        private void SetUpdateText()
        {
            ShouldUpdateText = true;
            InvalidateSurface();
        }

        public void UpdateText()
        {
            //HeightRequest
            Cols = (int)Math.Floor(Width / FontSize);
            Rows = (int)Math.Ceiling(Text.Length / (double)Cols);
            HeightRequest = FontSize * Rows;
            ShouldUpdateText = false;
        }
        private SKCanvas _canvas;

        protected override void OnPaintSurface(SKPaintSurfaceEventArgs e)
        {
            if (ShouldUpdateText || Width != LastWidth)
            {
                UpdateText();
            }
            base.OnPaintSurface(e);
            _canvas = e.Surface.Canvas;
            _canvas.Clear();
            //_canvas.DrawRect(0, 0, (float)Width, (float)Height, new SKPaint { Color = SKColors.Blue });
            var col = 0;
            var row = 1;

            var fontSize = (float)FontSize;
            /*var font = new Microsoft.Maui.Graphics.Font(FontFamily, 300);*/
            var assembly = Assembly.GetExecutingAssembly();
            using var stream = assembly.GetManifestResourceStream("MauiSkiaPrototype.Resources.Fonts.NotoSansJP-Light.ttf");
            var typeface = SKTypeface.FromStream(stream);
            var paint = new SKPaint(new SKFont() { Typeface = typeface }) { Color = SKColors.Black, TextSize = fontSize };
            foreach (var character in Text)
            {
                _canvas.DrawText(character.ToString(), new SKPoint(col * fontSize, row * fontSize), paint);
                col++;
                if (col % Cols == 0)
                {
                    col = 0;
                    row++;
                }
            }

        }
    }
}
