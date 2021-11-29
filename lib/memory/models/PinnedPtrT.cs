//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;

    public unsafe readonly struct PinnedPtr<T> : IDisposable
        where T : unmanaged
    {
        readonly object Origin;

        readonly GCHandle Handle;

        readonly T* Pointer;

        [MethodImpl(Inline)]
        internal PinnedPtr(object origin, GCHandle handle, T* ptr)
        {
            Origin = origin;
            Handle = handle;
            Pointer = ptr;
        }

        public void Dispose()
        {
            if(Handle.IsAllocated)
                Handle.Free();
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => !Handle.IsAllocated;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Handle.IsAllocated;
        }

        public static PinnedPtr<T> Empty
        {
            [MethodImpl(Inline)]
            get => new PinnedPtr<T>(null, default, null);
        }
    }
}