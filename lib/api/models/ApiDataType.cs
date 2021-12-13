//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct ApiDataType : IComparable<ApiDataType>
    {
        public Identifier Name {get;}

        public @string Syntax {get;}

        public object Kind {get;}

        public BitWidth ContentWidth {get;}

        public BitWidth StorageWidth {get;}

        [MethodImpl(Inline)]
        public ApiDataType(Identifier name, @string syntax, object kind, BitWidth content, BitWidth storage)
        {
            Name = name;
            Syntax = syntax;
            Kind = kind;
            ContentWidth = content;
            StorageWidth = storage;
        }

        public int CompareTo(ApiDataType src)
            => Name.CompareTo(src.Name);
    }
}