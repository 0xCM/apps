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
            => new LocatedSymbol(location, Label.Empty);

        public readonly uint Id;

        public readonly MemoryAddress Location;

        public readonly Label Name;

        [MethodImpl(Inline)]
        public LocatedSymbol(MemoryAddress location, Label name)
        {
            Name = name;
            Location = location;
            Id = alg.hash.combine((uint)location, (uint)name.Address);
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
            => (int)Id;

        public override bool Equals(object src)
            => src is LocatedSymbol x && Equals(x);

        [MethodImpl(Inline)]
        public static implicit operator LocatedSymbol(MemoryAddress loc)
            => anonymous(loc);

        public static LocatedSymbol Empty
            => new LocatedSymbol(0, Label.Empty);
    }
}