using System.Drawing;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;

namespace FuryMonitor
{
    /// <summary>
    /// Small helper class with Tee Fury specific functionality. Lets you Get the current
    /// shirt image URL, and the current shirt Image.
    /// </summary>
    public class TeeFuryQuerier
    {
        /// <summary>
        /// The height of the tee fury banner at the bottom of the shirt design images.
        /// </summary>
        const int BANNER_HEIGHT = 36;

        /// <summary>
        /// Gets an image URL for the current TeeFury shirt design
        /// </summary>
        /// <returns>The URL of the shirt image, or a blank string if the image could
        /// not be fetched for some reason.</returns>
        public static string GetCurrentTShirtImageURL()
        {
            //Get the RSS feed and find the latest image
            const string FeedURL = @"http://feeds.feedburner.com/TeefuryDailyTee?format=xml";

            WebRequest webRequest = HttpWebRequest.Create(FeedURL);
            webRequest.Method = "GET";

            string source;
            using (StreamReader reader = new StreamReader(webRequest.GetResponse().GetResponseStream()))
            {
                source = reader.ReadToEnd();
            }

            //The large image should be the second thing formatted like so: img src="URLHERE";
            Regex imgUrlMatch = new Regex("img src=\"(.+?)\"");
            try
            {
                string imgURL = imgUrlMatch.Matches(source)[1].Groups[1].Captures[0].Value;
                return imgURL;
            }
            catch (System.Exception)
            {
                return "";
            }
        }

        /// <summary>
        /// Gets a shirt Image from a given URL, cropping the tee fury banner from the bottom
        /// of the image.
        /// </summary>
        /// <param name="url">The URL of the image to retrieve and crop</param>
        /// <returns>The shirt  Image.</returns>
        public static Image GetShirtImageFromURL(string url)
        {
            WebRequest webRequest = HttpWebRequest.Create(url);
            webRequest.Method = "GET";

            using(var image = Image.FromStream(webRequest.GetResponse().GetResponseStream()))
            {
                Bitmap cropped = new Bitmap(image.Width, image.Height - BANNER_HEIGHT);
                using( Graphics graphics = Graphics.FromImage(cropped))
                {
                    graphics.DrawImage(image, new Rectangle(0,0, image.Width, image.Height));
                }

                return cropped;
            }
        }
    }
}
