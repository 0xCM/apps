//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;

    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct RegMask
    {
        uint Index;

        uint Class;

        ushort Width;

        [MethodImpl(Inline)]
        public void Include(RegWidth src)
        {
             Width |= Pow2.pow16u((byte)src.Size.Code);
        }

        [MethodImpl(Inline)]
        public void Include(AsmRegClass src)
        {
             Class |= Pow2.pow32u(src);
        }

        [MethodImpl(Inline)]
        public void Include(RegIndex src)
        {
             Index |= Pow2.pow32u(src);
        }
    }
}