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
    [Activity(Label = "AddItemsActivity")]
    public class AddItemsActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.AddItem);

            FindViewById<Button>(Resource.Id.Savebutton).Click += OnSaveClick;
            FindViewById<Button>(Resource.Id.Cancelbutton).Click += OnCancelClick;
        }

        private void OnCancelClick(object sender, EventArgs e)
        {
            Finish();
        }

        private void OnSaveClick(object sender, EventArgs e)
        {
            string name  = FindViewById<EditText>(Resource.Id.nameEditText).Text;
            int count = int.Parse(FindViewById<EditText>(Resource.Id.countEditText).Text);

            var intent = new Intent();
            intent.PutExtra("ItemName", name);
            intent.PutExtra("ItemCount", count);
            SetResult(Result.Ok, intent);

            Finish();

        }
    }
}