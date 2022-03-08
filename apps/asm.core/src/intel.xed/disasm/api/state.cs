//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedDisasm
    {
        public static void state(ReadOnlySpan<Facet<string>> src, out DisasmState dst)
        {
            var parser = new DisasmFieldParser();
            parser.ParseState(src, out dst);
        }
    }
}