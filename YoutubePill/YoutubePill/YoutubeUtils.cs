using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace YoutubePill
{
    public static class YoutubeUtils
    {
        private static readonly List<string> ValidAuthorities = new List<string>
        {
            "youtube.com", 
            "www.youtube.com", 
            "youtu.be", 
            "www.youtu.be"
        };
        
        private const string EmbedPattern = "(?:.+?)?(?:\\/v\\/|embed\\/|\\?v=|\\&v=|youtu\\.be\\/|\\/v=|^youtu\\.be\\/)([a-zA-Z0-9_-]{11})+";
        private const string WatchPattern = "(?:.+?)?(?:\\/v\\/|watch\\/|\\?v=|\\&v=|youtu\\.be\\/|\\/v=|^youtu\\.be\\/)([a-zA-Z0-9_-]{11})+";
        private static readonly Regex EmbedRegex = new Regex(WatchPattern);
        private static readonly Regex WatchRegex = new Regex(EmbedPattern);
        
        public static string ExtractVideoIdFromUrl(this string url)
        {
            try
            {
                var authority = new UriBuilder(url).Uri.Authority.ToLower();

                //check if the url is a youtube url
                if (ValidAuthorities.Contains(authority))
                {
                    //and extract the id
                    var regRes = EmbedRegex.Match(url);
                    if (regRes.Success)
                    {
                        return regRes.Groups[1].Value;
                    }

                    regRes = WatchRegex.Match(url);
                    if (regRes.Success)
                    {
                        return regRes.Groups[1].Value;
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }

            return null;
        }

        public static string ToEmbedUrl(this string url)
            => url.Contains("embed") 
                ? url
                : $"https://www.youtube.com/embed/{url.ExtractVideoIdFromUrl()}";
    }
}
