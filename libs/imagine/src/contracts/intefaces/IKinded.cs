//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IKinded : ITextual
    {
        ulong Kind {get;}
    }

    /// <summary>
    /// Characterizes a kinded thing
    /// </summary>
    /// <typeparam name="K">The classifier type</typeparam>
    [Free]
    public interface IKinded<K> : IKinded
        where K : unmanaged
    {
        new K Kind {get;}

        ulong IKinded.Kind
            => Sized.bw64(Kind);

        string ITextual.Format()
            => Kind.ToString();
    }
}