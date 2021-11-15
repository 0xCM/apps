//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Machines.X86
{
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    using Asm;

    public readonly struct XmmRegAlloc
    {
        readonly RegAlloc Alloc;

        [MethodImpl(Inline)]
        internal XmmRegAlloc(RegAlloc src)
            => Alloc = src;

        [MethodImpl(Inline)]
        public ref Cell128 r128(RegIndexCode i)
        {
            var address = Alloc.RegAddress((byte)i);
            var data = cover<Cell128>(address,1);
            return ref first(data);
        }
    }
}