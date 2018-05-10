using Plugin.MediaManager;
using Plugin.MediaManager.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Clima
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestAudio : ContentPage
    {
        private IAudioPlayer PlaybackController => CrossMediaManager.Current.AudioPlayer;
        public TestAudio()
        {
            InitializeComponent();
            CrossMediaManager.Current.PlayingChanged += (sender, e) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    ProgressBar.Progress = e.Progress;
                    Duration.Text = "" + e.Duration.TotalSeconds + " seconds";
                });
            };
        }

        protected override void OnAppearing()
        {
            //videoView.Source = "http://sisteplay1.streamwowza.com:1935/radiohd/RAD25679/playlist.m3u8";
            //videoView.Source = "https://audioboom.com/posts/5766044-follow-up-305.mp3";
            //videoView.Source = "http://sc02.yertel.com:8094/;stream.mp3";
            //videoView.Source = "http://69.175.20.242:8112/live";
            videoView.Source = "rtsp://sisteplay1.streamwowza.com:1935/radiohd/RAD25679/";
        }

        void PlayClicked(object sender, System.EventArgs e)
        {
            PlaybackController.Play();
        }

        void PauseClicked(object sender, System.EventArgs e)
        {
            PlaybackController.Pause();
        }

        void StopClicked(object sender, System.EventArgs e)
        {
            PlaybackController.Stop();
        }
    }
}