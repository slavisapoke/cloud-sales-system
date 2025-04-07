namespace Poke.CloudSalesSystem.Customers.Common.Helpers;

/// <summary>
/// Could be part of library nuget
/// </summary>
public static class Preconditions
{
    /// <summary>
    /// Returns given value if not null. Else throwing Argument exception
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="reference"></param>
    /// <param name="paramName"></param>
    /// <param name="message"></param>
    /// <exception cref="ArgumentNullException"></exception>
    /// <returns></returns>
    public static T CheckNotNull<T>(T? reference, string paramName) where T : class
    {
        return CheckNotNull(reference, paramName, string.Empty);
    }

    /// <summary>
    /// Returns given value if not null. Else throwing Argument exception with custom message
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="reference"></param>
    /// <param name="paramName"></param>
    /// <param name="message"></param>
    /// <exception cref="ArgumentNullException"></exception>
    /// <returns></returns>
    public static T CheckNotNull<T>(T? reference, string paramName, string message) where T : class
    {
        if (reference != null)
        {
            return reference;
        }

        throw string.IsNullOrEmpty(message) ? new ArgumentNullException(paramName) : new ArgumentNullException(paramName, message);
    }
}
