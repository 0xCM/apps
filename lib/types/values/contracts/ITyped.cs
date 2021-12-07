//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface ITyped : ITerm
    {
        IType Type => TypeDef.Empty;
    }

    [Free]
    public interface ITyped<K> : ITyped
        where K : unmanaged
    {
        new IType<K> Type => TypeDef<K>.Empty;

        IType ITyped.Type
            => Type;
    }
}