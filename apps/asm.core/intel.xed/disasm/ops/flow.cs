//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
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
    }
}