﻿using System.Text;

namespace Poke.CloudSalesSystem.Common.Helpers;

/// <summary>
/// Dummy licence key generator
/// </summary>
public static class LicenceGenerator
{
    /// <summary>
    /// Generates string consisted of segments separated by the given separator
    /// </summary>
    /// <param name="separator">Separator</param>
    /// <param name="numOfSegments">How many segments</param>
    /// <param name="segmentLength">Segment length</param>
    /// <returns></returns>
    public static string GenerateSegmentedString(char separator, int numOfSegments = 5, int segmentLength = 5)
    {
        Preconditions.CheckGreaterThanZero(numOfSegments);
        Preconditions.CheckGreaterThanZero(segmentLength);

        string[] parts = new string[numOfSegments];

        for(var i = 0; i < numOfSegments; i++)
        {
            parts[i] = GenerateRandomPart(segmentLength);
        }

        return string.Join(separator, parts);
    }

    private static string GenerateRandomPart(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        Random random = new Random();
        StringBuilder result = new StringBuilder(length);

        for (int i = 0; i < length; i++)
        {
            result.Append(chars[random.Next(chars.Length)]);
        }

        return result.ToString();
    }
}
