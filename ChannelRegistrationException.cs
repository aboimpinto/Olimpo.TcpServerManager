using System;

namespace Olimpo;

public class ChannelRegistrationException : Exception
{
    public ChannelRegistrationException(string message) : base(message)
    {
    }
}