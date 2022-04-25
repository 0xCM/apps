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
        uint Hash {get;}

        /// <summary>
        /// The hash code that C# knows/loves as an inappropriately-ubiquitous signed 32-bit integer
        /// </summary>
        int HashCode
            => (int)Hash;
    }

    public interface IHashed<F> : IHashed
        where F : IHashed<F>
    {
        new Hash32 Hash {get;}

        uint IHashed.Hash
            => Hash;
    }
}