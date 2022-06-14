//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct SymAddress : IEquatable<SymAddress>, IComparable<SymAddress>, INullity
    {
        [MethodImpl(Inline), Op]
        public static SymAddress define(uint selector, MemoryAddress address)
            => new SymAddress(selector, address);

        public readonly uint Selector;

        public readonly MemoryAddress Address;

        [MethodImpl(Inline)]
        public SymAddress(uint selector, MemoryAddress address)
        {
            Selector = selector;
            Address = address;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Selector == 0 && Address == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => !IsEmpty;
        }

        public bool IsNonZero
        {
            [MethodImpl(Inline)]
            get => !IsEmpty;
        }

        public bool HasSelector
        {
            [MethodImpl(Inline)]
            get => Selector != 0;
        }

        public uint Hash
        {
            [MethodImpl(Inline)]
            get => alg.hash.combine(Selector, (uint)Address);
        }


        public override int GetHashCode()
            => (int)Hash;

        public string Format()
            => HasSelector ? string.Format("{0:x8}:{1:x6}h", Selector, (ulong)Address) : Address.Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public bool Equals(SymAddress src)
            => Selector == src.Selector && Address == src.Address;

        [MethodImpl(Inline)]
        public int CompareTo(SymAddress src)
        {
            var result = Selector.CompareTo(src.Selector);
            if(result == 0)
                result = Address.CompareTo(src.Address);
            return result;
        }

        public override bool Equals(object src)
            => src is SymAddress x && Equals(x);


        [MethodImpl(Inline)]
        public static bool operator == (SymAddress a, SymAddress b)
            => a.Equals(b);

        [MethodImpl(Inline)]
        public static bool operator != (SymAddress a, SymAddress b)
            => !a.Equals(b);

        [MethodImpl(Inline)]
        public static implicit operator SymAddress((uint sel, MemoryAddress address) src)
            => new SymAddress(src.sel, src.address);

        [MethodImpl(Inline)]
        public static implicit operator MemoryAddress(SymAddress src)
            => src.Address;

        public static SymAddress Zero => default;
    }
}