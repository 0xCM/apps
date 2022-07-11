//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes a hash code provider
    /// </summary>
    public interface IHashed
    {
        /// <summary>
        /// The hash code as an unsigned 32-bit integer
        /// </summary>
        Hash32 Hash {get;}
    }

    public interface IHashed<H> : IHashed
        where H : IHashCode
    {

    }
}