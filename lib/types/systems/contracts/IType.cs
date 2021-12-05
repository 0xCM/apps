//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IType
    {
        TypeKind Kind {get;}

    }

    public interface IType<K> : IType
        where K : unmanaged
    {
        new TypeKind<K> Kind {get;}

        TypeKind IType.Kind
            => Kind;
    }
}