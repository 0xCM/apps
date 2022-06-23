//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct text<C> : IString<text<C>,char>
        where C : unmanaged, ICharBlock<C>
    {
        readonly C Block;

        [MethodImpl(Inline)]
        public text(C block)
        {
            Block = block;
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => Block.Length;
        }

        public uint Capacity
        {
            [MethodImpl(Inline)]
            get => (uint)Block.Capacity;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Block.Hash;
        }

        public Span<char> Data
        {
            [MethodImpl(Inline)]
            get => Block.Data;
        }

        public ReadOnlySpan<char> Cells
        {
            [MethodImpl(Inline)]
            get => Block.Data;
        }

        public Span<byte> Bytes
        {
            [MethodImpl(Inline)]
            get => core.recover<byte>(Data);
        }

        public ReadOnlySpan<char> String
        {
            [MethodImpl(Inline)]
            get => Block.String;
        }

        public string Format()
            => Block.Format();

        public override string ToString()
            => Format();

        public int CompareTo(text<C> src)
            => Data.SequenceCompareTo(src.Data);

        public bool Equals(text<C> src)
            => Data.SequenceEqual(src.Data);

        public override int GetHashCode()
            => (int)Hash;

        public override bool Equals(object obj)
            => obj is text<C> x && Equals(x);

        [MethodImpl(Inline)]
        public static implicit operator text<C>(C block)
            => new text<C>(block);

        [MethodImpl(Inline)]
        public static implicit operator text<C>(string src)
            => new text<C>(CharBlocks.init<C>(src, out _));

        [MethodImpl(Inline)]
        public static implicit operator text<C>(ReadOnlySpan<char> src)
            => new text<C>(CharBlocks.init<C>(src, out _));
    }
}