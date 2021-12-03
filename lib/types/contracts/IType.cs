//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    public interface ISizedType
    {
        BitWidth ContentWidth {get;}

        BitWidth StorageWidth {get;}
    }

    public interface ISizedType<T> : ISizedType
        where T : unmanaged
    {
        BitWidth ISizedType.StorageWidth
            => core.size<T>();
    }

    [Free]
    public interface IType
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