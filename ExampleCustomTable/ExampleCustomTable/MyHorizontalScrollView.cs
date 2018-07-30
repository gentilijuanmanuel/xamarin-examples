using System;
using Android.Content;
using Android.Graphics;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace ExampleCustomTable
{
    [Register("exampleCustomTable.MyHorizontalScrollView")]
    public class MyHorizontalScrollView : HorizontalScrollView
    {
        public MyHorizontalScrollView(Context context) : base(context)
        {
        }

        public MyHorizontalScrollView(Context context, IAttributeSet attrs) : base(context, attrs)
        {    
        }

        public MyHorizontalScrollView(Context context, IAttributeSet attrs, int defStyle) : base(context, attrs, defStyle)
        {   
        }

        protected override void OnScrollChanged(int l, int t, int oldl, int oldt)
        {
            base.OnScrollChanged(l, t, oldl, oldt);

            MainActivity.rvRightDown.ClearOnScrollListeners();

            if(MainActivity.horizontalScrollViewRightTop.Equals(this))
                MainActivity.horizontalScrollViewRightBottom.ScrollTo(l, 0);
            else
                MainActivity.horizontalScrollViewRightTop.ScrollTo(l, 0);
        }
    }
}
