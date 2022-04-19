//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    /// <summary>
    /// Characterizes a lightweight, perhaps not-so-safe, "SafeHandle"
    /// </summary>
    [Free]
    public interface ISystemHandle
    {
        /// <summary>
        /// The handle address
        /// </summary>
        MemoryAddress Address {get;}

        /// <summary>
        /// Specifies whether the instance is responsible for handle lifecycle management
        /// </summary>
        bool IsOwner {get;}
    }
}