using MauiSkiaPrototype.Controls;

namespace MauiSkiaPrototype.Drawables
{
    public class TextRendererDrawable: IDrawable
    {
        private TextRenderer _textRenderer;

        public TextRendererDrawable(TextRenderer textRenderer)
        {
            _textRenderer = textRenderer;
        }

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            if (_textRenderer.ShouldUpdateText || _textRenderer.Width != _textRenderer.LastWidth)
            {
                _textRenderer.UpdateText();
            }
     
            //_canvas.DrawRect(0, 0, (float)Width, (float)Height, new SKPaint { Color = SKColors.Blue });
            var col = 0;
            var row = 1;

            var fontSize = (float)_textRenderer.FontSize;
            canvas.Font = new Microsoft.Maui.Graphics.Font("Roboto");
            canvas.FontColor = Colors.Black;
            canvas.FontSize = fontSize;
            foreach (var character in _textRenderer.Text)
            {
                canvas.DrawString(character.ToString(), col * fontSize, row * fontSize, HorizontalAlignment.Left);
                col++;
                if (col % _textRenderer.Cols == 0)
                {
                    col = 0;
                    row++;
                }
            }
        }
    }
}
