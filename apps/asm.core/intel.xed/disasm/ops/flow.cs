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
        public static DisasmFlow flow(IAppService svc, WsContext context, IDisasmTarget dst)
            => new DisasmFlow(context, dst);

        public static DisasmFlow flow(IAppService svc, WsContext context)
            => flow(svc, context, DisasmTarget.create(svc, context));

        public static void flow(IAppService svc, WsContext context, in FileRef src, Func<IDisasmTarget> dst)
        {
            var target = DisasmTarget.create(svc,context);
            var f = flow(svc,context);

        }

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

        public static Index<DisasmFlow> flows(IAppService svc, WsContext context, Index<IDisasmTarget> targets)
        {
            var dst = alloc<DisasmFlow>(targets.Count);
            for(var i=0; i<targets.Count; i++)
                seek(dst,i) = flow(svc,context, targets[i]);
            return dst;

        }

        public static Index<DisasmFlow> flows(IAppService svc, WsContext context, uint count)
        {
            var dst = alloc<DisasmFlow>(count);
            for(var i=0; i<count; i++)
                seek(dst,i) = flow(svc,context);
            return dst;
        }
    }
}