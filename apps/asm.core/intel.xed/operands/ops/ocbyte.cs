//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static core;

    partial class XedOperands
    {
        [MethodImpl(Inline), Op]
        public static ref readonly Hex8 ocbyte(in OperandState src)
            => ref @as<Hex8>(src.NOMINAL_OPCODE);

        partial struct Edit
        {
            [MethodImpl(Inline), Op]
            public static ref byte ocbyte(ref OperandState src)
                => ref src.NOMINAL_OPCODE;
        }
    }
}