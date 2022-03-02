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

            Bit,

            Bits,

            Byte,

            U16,

            U64,

            Hex8,

            Imm,

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