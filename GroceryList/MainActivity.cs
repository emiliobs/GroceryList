using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace GroceryList
{
    [Activity(Label = "GroceryList", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
       public static List<Item> Items = new List<Item>();

        protected override void OnCreate(Bundle bundle)
        {
            //Pre-load with  some sample data for convenience.!
            Items.Add(new Item("Milk", 1));
            Items.Add(new Item("Crackers", 1));
            Items.Add(new Item("Apples", 5));


            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
          FindViewById<Button>(Resource.Id.itemButton).Click += OnItemClick;
          FindViewById<Button>(Resource.Id.addButton).Click += OnAddClick;
          FindViewById<Button>(Resource.Id.aboutButton).Click += OnAboutClick;

           
        }

        private void OnAboutClick(object sender, EventArgs e)
        {
            StartActivity(typeof(AboutActivity));

        }

        private void OnAddClick(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(AddItemsActivity));
            StartActivityForResult(intent, 100);
        }

        private void OnItemClick(object sender, EventArgs e)
        {
            //use the standart technique to star an activity: create a Intent and then pass it to startActivity:
            var intent = new Intent(this, typeof(ItemsActivity));
            StartActivity(intent);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            if (requestCode == 100 && resultCode == Result.Ok)
            {
                string name = data.GetStringExtra("ItemName");
                int count = data.GetIntExtra("ItemCount", 0);

                MainActivity.Items.Add(new Item(name, count));
            }
        }
    }
}

