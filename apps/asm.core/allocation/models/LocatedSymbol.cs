//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct LocatedSymbol : IEquatable<LocatedSymbol>, IComparable<LocatedSymbol>
    {
        [MethodImpl(Inline)]
        public static LocatedSymbol anonymous(MemoryAddress location)
            => new LocatedSymbol(SymAddress.define(location), Label.Empty);

        [MethodImpl(Inline)]
        public static LocatedSymbol define(MemoryAddress location, Label name)
            => new LocatedSymbol(SymAddress.define(location),name);

        [MethodImpl(Inline)]
        public static LocatedSymbol define(uint selector, MemoryAddress location, Label name)
            => new LocatedSymbol(SymAddress.define(selector,location), name);

        [MethodImpl(Inline)]
        public static LocatedSymbol define(SymAddress location, Label name)
            => new LocatedSymbol(location, name);

        public SymAddress Location {get;}

        public Label Name {get;}

        [MethodImpl(Inline)]
        public LocatedSymbol(SymAddress address, Label name)
        {
            Name = name;
            Location = address;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Name.IsEmpty && Location.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Name.IsNonEmpty || Location.IsNonEmpty;
        }

        [MethodImpl(Inline)]

        public bool Equals(LocatedSymbol src)
            => Name.Address.Equals(src.Name.Address) && Location == src.Location;

        [MethodImpl(Inline)]
        public int CompareTo(LocatedSymbol src)
            => Location.CompareTo(src.Location);

        public string Format()
            => Name.IsNonEmpty ? string.Format("{0} ({1})", Location, Name) : Location.Format();

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => (int)alg.hash.combine(Location.Hash, (uint)Name.Address);

        public override bool Equals(object src)
            => src is LocatedSymbol x && Equals(x);

        [MethodImpl(Inline)]
        public static implicit operator LocatedSymbol(MemoryAddress src)
            => anonymous(src);

        public static LocatedSymbol Empty
        {
            [MethodImpl(Inline)]
            get => new LocatedSymbol(SymAddress.Zero, Label.Empty);
        }
    }
}