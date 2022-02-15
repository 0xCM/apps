//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using I = Rel;

    /// <summary>
    /// Defines a 32-bit immediate value
    /// </summary>
    [DataType("rel<w:32>")]
    public readonly struct Rel : IRelOp<uint>
    {
        public const byte Width = 32;

        public AsmOpKind OpKind {get;}

        public AsmRelKind RelKind {get;}

        public uint Value {get;}

        [MethodImpl(Inline)]
        public Rel(AsmRelKind kind, uint value)
        {
            RelKind = kind;
            OpKind = (AsmOpKind)((ushort)AsmOpClass.Rel | ((ushort)kind << 8));
            Value = value;
        }

        public AsmOpClass OpClass
            => AsmOpClass.Rel;

        public NativeSize Size
        {
            [MethodImpl(Inline)]
            get => (NativeSizeCode)((ushort)OpKind >> 8);
        }

        public string Format()
            => HexFormatter.format(Size, Value, prespec:true, @case:UpperCase);

        public override string ToString()
            => Format();

        public uint Hash
        {
            [MethodImpl(Inline)]
            get => alg.hash.calc(Value);
        }

        public override int GetHashCode()
            => (int)Hash;

        [MethodImpl(Inline)]
        public int CompareTo(I src)
            => Value == src.Value ? 0 : Value < src.Value ? -1 : 1;

        [MethodImpl(Inline)]
        public bool Equals(I src)
            => Value == src.Value;

        public override bool Equals(object src)
            => src is I x && Equals(x);

        [MethodImpl(Inline)]
        public MemoryAddress ToAddress()
            => Value;

        [MethodImpl(Inline)]
        public static bool operator <(I a, I b)
            => a.Value < b.Value;

        [MethodImpl(Inline)]
        public static bool operator >(I a, I b)
            => a.Value > b.Value;

        [MethodImpl(Inline)]
        public static bool operator <=(I a, I b)
            => a.Value <= b.Value;

        [MethodImpl(Inline)]
        public static bool operator >=(I a, I b)
            => a.Value >= b.Value;

        [MethodImpl(Inline)]
        public static bool operator ==(I a, I b)
            => a.Value == b.Value;

        [MethodImpl(Inline)]
        public static bool operator !=(I a, I b)
            => a.Value != b.Value;

        [MethodImpl(Inline)]
        public static implicit operator Rel(Rel8 src)
            => new Rel(AsmRelKind.Rel8, src.Value);

        [MethodImpl(Inline)]
        public static implicit operator Rel(Rel16 src)
            => new Rel(AsmRelKind.Rel16, src.Value);

        [MethodImpl(Inline)]
        public static implicit operator Rel(Rel32 src)
            => new Rel(AsmRelKind.Rel32, src.Value);

    }
}