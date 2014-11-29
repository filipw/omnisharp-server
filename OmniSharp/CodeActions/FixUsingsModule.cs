using Nancy;
using Nancy.ModelBinding;
using OmniSharp.CodeIssues;

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

public class ImplmentInterfaceModule : NancyModule
{
    public ImplmentInterfaceModule(ImplementInterfaceHandler implmentInterfaceHandler)
    {
        Post["/implementinterface"] = x =>
        {
            var req = this.Bind<OmniSharp.Common.Request>();
            var res = implmentInterfaceHandler.ImplementInterface(req);
            return Response.AsJson(res);
        };
    }
}
