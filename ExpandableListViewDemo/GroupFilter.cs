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
using Java.Lang;

namespace ExpandableListViewDemo
{
    public class GroupFilter:Filter
    {
        ExpandableListViewAdapter _adapter;
        public GroupFilter(ExpandableListViewAdapter adapter)
        {
            _adapter = adapter;
        }
        protected override FilterResults PerformFiltering(ICharSequence constraint)
        {
            var result = new FilterResults();
            // add the filtered items to FilterResults
            //convert net object to java object
            
            return result;
        }

        protected override void PublishResults(ICharSequence constraint, FilterResults results)
        {
            //convert java object to Net object
            //Call _adapter.NotifyDataSetChanged();
        }
    }
}