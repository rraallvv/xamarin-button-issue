using System;
using Android.Content;
using Android.Graphics;
using Android.Text;
using Android.Util;
using Android.Widget;
using test;
using test.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Xamarin.Forms.Label), typeof(MyLabelRenderer))]
namespace test.Droid
{
	public class MyLabelRenderer : LabelRenderer
	{
		Context context;

		float myFontSize = 20;
		float scaledDensity;

		public MyLabelRenderer(Context context) : base(context)
		{
			this.context = context;
			SetWillNotDraw(false);
		}

		protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Label> e)
		{
			base.OnElementChanged(e);
			scaledDensity = context.Resources.DisplayMetrics.ScaledDensity;
			Element.FontSize = myFontSize;
		}

		public override void Draw(Canvas canvas)
		{
			base.Draw(canvas);

			TextPaint paint = new TextPaint();
			paint.AntiAlias = true;
			paint.SetTypeface(Control.Typeface);
			paint.TextSize = myFontSize * scaledDensity;
			paint.Color = Android.Graphics.Color.Red;

			Paint.FontMetrics metrics = paint.GetFontMetrics();

			Rect bounds = new Rect();
			paint.GetTextBounds(Element.Text, 0, Element.Text.Length, bounds);

			canvas.DrawText(
				Element.Text,
				0.5f * MeasuredWidth - bounds.Left - 0.5f * bounds.Width(),
				0.5f * MeasuredHeight - metrics.Ascent - 0.5f * (metrics.Bottom - metrics.Top),
				paint
			);
		}
	}
}
