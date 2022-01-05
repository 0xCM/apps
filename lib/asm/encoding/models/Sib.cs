//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    // SIB[Scale[6,7] | Index[3,5] | Base[0,2]]
    [ApiComplete, DataType("asm.sib")]
    public struct Sib : IAsmByte<Sib>
    {
        public const string BitPattern = "ss iii bbb";

        const byte Base_Mask = 0b00_000_111;

        const byte Base_Min = 0;

        const byte Base_Max = 2;

        const byte Base_Width = Base_Max - Base_Min + 1;

        const byte Index_Mask = 0b00_111_000;

        const byte Index_Min = 3;

        const byte Index_Max = 5;

        const byte Index_Width = Index_Max - Index_Min + 1;

        const byte Scale_Mask = 0b11_000_000;

        const byte Scale_Min = 6;

        const byte Scale_Max = 7;

        const byte Scale_Width = Scale_Max - Scale_Min + 1;

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

        const byte BaseOffset = 0;

        const byte IndexMask = 0b11_000_111;

        const byte IndexOffset = 3;

        const byte ScaleMask = 0b00_111_111;

        const byte ScaleOffset = 6;

        // [MethodImpl(Inline)]
        // public uint3 Base()
        //     => (uint3)(math.srl((byte)(_Value & ~Base_Mask), BaseOffset));

        // [MethodImpl(Inline)]
        // public void Base(uint3 src)
        //     => _Value = math.or(math.and(_Value, Base_Mask), math.sll(src,BaseOffset));

        // [MethodImpl(Inline)]
        // public uint3 Index()
        //     => (uint3)(math.srl((byte)(_Value & ~IndexMask), IndexOffset));

        // [MethodImpl(Inline)]
        // public void Index(uint3 src)
        //     => _Value = math.or(math.and(_Value, IndexMask),math.sll(src,IndexOffset));

        // [MethodImpl(Inline)]
        // public uint2 Scale()
        //     => (uint2)(math.srl((byte)(_Value & ~ScaleMask), ScaleOffset));

        // [MethodImpl(Inline)]
        // public void Scale(uint2 src)
        //     => _Value = math.or(math.and(_Value, ScaleMask), math.sll(src,ScaleOffset));

        public MemoryScale ScaleFactor
        {
            [MethodImpl(Inline)]
            get => Pow2.pow8u(Scale);
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
            Span<char> dst = stackalloc char[10];

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