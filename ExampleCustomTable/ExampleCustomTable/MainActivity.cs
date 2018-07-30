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
        private MyHorizontalScrollView horizontalScrollViewRightBottom, horizontalScrollViewRightTop;
        private AligningRecyclerView rvLeftDown, rvRightDown;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);

            this.rvRightDown = this.FindViewById<AligningRecyclerView>(Resource.Id.rv_right_down);
            this.rvRightDown.SetAdapter(new RvRightDownAdapter(this));
            var layoutManagerRightDown = new GridLayoutManager(this, 6);
            this.rvRightDown.SetLayoutManager(layoutManagerRightDown);

            this.rvLeftDown = this.FindViewById<AligningRecyclerView>(Resource.Id.rv_left_down);
            this.rvLeftDown.SetAdapter(new RvLeftDownAdapter(this));
            var layoutManagerLeftDown = new GridLayoutManager(this, 1);
            this.rvLeftDown.SetLayoutManager(layoutManagerLeftDown);

            this.rvLeftDown.bindTo(rvRightDown);
            this.rvRightDown.bindTo(rvLeftDown);

            this.horizontalScrollViewRightTop = this.FindViewById<MyHorizontalScrollView>(Resource.Id.hv_right_top);
            this.horizontalScrollViewRightBottom = this.FindViewById<MyHorizontalScrollView>(Resource.Id.hv_right_down);

            this.horizontalScrollViewRightTop.Configure(this.horizontalScrollViewRightBottom, this.rvRightDown);
            this.horizontalScrollViewRightBottom.Configure(this.horizontalScrollViewRightTop, this.rvRightDown);
        }
    }

    public class PhotoViewHolder : RecyclerView.ViewHolder
    {
        public PhotoViewHolder(View itemView) : base(itemView)
        {
        }
    }
}