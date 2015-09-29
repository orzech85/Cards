
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

namespace Cards
{
	public class CardLayout : LinearLayout
	{
		public CardLayout (Context context) :
			base (context)
		{
			Initialize ();
		}

		public CardLayout (Context context, IAttributeSet attrs) :
			base (context, attrs)
		{
			Initialize ();
		}

		public CardLayout (Context context, IAttributeSet attrs, int defStyle) :
			base (context, attrs, defStyle)
		{
			Initialize ();
		}

		Cards cards;
		public Cards Cards { 
			get { return cards; } 
			set { 
				cards = value;
				levelView.Level = cards.Card [counter].Level;
				textView.Text = cards.Card [counter].Native [0].ItemElement.Text;
			}
		}

		int counter;

		TextView textView;

		public LevelView levelView { get; set; }

		void Initialize ()
		{
			counter = 0;
			SetBackgroundResource (Resource.Drawable.border);
			textView = new TextView (Context)
				{ Text = "Samochód", Gravity = GravityFlags.Center, TextAlignment = TextAlignment.Center };
			textView.LayoutParameters = new LinearLayout.LayoutParams (LayoutParams.MatchParent, LayoutParams.MatchParent);
			AddView (textView);
			levelView = new LevelView (Context);
		}

		float lastX;
		float lastY;

		public override bool OnTouchEvent (MotionEvent e)
		{
			switch (e.Action) {
			case MotionEventActions.Down:
				lastX = e.GetX ();
				lastY = e.GetY ();
				break;
			case MotionEventActions.Up:
				var diffX = Math.Abs (e.GetX () - lastX);
				var diffY = Math.Abs (e.GetY () - lastY);

				if (diffX > diffY) {
					if (diffX > 100) {
						if (ScaleX == 1.0f) {
							this.Animate ().ScaleX (0.0f).WithEndAction (new Java.Lang.Runnable (() => {
								textView.Text = cards.Card[counter].Foreign[0].ItemElement.Text;
								this.Animate ().ScaleX (0.999f);
							}));
						} else
							this.Animate ().ScaleX (0.0f).WithEndAction (new Java.Lang.Runnable (() => {
								textView.Text = cards.Card[counter].Native[0].ItemElement.Text;
								this.Animate ().ScaleX (1.00f);
							}));
					}
				} else {
					this.Animate ().ScaleX (0f);
					this.Animate ().ScaleY (0f);
					this.Animate ().Alpha (0f).WithEndAction (new Java.Lang.Runnable (() => {
						counter++;
						if (counter < cards.Card.Count) {
							levelView.Level = cards.Card [counter].Level;
							textView.Text = cards.Card[counter].Native[0].ItemElement.Text;
							this.TranslationY = 0.0f;
							this.ScaleX = 0.0f;
							this.ScaleY = 0.0f;
							this.Alpha = 1.0f;
							this.Animate ().ScaleX (1.0f);
							this.Animate ().ScaleY (1.0f);
						}
					}));

					if (e.GetY () - lastY > 0) {
						cards.Card [counter].Level++;
						this.Animate ().TranslationYBy (1000f);
					} else {
						cards.Card [counter].Level = 0;
						this.Animate ().TranslationYBy (-1000f);
					}
				}
				break;
			default:
				break;
			}

			return true;// base.OnTouchEvent (e);
		}
	}
}

