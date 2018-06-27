using Android.Webkit;

namespace YoutubePill.Droid.Renderer
{
    internal class YoutubeFullScreenWebClient : WebViewClient
    {
        public override bool ShouldOverrideUrlLoading(WebView view, string url)
        {
            view.LoadUrl(url);
            return true;
        }

        public override bool ShouldOverrideUrlLoading(WebView view, IWebResourceRequest request)
        {
            view.LoadUrl(request.Url.ToString());
            return true;
        }
    }
}