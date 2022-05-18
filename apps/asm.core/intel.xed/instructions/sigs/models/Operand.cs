//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    partial class XedRules
    {
        partial class InstSigs
        {
            [StructLayout(StructLayout,Pack=1), DataWidth(Width)]
            public readonly struct Operand
            {
                public const byte Width = num3.Width + OpName.Width + OpIndicator.Width + num8.Width + num16.Width;

                public readonly num3 Pos;

                public readonly OpName Name;

                public readonly OpIndicator Indicator;

                public readonly OpKind Kind;

                public readonly ushort Bits;

                [MethodImpl(Inline)]
                public Operand(num3 pos, OpName name, OpIndicator ind, OpKind kind, ushort width)
                {
                    Kind = kind;
                    Name = name;
                    Pos = pos;
                    Bits = width;
                    Indicator = ind;
                }
            }
        }
    }
}