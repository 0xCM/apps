//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Characterizes a test service that provides access to a buffer sequence
    /// </summary>
    public interface IBufferedChecker : IChecker, IDisposable, IBufferTokenSource
    {
        /// <summary>
        /// All the buffers belong to this
        /// </summary>
        BufferTokens Tokens {get;}

        /// <summary>
        /// Returns the token of an index-identified buffer
        /// </summary>
        ref readonly BufferToken IBufferTokenSource.this[BufferSeqId id]
        {
            [MethodImpl(Inline)]
            get => ref Tokens[id];
        }
    }
}