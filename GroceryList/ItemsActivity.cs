using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace GroceryList
{
    [Activity(Label = "ItemsActivity")]
    public class ItemsActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Items);

            var lv = FindViewById<ListView>(Resource.Id.listView1);
            lv.Adapter = new ArrayAdapter<Item>(this,Android.Resource.Layout.SimpleListItem1, Android.Resource.Id.Text1, MainActivity.Items);


            lv.ItemClick += OnItemClick;
        }

        private void OnItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var intent = new Intent(this, typeof(DetailsActivity));
            intent.PutExtra("ItemPosition", e.Position);
            StartActivity(intent);
        }
    }
}