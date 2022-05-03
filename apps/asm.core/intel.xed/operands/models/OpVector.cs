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
        public static OpVector vector(InstPattern src)
        {
            ref readonly var ops = ref src.OpDetails;
            var count = (byte)ops.Count;
            var dst = OpVector.init(count);
            for(var i=z8; i<count; i++)
            {
                ref readonly var op = ref ops[i];
                dst[i] = OpVector.cell(op.Index, op.Name, op.Kind, op.BitWidth);
            }
            return dst;
        }

        public readonly struct OpVector
        {
            public static OpVector init(byte n)
                => new OpVector(n);

            [MethodImpl(Inline)]
            public static Component cell(uint3 pos, OpName name, OpKind kind, ushort width)
                => new(pos,name,kind, width);

            public readonly byte N;

            public OpVector(byte n)
            {
                N = n;
                Data = alloc<Component>(n);
            }

            readonly Index<Component> Data;

            public ref Component this[byte i]
            {
                [MethodImpl(Inline)]
                get => ref Data[i];
            }

            public string Format()
            {
                var dst = text.buffer();
                if(N > 0)
                {
                    dst.Append(Chars.Lt);
                    for(var i=z8; i<N; i++)
                    {
                        if(i !=0)
                            dst.Append(Chars.Comma);

                        ref readonly var c = ref this[i];
                        dst.Append(c.Indicator.Format());
                        if(c.BitWidth != 0)
                        {
                            dst.AppendFormat(":w{0}", c.BitWidth);
                        }

                    }
                    dst.Append(Chars.Gt);

                }

                return dst.Emit();
            }

            public override string ToString()
                => Format();

            public static OpVector Empty => default;

            public readonly struct Component
            {
                public readonly uint3 Pos;

                public readonly OpName Name;

                public readonly OpKind Kind;

                public readonly ushort BitWidth;

                [MethodImpl(Inline)]
                public Component(uint3 pos, OpName name, OpKind kind, ushort width)
                {
                    Kind = kind;
                    Name = name;
                    Pos = pos;
                    BitWidth = width;
                }

                public OpIndicator Indicator
                {
                    [MethodImpl(Inline)]
                    get => Name.Indicator;
                }
            }
        }
    }
}