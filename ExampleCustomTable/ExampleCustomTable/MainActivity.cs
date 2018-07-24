using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Android.Util;
using Android.Views;
using System;
using Android.Support.V7.App;

namespace ExampleCustomTable
{
    [Activity(Label = "ExampleCustomTable", MainLauncher = true, Theme = "@style/AppTheme.Base")]
    public class MainActivity : AppCompatActivity
    {
        private ScrollView scrollViewLeftDown, scrollViewRightDown;
        private HorizontalScrollView horizontalScrollViewRightTop, horizontalScrollViewRightBottom;
        private GridView gvRightDown;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);

            //scrolling
            horizontalScrollViewRightTop = this.FindViewById<HorizontalScrollView>(Resource.Id.hs_right_top);
            horizontalScrollViewRightBottom = this.FindViewById<HorizontalScrollView>(Resource.Id.hv_right_down);
            scrollViewLeftDown = this.FindViewById<ScrollView>(Resource.Id.sv_left_down);
            //scrollViewRightDown = this.FindViewById<ScrollView>(Resource.Id.sv_right_down);
            gvRightDown = this.FindViewById<GridView>(Resource.Id.gv_example);
            gvRightDown.Adapter = new ItemsAdapter(this);

            horizontalScrollViewRightTop.ScrollChange += HorizontalScrollViewRightTop_ScrollChange;
            horizontalScrollViewRightBottom.ScrollChange += HorizontalScrollViewRightTop_ScrollChange;

            scrollViewLeftDown.ScrollChange += ScrollViewLeftDown_ScrollChange;
            gvRightDown.ScrollChange += ScrollViewLeftDown_ScrollChange;
            //scrollViewRightDown.ScrollChange += ScrollViewLeftDown_ScrollChange;
        }

        void ScrollViewLeftDown_ScrollChange(object sender, View.ScrollChangeEventArgs e)
        {
            if (((View)sender).Id == Resource.Id.sv_left_down)
            {
                gvRightDown.ScrollTo(0, e.ScrollY);
                //scrollViewRightDown.ScrollTo(0, e.ScrollY);
            }
            else
            {
                Console.WriteLine(e.ScrollY);
                scrollViewLeftDown.ScrollTo(0, e.ScrollY);
            }
        }

        void HorizontalScrollViewRightTop_ScrollChange(object sender, View.ScrollChangeEventArgs e)
        {
            if (((View)sender).Id == Resource.Id.hs_right_top)
            {
                horizontalScrollViewRightBottom.ScrollTo(e.ScrollX, 0);
            }
            else
            {
                horizontalScrollViewRightTop.ScrollTo(e.ScrollX, 0);
            }
        }
    }
}