using Android.Content;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Widget;

namespace ExampleCustomTable
{
    [Register("exampleCustomTable.MyHorizontalScrollView")]
    public class MyHorizontalScrollView : HorizontalScrollView
    {
        private MyHorizontalScrollView target;
        private RecyclerView recyclerView;

        public MyHorizontalScrollView(Context context) 
            : base(context)
        {
        }

        public MyHorizontalScrollView(Context context, IAttributeSet attrs) 
            : base(context, attrs)
        {
        }

        public MyHorizontalScrollView(Context context, IAttributeSet attrs, int defStyle) 
            : base(context, attrs, defStyle)
        {
        }

        public void Configure(MyHorizontalScrollView target, RecyclerView recyclerView)
        {
            this.target = target;
            this.recyclerView = recyclerView;
        }

        protected override void OnScrollChanged(int l, int t, int oldl, int oldt)
        {
            base.OnScrollChanged(l, t, oldl, oldt);

            this.recyclerView.ClearOnScrollListeners();

            this.target.ScrollTo(l, 0);
        }
    }
}
