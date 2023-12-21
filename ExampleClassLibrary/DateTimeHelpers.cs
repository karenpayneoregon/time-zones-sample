using System.Collections.Immutable;
using System.Collections.ObjectModel;

namespace ExampleClassLibrary;

public static class DateTimeHelpers
{
    public static async Task<(ImmutableList<string> list, bool success)> TimeZones()
    {
        DateTimeOffset? local = await InternetHelpers.LocalTime();
        return local is null ?
            (new List<string>().ToImmutableList(), false) :
            (local.Value.PossibleTimeZones(), true);
    }

    public static ImmutableList<string> PossibleTimeZones(this DateTimeOffset offsetTime)
    {
        List<string> list = [];
        TimeSpan offset = offsetTime.Offset;

        ReadOnlyCollection<TimeZoneInfo> timeZones = AllTimeZones();

        list.AddRange(timeZones
            .Where(timeZone => timeZone.GetUtcOffset(offsetTime.DateTime).Equals(offset))
            .Select(timeZone => timeZone.DaylightName));

        return list.ToImmutableList();
    }

    public static ReadOnlyCollection<TimeZoneInfo> AllTimeZones()
    {
        ReadOnlyCollection<TimeZoneInfo> timeZones = TimeZoneInfo.GetSystemTimeZones();
        return timeZones;
    }
}