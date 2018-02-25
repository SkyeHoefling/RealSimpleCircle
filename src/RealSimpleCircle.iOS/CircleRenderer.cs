using CoreGraphics;
using RealSimpleCircle.Abstractions;
using RealSimpleCircle.iOS;
using System.ComponentModel;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Circle), typeof(CircleRenderer))]
namespace RealSimpleCircle.iOS
{
    public class CircleRenderer : ViewRenderer<Circle, UIView>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Circle> e)
        {
            base.OnElementChanged(e);
            if (Control == null)
            {
                var circleDotView = new UIView();
                SetNativeControl(circleDotView);
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == Circle.ActiveProperty.PropertyName)
            {
                SetNeedsDisplay();
            }
        }

        public override void Draw(CGRect rect)
        {
            DrawCircleDot(rect, Element.FillColor.ToUIColor(), Element.StrokeColor.ToUIColor(), Element.Active);
        }

        private void DrawCircleDot(CGRect frame, UIColor colorFill, UIColor colorStroke, bool circleDotActive)
        {

            if (circleDotActive)
            {
                //// circleDotFill Drawing
                var circleDotFillPath = UIBezierPath.FromOval(new CGRect(frame.GetMinX() + 1.0f, frame.GetMinY() + 1.0f, frame.Width - 2.0f, frame.Height - 2.0f));
                colorFill.SetFill();
                circleDotFillPath.Fill();
            }


            //// circleDotStroke Drawing
            var circleDotStrokePath = UIBezierPath.FromOval(new CGRect(frame.GetMinX() + 1.0f, frame.GetMinY() + 1.0f, frame.Width - 2.0f, frame.Height - 2.0f));
            colorStroke.SetStroke();
            circleDotStrokePath.LineWidth = 1.5f;
            circleDotStrokePath.Stroke();
        }
    }
}
