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
    public class Item
    {
        public string Name { get; set; }
        public long Count { get; set; }

        public Item(string name, long count)
        {
            this.Name = name;
            this.Count = count;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}