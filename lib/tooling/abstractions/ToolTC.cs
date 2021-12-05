//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static core;

    public abstract class Tool<T,C> : Tool<T>, ICmdLineTool<T,C>
        where T : Tool<T,C>,new()
        where C : IToolCmd
    {
        Index<char> _RenderBuffer;

        object RenderLock;

        protected Tool(ToolId id)
            : base(id)
        {
            _RenderBuffer = alloc<char>(2048);
            RenderLock = new object();
        }

        Span<char> Buffer()
        {
            var src = _RenderBuffer.Edit;
            src.Clear();
            return src;
        }

        public CmdLine CmdLine(in C src)
        {
            lock(RenderLock)
            {
                var buffer = Buffer();
                var i = 0u;
                var length = Render(src, ref i, buffer);
                var content = text.format(slice(buffer,0, length));
                return new CmdLine(content);
            }
        }

        protected abstract uint Render(C src, ref uint i, Span<char> dst);
    }
}
