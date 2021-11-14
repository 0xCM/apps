//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    // SIB[Scale[6,7] | Index[3,5] | Base[0,2]]
    [ApiComplete]
    public struct Sib
    {
        byte Data;

        [MethodImpl(Inline)]
        public Sib(byte src)
        {
            Data = src;
        }

        [MethodImpl(Inline)]
        public byte Base()
            => bits.segment(Data, 0, 2);

        [MethodImpl(Inline)]
        public void Base(byte b)
            => Data = bits.replace(Data, 0, 2, b);

        [MethodImpl(Inline)]
        public byte Index()
            => bits.segment(Data, 3, 5);

        [MethodImpl(Inline)]
        public void Index(byte i)
            => Data = bits.replace(Data, 3, 5, i);

        [MethodImpl(Inline)]
        public byte Scale()
            => bits.segment(Data, 6, 7);

        [MethodImpl(Inline)]
        public void Scale(byte s)
            => Data = bits.replace(Data, 6, 7, s);

        public MemoryScale ScaleFactor
        {
            [MethodImpl(Inline)]
            get => Pow2.pow8u(Scale());
        }

        public byte Encoded
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Data.Equals(0);
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => !IsEmpty;
        }

        public static Sib Empty
            => default;
    }
}