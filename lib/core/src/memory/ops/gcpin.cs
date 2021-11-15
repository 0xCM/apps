//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    unsafe partial struct memory
    {
        [Op]
        public static ManagedBuffer gcpin(byte[] buffer)
            => new ManagedBuffer(GCHandle.Alloc(buffer, GCHandleType.Pinned), (uint)buffer.Length);

        [Op, Closures(Closure)]
        public static ManagedBuffer<T> gcpin<T>(T[] buffer)
            where T : unmanaged
                => new ManagedBuffer<T>(GCHandle.Alloc(buffer, GCHandleType.Pinned), (uint)buffer.Length*core.size<T>());
    }
}