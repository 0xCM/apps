//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IExpr : ITextual, INullity
    {
        ulong Kind => 0;

        bool INullity.IsEmpty
            => false;

       string ITextual.Format()
            => string.Empty;

    }

    [Free]
    public interface IExpr<K> : IExpr, IKinded<K>
        where K : unmanaged
    {
        ulong IExpr.Kind
            => core.bw64((this as IKinded<K>).Kind);
    }
}