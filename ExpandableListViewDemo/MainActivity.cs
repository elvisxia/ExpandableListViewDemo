using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using Android.Views;
using System;
using Java.Lang;
using Org.Json;

namespace ExpandableListViewDemo
{
    [Activity(Label = "TestFilterDemo", MainLauncher = true)]
    public class MainActivity : Activity
    {
        Button btnFilter;
        private List<string> group = new List<string>();
        private string[] names;
        private Dictionary<string, List<string>> Mapout = new Dictionary<string, List<string>>();
        private ExpandableListViewAdapter mAdapter;
        ExpandableListView exListview;
        EditText etQuery;

        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);
            
            btnFilter = FindViewById<Button>(Resource.Id.btnFilter);
            exListview = FindViewById<ExpandableListView>(Resource.Id.Exlistview);
            etQuery = FindViewById<EditText>(Resource.Id.etQuery);
            etQuery.TextChanged += EtQuery_TextChanged;
            SetData(out mAdapter);
            
            exListview.SetAdapter(mAdapter);
            btnFilter.Click += BtnFilter_Click;
        }

        private void EtQuery_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            mAdapter.Filter.InvokeFilter(e.Text.ToString());
        }

        private void BtnFilter_Click(object sender, EventArgs e)
        {
            mAdapter.Filter.InvokeFilter("odd");
        }

        void SetData(out ExpandableListViewAdapter adapter)
        {
            string urlholder;
            string url;
            string json;
            string time;
            string timestamp;
            string together;

            //create fake names[]
            names = new string[10];
            for (int i = 0; i < 10; i++)
            {
                if (i % 2 == 1)
                {
                    names[i] = "Odd Group" + i;
                }
                else
                {
                    names[i] = "Even Group" + i;
                }
            }

            //create fake data
            for (int i = 0; i < 10; i++)
            {
                List<string> listplaceholder = new List<string>();
                group.Add(names[i]);
                urlholder = Uri.EscapeDataString(names[i]);
                url = "**********";
                json = CreateJsonArray();
                JSONArray array2 = new JSONArray(json);
                int length2 = array2.Length();
                for (int j = 0; j < length2; j++)
                {
                    JSONObject Element = array2.GetJSONObject(j);
                    time = Element.GetString("wait");
                    JSONObject TimeElement = array2.GetJSONObject(j);
                    timestamp = TimeElement.GetString("created_at");
                    //timestamp = timestamp.Replace("T", " at ");
                    //int index = timestamp.IndexOf(".");
                    //if (index > 0)
                    //{
                    //    timestamp = timestamp.Substring(0, index);
                    //}
                    together = time + " minutes posted at " + timestamp;
                    listplaceholder.Add(together);
                }
                Mapout.Add(group[i], listplaceholder);
            }
            adapter = new ExpandableListViewAdapter(this, group, Mapout,exListview);
        }

        string  CreateJsonArray()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            Random rand = new Random();
            int len=rand.Next(1, 12);
            for (int i = 0; i < len; i++)
            {
                int tmpWait = rand.Next(0, 60);
                string tmp = @"{'wait':"+tmpWait+",'created_at':'2017/09/15'},";
                sb.Append(tmp);
            }
            sb.DeleteCharAt(sb.Length() - 1);
            sb.Append("]");
            return sb.ToString();
        }
    }

}

