using Android.Graphics;
using SkiaSharp;
using Xamarin.Forms;

namespace AndroidStretchingTests
{
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnPaintSkiaSharpFormsSurface(object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs e)
        {
            var skiaView = sender as SkiaSharp.Views.Forms.SKCanvasView;
            var skiaViewSize = new SKSize((float)skiaView.Width, (float)skiaView.Height);

            DoSkiaSharpPaint(e.Surface, e.Info.Size, skiaViewSize);
        }

        private void OnPaintSkiaSharpAndroidSurface(object sender, SkiaSharp.Views.Android.SKPaintSurfaceEventArgs e)
        {
            var skiaView = sender as SkiaSharp.Views.Android.SKCanvasView;
            var skiaViewSize = new SKSize(skiaView.Width, skiaView.Height);

            DoSkiaSharpPaint(e.Surface, e.Info.Size, skiaViewSize);
        }

        private void OnPaintNativeAndroidSurface(object sender, Canvas canvas)
        {
            var view = sender as CustomView;
            var viewSize = new SKSize(view.Width, view.Height);
            var canvasSize = new SKSize(canvas.Width, canvas.Height);

            DoNativePaint(canvas, viewSize, canvasSize);
        }

        private void DoNativePaint(Canvas canvas, SKSize viewSize, SKSize canvasSize)
        {
            // canvas.Clear(SKColors.White);
            canvas.DrawRect(new Rect(0, 0, canvas.Width, canvas.Height), new Paint
            {
                Color = Android.Graphics.Color.White
            });

            var border = new Paint
            {
                StrokeWidth = 5,
                Color = Android.Graphics.Color.Black,
            };
            border.SetStyle(Paint.Style.Stroke);

            var text = new Paint
            {
                TextSize = 50,
            };

            canvas.DrawText("Drawn with Android.Graphics", 50, 50 + text.TextSize, text);
            canvas.DrawText($"View Size: {viewSize}", 50, 200 + text.TextSize, text);
            canvas.DrawText($"Canvas Size: {canvasSize}", 50, 300 + text.TextSize, text);

            canvas.DrawRect(50, 500, 250, 700, border);
            canvas.DrawOval(350, 500, 550, 700, border);
        }

        private void DoSkiaSharpPaint(SKSurface surface, SKSize canvasSize, SKSize viewSize)
        {
            var canvas = surface.Canvas;

            canvas.Clear(SKColors.White);

            var border = new SKPaint
            {
                StrokeWidth = 5,
                Style = SKPaintStyle.Stroke,
            };

            var text = new SKPaint
            {
                TextSize = 50,
            };

            canvas.DrawText("Drawn with SkiaSharp", 50, 50 + text.TextSize, text);
            canvas.DrawText($"View Size: {viewSize}", 50, 200 + text.TextSize, text);
            canvas.DrawText($"Canvas Size: {canvasSize}", 50, 300 + text.TextSize, text);

            canvas.DrawRect(50, 500, 200, 200, border);
            canvas.DrawOval(450, 600, 100, 100, border);
        }
    }
}
