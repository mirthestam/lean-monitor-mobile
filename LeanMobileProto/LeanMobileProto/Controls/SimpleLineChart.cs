using System;
using System.Collections.Generic;
using System.Text;
using SkiaSharp;
using SkiaSharp.Views.Forms;

namespace LeanMobileProto.Controls
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
                int x = 0;

                var path = new SKPath();                
                path.MoveTo(0, y);

                var random = new Random(DateTime.Now.Millisecond);

                while (x < e.Info.Width)
                {                                        
                    var next = random.Next(0, 500);
                    y += next >= 250 ? 1 : -1;
                    y = Math.Max(0, y);
                    y = Math.Min(e.Info.Height, y);
                    path.LineTo(x, e.Info.Height - (y));   
                    x++;
                }
              
                canvas.DrawPath(path, paint);
            }
        }
    }
}
