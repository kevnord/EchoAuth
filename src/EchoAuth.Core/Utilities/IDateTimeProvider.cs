using System;

namespace EchoAuth.Core.Utilities
{
    public interface IDateTimeProvider
    {
        DateTime NowUtc { get; }
    }
}
