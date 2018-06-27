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
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using YoutubePill;
using YoutubePill.Droid.Renderer;

[assembly:ExportRenderer(typeof(YoutubeVideoPlayer), typeof(YoutubeVideoPlayerRenderer))]
namespace YoutubePill.Droid.Renderer
{
    public class YoutubeVideoPlayerRenderer : WebViewRenderer
    {
        public YoutubeVideoPlayerRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<WebView> e)
        {
            base.OnElementChanged(e);

            if (Control == null || Element == null)
                return;


            Control.SetWebViewClient(new YoutubeFullScreenWebClient());
            Control.SetWebChromeClient(new YoutubeFullScreenChromeClient());
            Control.Settings.JavaScriptEnabled = true;
            Control.Settings.SetAppCacheEnabled(true);
            Control.Settings.BuiltInZoomControls = false;
            Control.Settings.SaveFormData = true;
            

        }
    }
}