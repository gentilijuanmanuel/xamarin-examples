using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;

namespace ExampleCustomTable
{
    [Activity(Label = "ExampleCustomTable", MainLauncher = true, Theme = "@style/AppTheme.Base")]
    public class MainActivity : AppCompatActivity
    {
        public static MyHorizontalScrollView horizontalScrollViewRightBottom, horizontalScrollViewRightTop;
        public static AligningRecyclerView rvLeftDown, rvRightDown;

        public static bool leftMustScrollBecauseOfRv, rvMustScrollBecauseOfLeft, topMustScrollBecauseOfRv, rvMustScrollBecauseOfTop;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);

            horizontalScrollViewRightBottom = this.FindViewById<MyHorizontalScrollView>(Resource.Id.hv_right_down);
            horizontalScrollViewRightTop = this.FindViewById<MyHorizontalScrollView>(Resource.Id.hv_right_top);

            rvRightDown = this.FindViewById<AligningRecyclerView>(Resource.Id.rv_right_down);
            rvRightDown.SetAdapter(new RvRightDownAdapter(this));
            var layoutManagerRightDown = new GridLayoutManager(this, 6);
            rvRightDown.SetLayoutManager(layoutManagerRightDown);

            rvLeftDown = this.FindViewById<AligningRecyclerView>(Resource.Id.rv_left_down);
            rvLeftDown.SetAdapter(new RvLeftDownAdapter(this));
            var layoutManagerLeftDown = new GridLayoutManager(this, 1);
            rvLeftDown.SetLayoutManager(layoutManagerLeftDown);

            rvLeftDown.bindTo(rvRightDown);
            rvRightDown.bindTo(rvLeftDown);
        }
    }

    public class PhotoViewHolder : RecyclerView.ViewHolder
    {
        public PhotoViewHolder(View itemView) : base(itemView)
        {
        }
    }
}