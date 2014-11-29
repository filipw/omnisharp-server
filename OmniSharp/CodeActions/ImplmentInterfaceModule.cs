using Nancy;
using Nancy.ModelBinding;
using OmniSharp.CodeIssues;

namespace OmniSharp.CodeActions
{
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
}