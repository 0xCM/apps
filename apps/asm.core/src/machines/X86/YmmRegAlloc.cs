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

    public readonly struct YmmRegAlloc
    {
        readonly RegAlloc Alloc;

        [MethodImpl(Inline)]
        internal YmmRegAlloc(RegAlloc src)
            => Alloc = src;

        [MethodImpl(Inline)]
        public ref Cell128 r128(RegIndexCode i)
            => ref lo128(r256(i));

        [MethodImpl(Inline)]
        public ref Cell256 r256(RegIndexCode i)
        {
            var address = Alloc.RegAddress((byte)i);
            var data = cover<Cell256>(address,1);
            return ref first(data);
        }
    }
}