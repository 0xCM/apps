//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    unsafe partial struct memory
    {
        /// <summary>
        /// Identifies a buffer of specified base address and size
        /// </summary>
        /// <param name="base"></param>
        /// <param name="size"></param>
        [MethodImpl(Inline), Op]
        public static BufferToken token(MemoryAddress @base, ByteSize size)
            => new BufferToken(@base,size);
    }
}