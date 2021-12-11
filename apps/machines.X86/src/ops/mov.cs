//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Machines.X86
{
    using System;
    using System.Runtime.CompilerServices;

    using Asm.Operands;

    using O = Asm.Operands;
    using static Root;

    partial class X86Machine
    {
        [MethodImpl(Inline), Op]
        public void mov(O.r8 a, O.r8 b)
            => reg8(a) = reg8(b);

        [MethodImpl(Inline), Op]
        public void mov(O.r16 a, O.r16 b)
            => reg16(a) = reg16(b);

        [MethodImpl(Inline), Op]
        public void mov(O.r32 a, O.r32 b)
            => reg32(a) = reg32(b);

        [MethodImpl(Inline), Op]
        public void mov(O.r64 a, O.r64 b)
            => reg64(a) = reg64(b);
    }
}