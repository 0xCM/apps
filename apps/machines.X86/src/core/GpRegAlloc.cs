//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Machines.X86
{
    using System.Runtime.CompilerServices;

    using Asm;

    using static Root;
    using static Cells;
    using static core;

    public readonly struct GpRegAlloc
    {
        readonly RegAlloc Alloc;

        [MethodImpl(Inline)]
        internal GpRegAlloc(RegAlloc src)
            => Alloc = src;

        [MethodImpl(Inline)]
        public ref Cell8 r8(RegIndexCode i)
            => ref lo8(r64(i));

        [MethodImpl(Inline)]
        public ref Cell16 r16(RegIndexCode i)
            => ref lo16(r64(i));

        [MethodImpl(Inline)]
        public ref Cell32 r32(RegIndexCode i)
            => ref lo32(r64(i));

        [MethodImpl(Inline)]
        public ref Cell64 r64(RegIndexCode i)
        {
            var address = Alloc.RegAddress((byte)i);
            var data = cover<Cell64>(address,1);
            return ref first(data);
        }
    }
}