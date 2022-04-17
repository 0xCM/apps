//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedModels;

    using K = XedModels.OpKind;

    partial class XedRules
    {
        [MethodImpl(Inline), Op]
        public static int cmp(RuleTableKind a, RuleTableKind b)
            => ((byte)b).CompareTo((byte)a);

        [MethodImpl(Inline), Op]
        public static int cmp(OperatorKind a, OperatorKind b)
            => ((byte)b).CompareTo((byte)a);

        [MethodImpl(Inline), Op]
        public static int cmp(FieldKind a, FieldKind b)
            => ((byte)a).CompareTo((byte)b);

        [MethodImpl(Inline), Op]
        public static int cmp(OpKind a, OpKind b)
        {
            ref readonly var x = ref skip(OpKindOrder,(byte)a);
            ref readonly var y = ref skip(OpKindOrder,(byte)b);
            return x.CompareTo(y);
        }

        [MethodImpl(Inline)]
        public static int cmp(ModeKind a, ModeKind b)
        {
            return order(a).CompareTo(order(b));

            static int order(ModeKind src)
                => src switch
                {   ModeKind.Mode16 => 0,
                    ModeKind.Mode32 => 1,
                    ModeKind.Not64 => 2,
                    ModeKind.Default => 3,
                    ModeKind.Mode64 => 4,
                    _ => 0,
                };
        }

        [MethodImpl(Inline), Op]
        public static int cmp(OpNameKind a, OpNameKind b)
            => ((byte)a).CompareTo((byte)b);

        public static int cmp(InstOpClass a, InstOpClass b)
        {
            var result = XedRules.cmp(a.Kind,b.Kind);
            if(result == 0)
                result = a.DataWidth.CompareTo(b.DataWidth);
            if(result == 0)
                result = a.IsRegLit.CompareTo(b.IsRegLit);
            if(result == 0)
                result = a.IsLookup.CompareTo(b.IsLookup);
            if(result == 0)
                result = a.CellCount.CompareTo(b.CellCount);
            if(result == 0)
                result = a.ElementType.CompareTo(b.ElementType);
            if(result == 0)
                result = ((byte)a.WidthCode).CompareTo((byte)b.WidthCode);
            return result;
        }

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