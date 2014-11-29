using OmniSharp.CodeActions;
using OmniSharp.Common;
using OmniSharp.Configuration;
using OmniSharp.Parser;
using OmniSharp.Tests.Rename;

namespace OmniSharp.Tests.ImplementInterface
{
    public static class ImplementInterfaceExtensions
    {
        public static ImplementInterfaceResponse GetImplementInterfaceResponse(this string buffer, int line, int column)
        {
            var solution = new FakeSolutionBuilder().AddFile(buffer).Build();
            var bufferParser = new BufferParser(solution);
            var handler = new ImplementInterfaceHandler(bufferParser, new Logger(Verbosity.Quiet), new OmniSharpConfiguration());
            var request = new Request { Buffer = buffer, FileName = "myfile", Line = line, Column = column };
            var response = handler.ImplementInterface(request);
            return response;
        }
    }
}