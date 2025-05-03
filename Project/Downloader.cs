namespace Project;

public static class Downloader
{
    public static async Task Download(string destinationPath, List<Uri> urls, int maxParallelism)
    {
        using var httpClient = new HttpClient();

        var parallelOptions = new ParallelOptions
        {
            MaxDegreeOfParallelism = maxParallelism,
        };

        var success = 0;
        var failure = 0;

        Directory.CreateDirectory(destinationPath);

        await Parallel.ForEachAsync(urls, parallelOptions, async (url, cancellationToken) =>
        {
            try
            {
                var path = Path.Combine(destinationPath, Path.GetFileName(url.AbsolutePath));

                var bytes = await httpClient.GetByteArrayAsync(url, cancellationToken);
                await File.WriteAllBytesAsync(path, bytes, cancellationToken);

                Console.WriteLine($"Saved: {path}");
                success++;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Failed to download {url}. Error: {ex.Message}");
                Console.ResetColor();
                failure++;
            }
        });

        Console.WriteLine($"{success} downloads completed successfully, {failure} failed.");
    }
}
