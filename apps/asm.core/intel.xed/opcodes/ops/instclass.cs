//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedRules;

    partial class XedOpCodes
    {
        [MethodImpl(Inline)]
        public static OcInstClass instclass(InstClass @class, XedOpCode opcode, byte index)
            => new OcInstClass(identify(@class,opcode,index), @class, opcode, index);


        [MethodImpl(Inline)]
        public static uint identify(InstClass @class, XedOpCode opcode, byte index)
        {
            var a = (byte)((index & 0xF) << 4);
            var b = (byte)(((byte)XedOpCodes.index(opcode.Kind) & 0xF));
            var b0 = (byte)(a | b);
            return Bitfields.join(Bitfields.join(b0,opcode.FirstByte), (ushort)@class);
        }
    }
}