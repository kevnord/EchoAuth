using System;

namespace EchoAuth.Core.Utilities
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime NowUtc { get { return DateTime.UtcNow; } }
    }
}