//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ITypeDef
    {
        TypeKind Kind {get;}

    }

    public interface ITypeDef<K> : ITypeDef
        where K : unmanaged
    {
        new TypeKind<K> Kind {get;}

        TypeKind ITypeDef.Kind
            => Kind;
    }
}