namespace ExampleClassLibrary;

public class InternetHelpers
{
    public static async Task<DateTimeOffset?> LocalTime()
    {
        var dateTimeOffset = await CurrentTimeFromWeb();
        return dateTimeOffset?.ToLocalTime();
    }

    public static async Task<DateTimeOffset?> CurrentTimeFromWeb()
    {
        static async Task<DateTimeOffset?> TimeFromSite(string site)
        {
            using var client = new HttpClient();
            /*
             * Timeout may not be needed, comment out or change milliseconds
             */
            client.Timeout = TimeSpan.FromMilliseconds(1500);
            var response = await client.GetAsync(site);
            return response.Headers.Date!.Value;
        }

        // optionally read from a config file
        var sites = new[] { "https://nist.time.gov", "http://www.microsoft.com", "http://www.google.com" };

        foreach (var site in sites)
        {
            try
            {
                Task<DateTimeOffset?>? dateTimeOffset = Task.FromResult(await TimeFromSite(site));
                if (dateTimeOffset is not null)
                {
                    return await dateTimeOffset;
                }
            }
            catch
            {
                continue;
            }
        }

        return null;

    }
}