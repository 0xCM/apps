//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial class AsmBits
    {
        [Op]
        public static AsmBitstring bitstring(in AsmHexCode src)
            => src;
    }
}