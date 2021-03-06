//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using C = AsciCode;

    partial struct TextQuery
    {
        [MethodImpl(Inline), Op]
        public static bit lbracket(C src)
            => src == C.LBracket;

        [MethodImpl(Inline), Op]
        public static bit lbracket(char src)
            => src == (char)C.LBracket;
    }
}