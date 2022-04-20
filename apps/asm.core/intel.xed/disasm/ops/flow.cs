//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedRules;

    partial class XedDisasm
    {
        [MethodImpl(Inline)]
        public static DisasmFlow flow(WsContext context)
            => new DisasmFlow(context);

        public static void flow(IAppService svc, WsContext context, in FileRef src, IDisasmTarget dst)
            => flow(context).Run(src,dst);

        static long DisasmTokens;

        [MethodImpl(Inline)]
        public static DisasmToken token()
            => (uint)core.inc(ref DisasmTokens);

        public static Index<IDisasmTarget> targets(uint count)
        {
            var dst = alloc<IDisasmTarget>(count);
            for(var i=0; i<count; i++)
                seek(dst,i) = new DisasmTarget();
            return dst;
        }

        public static Index<DisasmFlow> flows(WsContext context, Index<IDisasmTarget> targets)
        {
            var dst = alloc<DisasmFlow>(targets.Count);
            for(var i=0; i<targets.Count; i++)
                seek(dst,i) = flow(context);
            return dst;
        }

        public static Index<DisasmFlow> flows(WsContext context, uint count)
        {
            var dst = alloc<DisasmFlow>(count);
            for(var i=0; i<count; i++)
                seek(dst,i) = flow(context);
            return dst;
        }
    }
}