//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class CmdResultProcessor : ILineProcessor
    {
        public static ILineProcessor create(FS.FilePath script, Index<IToolResultHandler> handlers)
            => new CmdResultProcessor(script, handlers);

        public static ILineProcessor create(FS.FilePath script)
            => new CmdResultProcessor(script);

        public FS.FilePath ScriptPath {get;}

        IToolResultHandler CurrentHandler;

        IToolResultHandler DefaultHandler;

        Index<IToolResultHandler> KnownHandlers;

        public CmdResultProcessor(FS.FilePath script, Index<IToolResultHandler> handlers)
        {
            ScriptPath = script;
            DefaultHandler = new DefaultResultHandler();
            CurrentHandler = DefaultHandler;
            KnownHandlers = handlers;
        }

        public CmdResultProcessor(FS.FilePath script)
        {
            ScriptPath = script;
            DefaultHandler = new DefaultResultHandler();
            CurrentHandler = DefaultHandler;
            KnownHandlers = sys.empty<IToolResultHandler>();
        }

        void Switch(IToolResultHandler handler)
        {
            CurrentHandler = handler;
            term.inform($"Beginning {CurrentHandler.Tool} result processing");
        }

        void Revert()
        {
            CurrentHandler = DefaultHandler;
        }

        bool Handle(TextLine src)
            => CurrentHandler.Handle(src);

        public TextLine Process(TextLine src)
        {
            if(!Handle(src))
                Revert();

            foreach(var handler in KnownHandlers)
            {
                if(handler.CanHandle(src))
                {
                    Switch(handler);
                    break;
                }
            }

            return src;
        }
    }
}