using Android.Content;
using Android.Graphics;
using RealSimpleCircle.Abstractions;
using RealSimpleCircle.Android;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Circle), typeof(CircleRenderer))]
namespace RealSimpleCircle.Android
{
    public class CircleRenderer : ViewRenderer<Circle, global::Android.Views.View>
    {
        public CircleRenderer(Context context) : base(context)
        {
            SetWillNotDraw(false);
        }

        public static void Init()
        {
            var dummy = new CircleRenderer(global::Android.App.Application.Context);
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Circle> e)
        {
            base.OnElementChanged(e);
            if (Control == null)
            {
                var circleDotView = new global::Android.Views.View(Context);
                SetNativeControl(circleDotView);
            }
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == Circle.ActiveProperty.PropertyName)
            {
                Invalidate();
            }
        }
        
        protected override void OnDraw(Canvas canvas)
        {
            var rect = new Rect();
            this.GetDrawingRect(rect);
            Paint paint;

            // circleDotFill
            if (Element.Active)
            {
                RectF circleDotFillRect = new RectF(
                    rect.Left + 1f,
                    rect.Top + 1f,
                    rect.Right - 1f,
                    rect.Bottom - 1f);
                Path circleDotFillPath = new Path();
                circleDotFillPath.AddOval(circleDotFillRect, Path.Direction.Cw);

                paint = new Paint(PaintFlags.AntiAlias);
                paint.SetStyle(Paint.Style.Fill);
                paint.Color = Element.FillColor.ToAndroid();
                canvas.DrawPath(circleDotFillPath, paint);
            }

            // circleDotStroke
            RectF circleDotStrokeRect = new RectF(
                rect.Left + 1f,
                rect.Top + 1f,
                rect.Right - 1f,
                rect.Bottom - 1f);
            Path circleDotStrokePath = new Path();
            circleDotStrokePath.AddOval(circleDotStrokeRect, Path.Direction.Cw);

            paint = new Paint(PaintFlags.AntiAlias);
            paint.StrokeWidth = 2.5f;
            paint.StrokeMiter = 10f;
            canvas.Save();
            paint.SetStyle(Paint.Style.Stroke);
            paint.Color = Element.StrokeColor.ToAndroid();
            canvas.DrawPath(circleDotStrokePath, paint);
            canvas.Restore();
        }
    }
}