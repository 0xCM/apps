//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Machines.X86
{
    using System;
    using System.Runtime.CompilerServices;
    using Asm.Operands;

    using static Root;

    using O = Asm.Operands;

    partial class X86Machine
    {
        [MethodImpl(Inline), Op]
        public void movsx(O.r16 a, O.r8 b)
        {
            ref readonly var src = ref reg8(b);
            ref var dst = ref reg16(a);
            if(bit.test(src,7))
                dst = (ushort)((ushort)0b11111111_00000000 | (ushort)src);
            else
                dst = (ushort)src;
        }
    }
}