using SkiaSharp;
using SkiaSharp.Views.Maui;
using SkiaSharp.Views.Maui.Controls;
using Microsoft.Maui.Graphics.Skia;

namespace MauiSkiaPrototype.Controls
{
    public class TextRenderer : SKCanvasView//GraphicsView
    {
        private bool shouldUpdateText = false;
        private float lastWidth = 0;
        private int cols = 0;
        private int rows = 0;

        private string _text;
        private double _fontSize;

        public string Text { get { return _text; } set { SetText(value); } }
        public double FontSize { get { return _fontSize; } set { SetFontSize(value); } }
        public string FontFamily { get { return _fontFamily; } set { SetFontFamily(value); } }

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
            shouldUpdateText = true;
            InvalidateSurface();
        }

        private void UpdateText()
        {
            //HeightRequest
            cols = (int)Math.Floor(Width / FontSize);
            rows = (int)Math.Ceiling(Text.Length / (double)cols);
            HeightRequest = FontSize * rows;
            shouldUpdateText = false;
        }

        private SKCanvas _canvas;
        private string _fontFamily;


        protected override void OnPaintSurface(SKPaintSurfaceEventArgs e)
        {
            if (shouldUpdateText || Width != lastWidth)
            {
                UpdateText();
            }
            base.OnPaintSurface(e);
            _canvas = e.Surface.Canvas;
            _canvas.Clear();
            //_canvas.DrawRect(0, 0, (float)Width, (float)Height, new SKPaint { Color = SKColors.Blue });
            var col = 0;
            var row = 1;
            var font = Microsoft.Maui.Font.OfSize(FontFamily, FontSize);
            
            var fontSize = (float)FontSize;
            /*var font = new Microsoft.Maui.Graphics.Font(FontFamily, 300);
            var typeface = font.ToSKTypeface();*/
            var paint = new SKPaint(/*new SKFont() { Typeface = typeface }*/) { Color = SKColors.Black, TextSize = fontSize };
            foreach(var character in Text)
            {
                _canvas.DrawText(character.ToString(), new SKPoint(col * fontSize, row * fontSize), paint);
                col++;
                if (col % cols == 0)
                {
                    col = 0;
                    row++;
                }
            }

        }

        public void OnFontFamilyChanged(string oldValue, string newValue)
        {
            throw new NotImplementedException();
        }

        public void OnFontSizeChanged(double oldValue, double newValue)
        {
            throw new NotImplementedException();
        }

        public void OnFontAutoScalingEnabledChanged(bool oldValue, bool newValue)
        {
            throw new NotImplementedException();
        }

        public double FontSizeDefaultValueCreator()
        {
            throw new NotImplementedException();
        }

        public void OnFontAttributesChanged(FontAttributes oldValue, FontAttributes newValue)
        {
            throw new NotImplementedException();
        }
    }
}
