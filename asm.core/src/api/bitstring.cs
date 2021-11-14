//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial struct asm
    {
        [Op]
        public static AsmBitstring bitstring(AsmHexCode src)
            => src;
    }
}