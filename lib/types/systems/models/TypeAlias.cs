//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct TypeAlias : ITypeAlias
    {
        public TypeKind AliasType {get;}

        public TypeKind BaseType {get;}

        [MethodImpl(Inline)]
        public TypeAlias(TypeKind src, TypeKind dst)
        {
            AliasType = src;
            BaseType = dst;
        }
    }

}