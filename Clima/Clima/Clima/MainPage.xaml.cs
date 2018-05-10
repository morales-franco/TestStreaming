using Plugin.MediaManager;
using Plugin.MediaManager.Abstractions;
using Plugin.MediaManager.Abstractions.Enums;
using Plugin.MediaManager.Abstractions.EventArguments;
using Plugin.MediaManager.Abstractions.Implementations;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Clima
{
    public partial class MainPage : ContentPage
    {
        private IPlaybackController PlaybackController => CrossMediaManager.Current.PlaybackController;

        public MainPage()
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
            videoView.Source = "http://clips.vorwaerts-gmbh.de/big_buck_bunny.mp4";
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
