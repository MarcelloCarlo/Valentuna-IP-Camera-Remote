using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;

using System;

namespace Valentuna.Fragments
{
    public class LivePlay : Fragment
    {

        Button CamStartPlay;
        VideoView Camrender;
        Spinner ChannelSpinner;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public static LivePlay NewInstance()
        {
            var livePlay = new LivePlay{ Arguments = new Bundle() };
            return livePlay;
        }


        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var LiveViewV = inflater.Inflate(Resource.Layout.LivePlayFrag, container, false);

            CamStartPlay = LiveViewV.FindViewById<Button>(Resource.Id.CamLivePlay);
            Camrender = LiveViewV.FindViewById<VideoView>(Resource.Id.VideoRender1);
            ChannelSpinner = LiveViewV.FindViewById<Spinner>(Resource.Id.ChannelSpinner);

            CamStartPlay.Click += CamStartPlay_Click;

            return LiveViewV;
        }

        void CamStartPlay_Click(object sender, EventArgs e)
        {
            var uri = Android.Net.Uri.Parse("rtsp://admin:PorkSinigangPro12@192.168.1.34/media/video1");
            //Camrender.SetMediaController(new MediaController(this));
            Camrender.RequestFocus();
            Camrender.SetVideoURI(uri);
            Camrender.Start();
        }
    }
}