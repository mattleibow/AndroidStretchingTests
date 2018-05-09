using Android.Content;
using Android.Graphics;
using Android.Util;
using Android.Views;
using System;

namespace AndroidStretchingTests
{
    public class CustomView : View
    {
        public CustomView(Context context)
            : base(context)
        {
        }

        public CustomView(Context context, IAttributeSet attrs)
            : base(context, attrs)
        {
        }

        public CustomView(Context context, IAttributeSet attrs, int defStyle)
            : base(context, attrs, defStyle)
        {
        }

        public override void Draw(Canvas canvas)
        {
            base.Draw(canvas);

            PaintSurface?.Invoke(this, canvas);
        }

        public event EventHandler<Canvas> PaintSurface;
    }
}
