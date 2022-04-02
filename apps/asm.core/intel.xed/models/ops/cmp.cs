//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using K = XedModels.OpKind;

    partial struct XedModels
    {
        [MethodImpl(Inline), Op]
        public static int cmp(OpKind a, OpKind b)
        {
            ref readonly var x = ref skip(OpKindOrder,(byte)a);
            ref readonly var y = ref skip(OpKindOrder,(byte)b);
            return x.CompareTo(y);
        }

        [MethodImpl(Inline), Op]
        public static int cmp(OpNameKind a, OpNameKind b)
            => ((byte)a).CompareTo((byte)b);

        static ReadOnlySpan<byte> OpKindOrder => new byte[(byte)K.Seg + 1]{
            0,  // None:0 -> 0
            7,  // Agen:1 -> 7
            5,  // Base:2 -> 5
            11,  // Disp:3 -> 11
            3,  // Imm:4 -> 3
            9,  // Index:5 -> 9
            2,  // Mem:6 -> 2,
            8,  // Ptr:7 -> 8,
            1,  // Reg:8 -> 1,
            4, // RelBr:9 -> 4,
            10,  // Scale:10 -> 10,
            6, // Seg:11 -> 6
            };
    }
}