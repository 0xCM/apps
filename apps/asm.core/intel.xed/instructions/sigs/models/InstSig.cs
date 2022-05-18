//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static core;

    partial class XedRules
    {
        partial class InstSigs
        {
            public readonly struct InstSig
            {
                public static InstSig init(byte n)
                    => new InstSig(n);

                [MethodImpl(Inline)]
                public static Operand op(num3 pos, OpName name, OpIndicator ind, OpKind kind, ushort width)
                    => new(pos, name, ind,kind, width);

                public readonly byte N;

                public readonly ushort PackedWidth;

                public InstSig(byte n)
                {
                    N = n;
                    Ops = alloc<Operand>(n);
                    PackedWidth = (ushort)(n*Operand.Width);
                }

                readonly Index<Operand> Ops;

                public ref Operand this[byte i]
                {
                    [MethodImpl(Inline)]
                    get => ref Ops[i];
                }

                public string Format()
                    => format(this);

                public override string ToString()
                    => Format();

                public static InstSig Empty => default;
           }
        }
    }
}