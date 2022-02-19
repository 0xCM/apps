//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct NameList : IIndex<Name>
    {
        readonly Index<Name> Data;

        public Name ListName {get;}

        [MethodImpl(Inline)]
        public NameList(Name name, Name[] src)
        {
            ListName = name;
            Data = src;
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        public Span<Name> Edit
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public ReadOnlySpan<Name> View
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public Name[] Storage
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        [MethodImpl(Inline)]
        public static implicit operator NameList((Name name, Name[] names) src)
            => new NameList(src.name, src.names);

        [MethodImpl(Inline)]
        public static implicit operator NameList((string name, string[] names) src)
            => Named.list(src.name, src.names);
    }
}