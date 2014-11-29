using Nancy;
using Nancy.ModelBinding;
using OmniSharp.CodeIssues;

namespace OmniSharp.CodeActions
{
    public class FixUsingsModule : NancyModule
    {
        public FixUsingsModule(FixUsingsHandler fixUsingsHandler)
        {
            Post["/fixusings"] = x =>
            {
                var req = this.Bind<OmniSharp.Common.Request>();
                var res = fixUsingsHandler.FixUsings(req);
                return Response.AsJson(res);
            };
        }
    }
}