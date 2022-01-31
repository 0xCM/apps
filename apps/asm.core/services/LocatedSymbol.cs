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
        public readonly Label Name;

        public readonly MemoryAddress Location;

        [MethodImpl(Inline)]
        internal LocatedSymbol(Label name, MemoryAddress location)
        {
            Name = name;
            Location = location;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Name.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Name.IsNonEmpty;
        }

        public string Format()
            => string.Format("{0}<->{1}", Name, Location);

        public override string ToString()
            => Format();

        public static LocatedSymbol Empty
            => new LocatedSymbol(Label.Empty, 0);
    }
}