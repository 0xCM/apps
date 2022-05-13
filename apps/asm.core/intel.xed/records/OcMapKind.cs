//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static XedModels;

    partial class XedRules
    {
        [StructLayout(StructLayout,Pack=1), Record(TableId)]
        public struct OcMapKind
        {
            public const string TableId = "xed.opcode.kind";

            [Render(6)]
            public byte Index;

            [Render(12)]
            public OpCodeClass Class;

            [Render(6)]
            public asci2 Code;

            [Render(6)]
            public byte Number;

            [Render(16)]
            public OpCodeKind Kind;
        }
    }
}