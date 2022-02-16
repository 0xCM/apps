//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Numeric;
    using static core;
    using Z0.Asm;

    [DataType("imm<t:{0}>")]
    public readonly struct Imm<T> : IImm<Imm<T>,T>
        where T : unmanaged
    {
        public T Value {get;}

        [MethodImpl(Inline)]

        public Imm(T src)
            => Value = src;

        public AsmOpClass OpClass
        {
            [MethodImpl(Inline)]
            get => AsmOpClass.Imm;
        }

        public ImmKind ImmKind
        {
            [MethodImpl(Inline)]
            get => (ImmKind)(byte)width<T>();
        }

        public NativeSize OpSize
        {
            [MethodImpl(Inline)]
            get => Sizes.native(width<T>());
        }

        public AsmOpKind OpKind
        {
            [MethodImpl(Inline)]
            get => (AsmOpKind)((ushort)OpClass | ((ushort)OpSize << 8));
        }

        public byte EffectiveWidth
        {
            [MethodImpl(Inline)]
            get => Widths.effective(Imm64);
        }

        public ulong Imm64
        {
            [MethodImpl(Inline)]
            get => force<T,ulong>(Value);
        }

        public uint Imm32
        {
            [MethodImpl(Inline)]
            get => force<T,uint>(Value);
        }

        public ushort Imm16
        {
            [MethodImpl(Inline)]
            get => force<T,ushort>(Value);
        }

        public byte Imm8
        {
            [MethodImpl(Inline)]
            get => force<T,byte>(Value);
        }

        public uint Hash
        {
            [MethodImpl(Inline)]
            get => alg.ghash.calc(Value);
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
        public bool Equals(Imm<T> src)
            => Imm64 == src.Imm64;

        public override bool Equals(object obj)
            => obj is Imm<T> x && Equals(x);

        public string Format()
        {
            if(width<T>() == 8)
                return HexFormatter.format(w8, Imm8, prespec:true, @case:UpperCase);
            else if(width<T>() == 16)
                return HexFormatter.format(w16, Imm16, prespec:true, @case:UpperCase);
            else if(width<T>() == 32)
                return HexFormatter.format(w32, Imm32, prespec:true, @case:UpperCase);
            else
                return HexFormatter.format(w64, Imm64, prespec:true, @case:UpperCase);
        }

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public int CompareTo(Imm<T> src)
            => Imm64 == src.Imm64 ? 0 : Imm64 < src.Imm64 ? -1 : 1;

        [MethodImpl(Inline)]
        public static implicit operator Imm<T>(byte src)
            => new Imm<T>(force<byte,T>(src));

        [MethodImpl(Inline)]
        public static implicit operator Imm<T>(ushort src)
            => new Imm<T>(force<ushort,T>(src));

        [MethodImpl(Inline)]
        public static implicit operator Imm<T>(uint src)
            => new Imm<T>(force<uint,T>(src));

        [MethodImpl(Inline)]
        public static implicit operator Imm<T>(ulong src)
            => new Imm<T>(force<ulong,T>(src));

        [MethodImpl(Inline)]
        public static implicit operator Imm(Imm<T> src)
            => new Imm(src.ImmKind, bw64(src.Value));
    }
}