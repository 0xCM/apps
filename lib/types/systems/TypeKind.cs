//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct TypeKind : ITypeKind
    {
        public ulong Key {get;}

        public Identifier Class {get;}

        public Identifier Name {get;}

        [MethodImpl(Inline)]
        public TypeKind(ulong key, Identifier @class, Identifier name)
        {
            Key = key;
            Class = @class;
            Name = name;
        }

        public string Format()
            => string.Format("{0}:{1}",Name, Class);

        public override string ToString()
            => Format();
    }
}