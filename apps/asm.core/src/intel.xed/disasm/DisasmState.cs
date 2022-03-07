//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static XedRules;
    partial class XedDisasmSvc
    {
        [Record(TableId), StructLayout(LayoutKind.Sequential,Pack=1)]
        public struct DisasmState
        {
            public const string TableId = "xed.disasm.state";

            public imm64 UIMM0;

            public Disp64 DISP;

            public text31 AGENVal;

            public text31 MEM0Val;

            public text31 MEM1Val;

            public RuleState RuleState;

            public static DisasmState Empty => default;

        }
    }
}