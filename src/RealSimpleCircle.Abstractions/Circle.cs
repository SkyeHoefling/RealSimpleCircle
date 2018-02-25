using Xamarin.Forms;

namespace RealSimpleCircle.Abstractions
{
    public class Circle : View
    {
        public Color FillColor
        {
            get { return (Color)GetValue(FillColorProperty); }
            set { SetValue(FillColorProperty, value); }
        }

        public static readonly BindableProperty FillColorProperty = BindableProperty.Create(
            nameof(FillColor),
            typeof(Color),
            typeof(Circle),
            Color.Black);

        public Color StrokeColor
        {
            get { return (Color)GetValue(StrokeColorProperty); }
            set { SetValue(StrokeColorProperty, value); }
        }

        public static readonly BindableProperty StrokeColorProperty = BindableProperty.Create(
            nameof(StrokeColor),
            typeof(Color),
            typeof(Circle),
            Color.Black);

        public bool Active
        {
            get { return (bool)GetValue(ActiveProperty); }
            set { SetValue(ActiveProperty, value); }
        }

        public static readonly BindableProperty ActiveProperty = BindableProperty.Create(
            nameof(Active),
            typeof(bool),
            typeof(Circle),
            false);
    }
}
