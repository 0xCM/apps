//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    /// <summary>
    /// Characterizes a kinded thing
    /// </summary>
    /// <typeparam name="K">The classifier type</typeparam>
    [Free]
    public interface IKinded<K> : ITextual
        where K : unmanaged
    {
        K Kind {get;}

        string ITextual.Format()
            => Kind.ToString();
    }
}