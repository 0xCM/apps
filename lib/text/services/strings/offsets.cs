//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    partial struct strings
    {
        [MethodImpl(Inline), Op]
        public static unsafe ref readonly uint offset(in MemoryStrings info, int index)
        {
            var src = recover<uint>(core.cover(info.OffsetBase.Pointer<byte>(), info.EntryCount*4));
            return ref core.skip(src,index);
        }

        [MethodImpl(Inline), Op]
        public static unsafe ReadOnlySpan<uint> offsets(in MemoryStrings src)
            => core.recover<uint>(core.cover(src.OffsetBase.Pointer<byte>(), src.EntryCount*4));
    }
}