//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct ContentType
    {
        public readonly ContentKind Kind;

        public readonly StringAddress Name;

        [MethodImpl(Inline)]
        internal ContentType(ContentKind kind, string name)
        {
            Kind = kind;
            Name = name;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Kind == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Kind != 0 && Name.IsNonZero;
        }

        public string Format()
            => Name.Format();

        public override string ToString()
            => Format();

        public static ContentType Empty
        {
            [MethodImpl(Inline)]
            get => new ContentType(0, EmptyString);
        }
    }
}