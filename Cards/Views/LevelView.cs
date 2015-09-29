
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Graphics;

namespace Cards
{
	public class LevelView : View
	{
		public LevelView (Context context) :
			base (context)
		{
			Initialize ();
		}

		public LevelView (Context context, IAttributeSet attrs) :
			base (context, attrs)
		{
			Initialize ();
		}

		public LevelView (Context context, IAttributeSet attrs, int defStyle) :
			base (context, attrs, defStyle)
		{
			Initialize ();
		}

		void Initialize ()
		{
			maxLevel = 5;
		}

		public int Level { get; set; }
		public int maxLevel { get; set; }

		protected override void OnDraw (Android.Graphics.Canvas canvas)
		{
			Paint paint = new Paint () { Color = Color.ForestGreen, StrokeWidth = 5 };
			for (int i = 0; i < maxLevel; i++) {
				if (i < Level)
					paint.SetStyle (Paint.Style.Fill);
				else
					paint.SetStyle (Paint.Style.Stroke);
				canvas.DrawCircle (canvas.Height / 2 + canvas.Height*i , canvas.Height / 2, canvas.Height / 2 - 5, paint);
			}
		}
	}
}

