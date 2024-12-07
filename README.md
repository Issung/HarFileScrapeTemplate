# Har File Scraping Template
The HTTP Archive format, or HAR, is a JSON-formatted archive file format for logging of a web browser's interaction with a site. Able to be exported from the devtools of popular browsers such as Chrome, they are useful for recording network activity of web applications for inspection & debugging.

While trying to find ways to scrape photo albums from Facebook the idea struck me that these could also be used to collect all URLs accessed, filter to those of interest, and then download in parallel.

To do this:
* I opened Chrome devtools.
* Opened the target photo album.
* Held the right arrow key to flip through all the photos in the album.
* Once I reached the end, exported the HAR file.
* Ran this program with downloading disabled (commented out) to print all the urls, then inspect them to find what was common & distinct among all of the target urls (the actual photos of the album).
* Write a LINQ query to filter to those (you can use contains, regex, or match on other data in the HAR file such as headers/timings).
* Once the filter looks good, then run with the download stage uncommented.

This approach is super nice for multiple reasons:
* No need to try and reverse engineer complicated/obfuscated APIs.
* Writing selinium/playwright/puppeteer frontend scrapers are slow to run, can easily be broken often, and development is harder.
* Once you have the HAR file iterating the URL filtering rules is rapid.

Sadly just requires a little manual work for whatever you want to scrape, but if you don't have to do that many times this is a great option for scraping things that you can't otherwise find scraping options for.

This repo is just for me to have this for later, but there's no need for it to be private so I've made it public, hopefully someone out there can take inspiration from it.