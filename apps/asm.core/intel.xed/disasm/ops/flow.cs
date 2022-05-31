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
        public static IFlow flow(WsContext context)
            => new Flow(context);

        static long DisasmTokens;

        [MethodImpl(Inline)]
        public static DisasmToken token()
            => (uint)core.inc(ref DisasmTokens);
    }
}