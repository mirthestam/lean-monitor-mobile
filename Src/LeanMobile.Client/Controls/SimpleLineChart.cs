using System;
using System.Collections.Generic;
using System.Text;
using SkiaSharp;
using SkiaSharp.Views.Forms;

namespace LeanMobile.Client.Controls
{
    public class SimpleLineChart : SKCanvasView
    {
        public SKColor LineColor { get; set; } = SKColor.Parse("337AB7");

        public float LineSize { get; set; } = 3;

        public SimpleLineChart()
        {
            BackgroundColor = Xamarin.Forms.Color.Transparent;
            PaintSurface += OnOnPaintSurface;
        }

        private void OnOnPaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            var canvas = e.Surface.Canvas;
            canvas.Clear(BackgroundColor.ToSKColor());

            using (var paint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = LineColor,
                StrokeWidth = LineSize,
                IsAntialias = true
            })
            {
                var y = e.Info.Height / 2;

                var path = new SKPath();
                path.MoveTo(0, y);
                path.LineTo(e.Info.Width, y);

                canvas.DrawPath(path, paint);
            }
        }
    }
}
