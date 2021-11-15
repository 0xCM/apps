//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static Numeric;
    using static core;

    [DataType("imm{t}")]
    public readonly struct ImmOp<T> : IImm<ImmOp<T>,T>
        where T : unmanaged
    {
        public T Content {get;}

        [MethodImpl(Inline)]

        public ImmOp(T src)
            => Content = src;

        public static ImmBitWidth Capacity
        {
            [MethodImpl(Inline)]
            get => (ImmBitWidth)(byte)width<T>();
        }

        public static ImmKind Kind
        {
            [MethodImpl(Inline)]
            get => (ImmKind)Capacity;
        }

        public byte EffectiveWidth
        {
            [MethodImpl(Inline)]
            get => Widths.effective(Imm64);
        }

        public ulong Imm64
        {
            [MethodImpl(Inline)]
            get => force<T,ulong>(Content);
        }

        public uint Imm32
        {
            [MethodImpl(Inline)]
            get => force<T,uint>(Content);
        }

        public ushort Imm16
        {
            [MethodImpl(Inline)]
            get => force<T,ushort>(Content);
        }

        public byte Imm8
        {
            [MethodImpl(Inline)]
            get => force<T,byte>(Content);
        }

        public uint Hash
        {
            [MethodImpl(Inline)]
            get => alg.hash.calc(Content);
        }

        public bool IsZero
        {
            [MethodImpl(Inline)]
            get => Imm8 == 0;
        }

        public bool IsNonZero
        {
            [MethodImpl(Inline)]
            get => Imm8 != 0;
        }


        public override int GetHashCode()
            => (int)Hash;


        [MethodImpl(Inline)]
        public bool Equals(ImmOp<T> src)
            => Imm64 == src.Imm64;

        public override bool Equals(object obj)
            => obj is ImmOp<T> x && Equals(x);

        public string Format()
        {
            if(width<T>() == 8)
                return HexFormatter.format(w8, Content, true);
            else if(width<T>() == 16)
                return HexFormatter.format(w16, Content, true);
            else if(width<T>() == 32)
                return HexFormatter.format(w32, Content, true);
            else
                return HexFormatter.format(w64, Content, true);
        }

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public int CompareTo(ImmOp<T> src)
            => Imm64 == src.Imm64 ? 0 : Imm64 < src.Imm64 ? -1 : 1;

        [MethodImpl(Inline)]
        public static implicit operator ImmOp<T>(byte src)
            => new ImmOp<T>(force<byte,T>(src));

        [MethodImpl(Inline)]
        public static implicit operator ImmOp<T>(ushort src)
            => new ImmOp<T>(force<ushort,T>(src));

        [MethodImpl(Inline)]
        public static implicit operator ImmOp<T>(uint src)
            => new ImmOp<T>(force<uint,T>(src));

        [MethodImpl(Inline)]
        public static implicit operator ImmOp<T>(ulong src)
            => new ImmOp<T>(force<ulong,T>(src));
    }
}