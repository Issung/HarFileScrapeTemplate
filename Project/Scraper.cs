using HarSharp;

namespace Project;

public static class Scraper
{
    public static List<Uri> Scrape(Har har)
    {
        var urls = har.Log.Entries
            // Facebook example, lots of jpgs in the har file things like UI icons, profile pictures, emojis.
            // This simple check filtered it down to just the album photos that I needed.
            .Where(e => e.Request.Url.AbsoluteUri.Contains(".jpg?_nc_cat="))
            .Select(e => e.Request.Url)
            // Facebook har file had a lot of images appearing twice but with different signature urls in the query params.
            // Probably due to some UI dodginess. De-duplicating by the path remedies this.
            .DistinctBy(url => url.AbsolutePath)
            .ToList();

        return urls;
    }
}
