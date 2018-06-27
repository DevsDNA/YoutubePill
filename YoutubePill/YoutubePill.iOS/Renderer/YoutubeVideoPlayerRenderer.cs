using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms.Platform.iOS;

namespace YoutubePill.iOS.Renderer
{
    public class YoutubeVideoPlayerRenderer : WebViewRenderer
    {
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            ScrollView.ScrollEnabled = false;
            ScrollView.Bounces = false;
        }
    }
}