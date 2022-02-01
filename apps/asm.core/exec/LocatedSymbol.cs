//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct LocatedSymbol
    {
        [MethodImpl(Inline)]
        public static LocatedSymbol anonymous(MemoryAddress location)
            => new LocatedSymbol(location, Label.Empty);

        public readonly MemoryAddress Location;

        public readonly Label Name;

        [MethodImpl(Inline)]
        internal LocatedSymbol(MemoryAddress location, Label name)
        {
            Name = name;
            Location = location;
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

        public string Format()
            =>  Name.IsNonEmpty ? string.Format("{0} ({1})", Location, Name) : Location.Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator LocatedSymbol(MemoryAddress loc)
            => anonymous(loc);

        public static LocatedSymbol Empty
            => new LocatedSymbol(0, Label.Empty);

    }
}