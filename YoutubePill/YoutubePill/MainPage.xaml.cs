using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace YoutubePill
{
	public partial class MainPage : ContentPage
	{
        private const string Html = @"<iframe width=""widthReq"" height=""heightReq"" src=""strUrl"" frameborder=""0"" 
                                style=""margin:none; padding:none; border:none;"" 
                                allowfullscreen=""allowfullscreen""
                                allowfullscreen>
                                </iframe></body></html>";

        private const string embedUrl = "https://www.youtube.com/watch?v=g9RQLeGr--A&t=4s";

        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            YoutubeVideoPlayer.Source = new HtmlWebViewSource() { Html = GetVideoIframe() };
        }

        private string GetVideoIframe()
        {
            return Html.Replace("strUrl", embedUrl.ToEmbedUrl())
                                 .Replace("widthReq", "300")
                                 .Replace("heightReq", "200");
        }
    }
}
        