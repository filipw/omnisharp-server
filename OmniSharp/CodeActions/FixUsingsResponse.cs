using System.Collections.Generic;
using OmniSharp.Common;

public class FixUsingsResponse
{
    public FixUsingsResponse(string buffer, IEnumerable<QuickFix> ambiguous)
    {
        Buffer = buffer;
        AmbiguousResults = ambiguous;
    }

    public string Buffer { get; private set; }
    public IEnumerable<QuickFix> AmbiguousResults { get; private set; }
}

public class ImplementInterfaceResponse
{
    public ImplementInterfaceResponse(string buffer)
    {
        Buffer = buffer;
    }

    public string Buffer { get; private set; }
}