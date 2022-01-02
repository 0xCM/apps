//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct XedModels
    {
        public readonly struct TableFunction
        {
            public Name Name {get;}

            [MethodImpl(Inline)]
            public TableFunction(Name name)
            {
                Name = name;
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

            [MethodImpl(Inline)]
            public string Format()
                => Name;

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator TableFunction(string src)
                => new TableFunction(src);

            public static TableFunction Empty => new TableFunction(Name.Empty);
        }
    }
}