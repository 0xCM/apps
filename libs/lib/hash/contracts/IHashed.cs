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

        /// <summary>
        /// The hash code that C# knows/loves as an inappropriately-ubiquitous signed 32-bit integer
        /// </summary>
        Hash32 HashCode
            => (int)Hash;
    }

    public interface IHashed<H> : IHashed
        where H : IHashCode
    {

    }
}