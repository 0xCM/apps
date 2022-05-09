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
        public static Pairings<InstPattern,OpVector> vectors(Index<InstPattern> src)
        {
            var dst = alloc<Paired<InstPattern,OpVector>>(src.Count);
            for(var i=0; i<src.Count; i++)
                seek(dst,i) = (src[i],vector(src[i]));
            return dst;
        }

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
            public static Component cell(num3 pos, OpName name, OpKind kind, ushort width)
                => new(pos, name, kind, width);

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
                => XedRender.format(this);

            public override string ToString()
                => Format();

            public static OpVector Empty => default;

            public readonly struct SigToken
            {
                readonly asci8 Value;

                [MethodImpl(Inline)]
                public SigToken(asci8 src)
                {
                    Value = src;
                }

                public string Format()
                    => Value.Format();

                public override string ToString()
                    => Format();

                [MethodImpl(Inline)]
                public static implicit operator SigToken(string src)
                    => new SigToken(src);
            }

            static Index<SigToken> CalcSigTokens() => new SigToken[]{
                "agen",

                "base0",
                "base1",

                "imm8",
                "imm16",
                "imm32",
                "imm64",

                "index8",
                "index80",

                "m8",
                "m16",
                "m32",
                "m64",
                "m80",
                "m128",
                "m256",
                "m512",
                "m4068",

                "ptr48",

                "r8",
                "r16",
                "r32",
                "r64",
                "r80",
                "xmm",
                "ymm",
                "zmm",

                "relbr32",
                "relbr8",

                "scale",

                "seg0",
                "seg1",
            };

            [StructLayout(StructLayout,Pack=1), DataWidth(Width)]
            public readonly struct Component
            {
                public const byte Width = num3.Width + num5.Width + num4.Width + num13.Width;

                public readonly num3 Pos;

                public readonly OpName Name;

                public readonly OpKind Kind;

                public readonly ushort Bits;

                [MethodImpl(Inline)]
                public Component(num3 pos, OpName name, OpKind kind, ushort width)
                {
                    Kind = kind;
                    Name = name;
                    Pos = pos;
                    Bits = width;
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