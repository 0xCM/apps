//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;
    using static SibFields;

    [LiteralProvider]
    public readonly struct SibFields
    {
        public const string BitPattern = "ss iii bbb";

        public const byte RenderWidth = 10;

        public const byte Base_Mask = 0b00_000_111;

        public const byte Base_Min = 0;

        public const byte Base_Max = 2;

        public const byte Base_Width = Base_Max - Base_Min + 1;

        public const byte Index_Mask = 0b00_111_000;

        public const byte Index_Min = 3;

        public const byte Index_Max = 5;

        public const byte Index_Width = Index_Max - Index_Min + 1;

        public const byte Scale_Mask = 0b11_000_000;

        public const byte Scale_Min = 6;

        public const byte Scale_Max = 7;

        public const byte Scale_Width = Scale_Max - Scale_Min + 1;
    }

    [ApiComplete, DataType("asm.sib")]
    public struct Sib : IAsmByte<Sib>
    {
        [MethodImpl(Inline), Op]
        public static ScaleFactor factor(Sib src)
            => (ScaleFactor)Pow2.pow8u(src.Scale);

        public const string BitPattern = SibFields.BitPattern;

        [MethodImpl(Inline)]
        public static Sib init(byte src = 0)
            => new Sib(src);

        byte _Value;

        [MethodImpl(Inline)]
        public Sib(byte src)
        {
            _Value = src;
        }

        public uint3 Base
        {
            [MethodImpl(Inline)]
            get => (uint3)bits.extract(_Value, Base_Min, Base_Max);

            [MethodImpl(Inline)]
            set => _Value = math.or(bits.scatter((byte)value, Base_Mask), math.and(_Value, math.not(Base_Mask)));
        }

        public uint3 Index
        {
            [MethodImpl(Inline)]
            get => (uint3)bits.extract(_Value, Index_Min, Index_Max);

            [MethodImpl(Inline)]
            set => _Value = math.or(bits.scatter((byte)value, Index_Mask), math.and(_Value, math.not(Index_Mask)));
        }

        public uint2 Scale
        {
            [MethodImpl(Inline)]
            get => (uint2)bits.extract(_Value, Scale_Min, Scale_Max);

            [MethodImpl(Inline)]
            set => _Value = math.or(bits.scatter((byte)value, Scale_Mask), math.and(_Value, math.not(Scale_Mask)));
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => _Value.Equals(0);
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => !IsEmpty;
        }

        [MethodImpl(Inline)]
        public byte Value()
            => _Value;

        public static Sib Empty
            => default;

        public string ToBitString()
        {
            Span<char> dst = stackalloc char[RenderWidth];

            var i = 0u;
            BitRender.render2(Scale, ref i, dst);
            seek(dst,i++) = Chars.Space;

            BitRender.render3(Index, ref i, dst);
            seek(dst,i++) = Chars.Space;

            BitRender.render3(Base, ref i, dst);
            return new string(dst);
        }

        public string Format()
            => AsmRender.asmbyte(this);

        public override string ToString()
            => Format();

        public bool Equals(Sib src)
            => _Value == src._Value;

        public override bool Equals(object src)
            => src is Sib x && Equals(x);

        public override int GetHashCode()
            => _Value;

        [MethodImpl(Inline)]
        public static implicit operator byte(Sib src)
            => src.Value();

        public static bool operator ==(Sib a, Sib b)
            => a.Equals(b);

        public static bool operator !=(Sib a, Sib b)
            => !a.Equals(b);
    }
}