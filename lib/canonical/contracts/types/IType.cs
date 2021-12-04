//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IType : ITerm
    {
        TypeKind Kind => default;
    }

    public interface IType<K> : IType
        where K : unmanaged
    {
        new TypeKind<K> Kind => default;

        TypeKind IType.Kind
            => Kind;
    }
}