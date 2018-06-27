using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Hardware;
using Android.Views;
using Android.Webkit;
using Android.Widget;
using System;
using Xamarin.Forms;

namespace YoutubePill.Droid.Renderer
{
    internal class YoutubeFullScreenChromeClient : WebChromeClient
    {
        private Android.Views.View customView;
        private WebChromeClient.ICustomViewCallback viewCallback;
        private FrameLayout fullScreenContainer;
        private ScreenOrientation originalOrientation;
        private StatusBarVisibility originalSystemUIVisibility;

        public override void OnHideCustomView()
        {
            base.OnHideCustomView();
            ((FrameLayout)(Forms.Context as Activity).Window.DecorView).RemoveView(customView);
            customView = null;
            (Forms.Context as Activity).Window.DecorView.SystemUiVisibility = originalSystemUIVisibility;
            (Forms.Context as Activity).RequestedOrientation = originalOrientation;
            viewCallback?.OnCustomViewHidden();
            viewCallback = null;
        }



        public override void OnShowCustomView(Android.Views.View view, ICustomViewCallback callback)
        {
            if (customView != null)
            {
                OnHideCustomView();
            }
            else
            {
                originalSystemUIVisibility = (Forms.Context as Activity).Window.DecorView.SystemUiVisibility;
                originalOrientation = (Forms.Context as Activity).RequestedOrientation;
                customView = view;
                viewCallback = callback;
                ((FrameLayout)(Forms.Context as Activity).Window.DecorView)
                .AddView(customView, new FrameLayout.LayoutParams(FrameLayout.LayoutParams.MatchParent, FrameLayout.LayoutParams.MatchParent));
            }
        }
    }

    public class MyOrientationEventListener : OrientationEventListener
    {
        public Action<int> OrientationChanged;

        public MyOrientationEventListener(Context context) : base(context, SensorDelay.Normal)
        {
        }

        public override void OnOrientationChanged(int orientation)
        {
            OrientationChanged?.Invoke(orientation);
        }


    }
}