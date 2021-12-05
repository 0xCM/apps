//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    class DefaultResultHandler : IToolResultHandler
    {
        public ToolId Tool => default;

        void Status(TextLine src)
            => term.babble(src);

        public DefaultResultHandler()
        {

        }

        public bool Handle(TextLine src)
        {
            Status(src);
            return true;
        }

        public bool CanHandle(TextLine src)
            => true;
    }
}