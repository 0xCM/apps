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
        public uint Value {get;}

        public NativeSize Size {get;}

        [MethodImpl(Inline)]
        public Rel(NativeSize size, uint value)
        {
            Value = value;
            Size = size;
        }

        public AsmOpKind OpKind
        {
            [MethodImpl(Inline)]
            get => AsmOps.kind(AsmOpClass.Rel, Size);
        }

        public AsmOpClass OpClass
            => AsmOpClass.Rel;

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
            => new Rel(NativeSizeCode.W8, src.Value);

        [MethodImpl(Inline)]
        public static implicit operator Rel(Rel16 src)
            => new Rel(NativeSizeCode.W16, src.Value);

        [MethodImpl(Inline)]
        public static implicit operator Rel(Rel32 src)
            => new Rel(NativeSizeCode.W32, src.Value);

    }
}