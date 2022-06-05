//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial struct asm
    {
        [MethodImpl(Inline), Op]
        public static uint bitstring(in AsmHexCode src, Span<char> dst)
            => AsmHexCode.bitstring(src,dst);

        [Op]
        public static string bitstring(in AsmHexCode src)
            => AsmHexCode.bitstring(src);
    }
}