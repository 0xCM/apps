//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes a tool option
    /// </summary>
    [Free]
    public interface ICmdOptionSpec : INamed, ITextual
    {
        @string Description {get;}
    }

    /// <summary>
    /// Characterizes a kinded tool option
    /// </summary>
    [Free]
    public interface ICmdOptionSpec<K> : ICmdOptionSpec
        where K : unmanaged
    {
        K Kind {get;}

        Name INamed.Name
            => Kind.ToString();
    }
}