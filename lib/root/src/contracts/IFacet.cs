//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IFacet<K,V> : IKeyed<K>
    {
        V Value {get;}

        string ITextual.Format()
            => string.Format("{0}:{1}", Key, Value);
    }
}