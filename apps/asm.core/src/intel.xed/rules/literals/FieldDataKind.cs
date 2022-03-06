//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public enum FieldDataKind : byte
        {
            None,

            B1,

            B2,

            B3,

            B4,

            B5,

            B6,

            B7,

            B8,

            U2,

            U3,

            U4,

            U5,

            U6,

            U8,

            U16,

            U64,

            Hex8,

            Imm8,

            Imm64,

            Disp,

            Broadcast,

            Chip,

            Reg,

            InstClass,

            Mem,

            MemWidth,

            Error,
        }
    }
}