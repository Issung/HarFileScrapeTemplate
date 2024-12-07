using HarSharp;
using Project;

const string harPath = "C:\\Users\\example\\Downloads\\example.har";
const string destinationPath = "C:\\Users\\example\\Downloads\\HarFileScrapes";
var har = HarConvert.DeserializeFromFile(harPath);

var urls = Scraper.Scrape(har);

Console.WriteLine(string.Join("\n\t", urls));
Console.Write($"Count: {urls.Count}.");

await Downloader.Download(
    destinationPath,
    urls,
    maxParallelism: 5
);