using System.Linq;
using ICSharpCode.NRefactory.CSharp.Refactoring;
using OmniSharp.Common;
using OmniSharp.Configuration;
using OmniSharp.Parser;
using OmniSharp.Refactoring;

namespace OmniSharp.CodeActions
{
    public class ImplementInterfaceHandler
    {
        private readonly BufferParser _bufferParser;
        private readonly OmniSharpConfiguration _config;
        private readonly Logger _logger;

        public ImplementInterfaceHandler(BufferParser bufferParser, Logger logger, OmniSharpConfiguration config)
        {
            _bufferParser = bufferParser;
            _logger = logger;
            _config = config;
        }

        public ImplementInterfaceResponse ImplementInterface(Request request)
        {
            var context = OmniSharpRefactoringContext.GetContext(_bufferParser, request);
            var actions = new ImplementInterfaceAction().GetActions(context);

            using (var script = new OmniSharpScript(context, _config))
            {
                foreach (var action in actions.Where(action => action != null))
                {
                    _logger.Info(string.Format("Running {0}", action.Description));
                    action.Run(script);
                }
            }
            return new ImplementInterfaceResponse(context.Document.Text);
        }
    }
}