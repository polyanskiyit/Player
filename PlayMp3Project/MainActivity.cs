using Android.App;
using Android.Widget;
using Android.OS;
using Android.Media;
using System.Collections.Generic;
using System.IO;

namespace PlayMp3Project
{
    [Activity(Label = "Mp3 Player Project", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        MediaPlayer player;

        private List<string> mItem;
        private ListView mListView;
        private Button
            playBtn,
            pauseBtn,
            stopBtn;
        

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            init();

            //  Єдиний робочий варіант
            //player = MediaPlayer.Create(this, Resource.Raw.ABBA_L);


            //  path
            //string MP3Path = Path.Combine("/sdcard/" + Android.OS.Environment.DirectoryMusic);
            var directories = Directory.EnumerateFiles(Path.Combine("/sdcard/" + Android.OS.Environment.DirectoryMusic));

            mItem = new List<string>();
            List<string> mItemName = new List<string>();

            foreach (var directory in directories)
            {
                mItem.Add(directory);
            }


            //  ?????
            player.SetDataSource(mItem[0]);







            //  events
            playBtn.Click += (sender, e) =>
            {
                player.Start();
            };

            pauseBtn.Click += (sender, e) =>
            {
                player.Pause();
            };

            stopBtn.Click += (sender, e) =>
            {
                player.Stop();
            };

            //  адаптер листа
            ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, mItem);
            mListView.ItemClick += MListView_ItemClick;

            mListView.Adapter = adapter;

            
        }
        
        public void init()
        {
            //  init
            playBtn = FindViewById<Button>(Resource.Id.PlayButton);
            pauseBtn = FindViewById<Button>(Resource.Id.pauseBtn);
            stopBtn = FindViewById<Button>(Resource.Id.stopBtn);
            mListView = FindViewById<ListView>(Resource.Id.listView1);
        }

        private void MListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            //Get our item from the list adapter
            var item = this.mListView.GetItemAtPosition(e.Position);

            //Make a toast with the item name just to show it was clicked
            Toast.MakeText(this, item + " Clicked!", ToastLength.Short).Show();
        }
    }
}


