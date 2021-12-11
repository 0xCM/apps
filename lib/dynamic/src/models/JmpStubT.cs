//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public struct JmpStub<T>
        where T : unmanaged
    {
        public MemoryRange Location {get; private set;}

        [MethodImpl(NotInline)]
        ulong Jump(T a0)
            => core.timestamp();

        public MemoryRange Init()
        {
            Jump(default);
            var @base = ClrJit.jit(GetType().Method(nameof(Jump)));
            var size = 16ul;
            var liberated = memory.liberate(@base, size);
            if(liberated.IsNonZero)
                Location = (@base, @base + size);
            return Location;
        }
    }
}