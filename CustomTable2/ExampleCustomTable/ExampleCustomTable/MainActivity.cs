using System;
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace ExampleCustomTable
{
    [Activity(Label = "ExampleCustomTable", MainLauncher = true, Theme = "@style/AppTheme.Base")]
    public class MainActivity : AppCompatActivity
    {
        public static ScrollView scrollViewLeftDown;
        public static HorizontalScrollView horizontalScrollViewRightBottom;
        public static MyRecyclerView rvLeftDown, rvRightDown, rvRightTop;

        public static bool leftMustScrollBecauseOfRv, rvMustScrollBecauseOfLeft, topMustScrollBecauseOfRv, rvMustScrollBecauseOfTop;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);

            //horizontalScrollViewRightBottom = this.FindViewById<HorizontalScrollView>(Resource.Id.hv_right_down);

            rvRightDown = this.FindViewById<MyRecyclerView>(Resource.Id.rv_right_down);
            rvRightDown.SetAdapter(new RvRightDownAdapter(this));
            var layoutManagerRightDown = new GridLayoutManager(this, 10);
            rvRightDown.SetLayoutManager(layoutManagerRightDown);

            rvLeftDown = this.FindViewById<MyRecyclerView>(Resource.Id.rv_left_down);
            rvLeftDown.SetAdapter(new RvLeftDownAdapter(this));
            var layoutManagerLeftDown = new GridLayoutManager(this, 1);
            rvLeftDown.SetLayoutManager(layoutManagerLeftDown);

            rvRightTop = this.FindViewById<MyRecyclerView>(Resource.Id.rv_right_top);
            rvRightTop.SetAdapter(new RvRightTopAdapter(this));
            var layoutManagerRightTop = new GridLayoutManager(this, 1, LinearLayoutManager.Horizontal, false);
            rvRightTop.SetLayoutManager(layoutManagerRightTop);

            rvRightDown.TargetToScroll = rvLeftDown;

            //horizontalScrollViewRightBottom.ScrollChange += HorizontalScrollViewRightTop_ScrollChange;

            rvRightDown.AddOnScrollListener(new ScrollListenerRightDownImplementation());
            rvLeftDown.AddOnScrollListener(new ScrollListenerLeftDownImplementation());
            rvRightTop.AddOnScrollListener(new ScrollListenerRightTopImplementation());

            rvRightDown.AddOnItemTouchListener(new ItemTouchListenerRightDownImplementation());
            rvLeftDown.AddOnItemTouchListener(new ItemTouchListenerLeftDownImplementation());
            //rvRightTop.AddOnItemTouchListener(new ItemTouchListenerRightTopImplementation());
        }

        //void HorizontalScrollViewRightTop_ScrollChange(object sender, View.ScrollChangeEventArgs e)
        //{
        //    rvRightTop.SmoothScrollBy(e.ScrollX, 0);
        //}
    }

    public class PhotoViewHolder : RecyclerView.ViewHolder
    {
        public PhotoViewHolder(View itemView) : base(itemView)
        {
        }
    }
}