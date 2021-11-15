//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Allocates strings from a suplied <see cref='StringBuffer'/>
    /// </summary>
    public class StringAllocator
    {
        StringBuffer Buffer;

        MemoryAddress MaxAddress;

        uint Position;

        internal StringAllocator(StringBuffer buffer)
        {
            Buffer = buffer;
            MaxAddress =  buffer.Address(buffer.Length);
            Position = 0;
        }

        /// <summary>
        /// Populates a <see cref='StringRef'/> that represents the input if the buffer has sufficient capacity and returns true; otherwise,
        /// returns false
        /// </summary>
        /// <param name="src">The input sequence</param>
        /// <param name="dst">The input sequence reference, if successful, otherwise a reference to the empty string</param>
        public bool Allocate(ReadOnlySpan<char> src, out StringRef dst)
        {
            var length = (uint)src.Length;
            dst = StringRef.Empty;

            if(Buffer.Address(Position + length) > MaxAddress)
                return false;

            dst = Buffer.StoreString(src, Position);
            Position += length;
            return true;
        }
    }
}