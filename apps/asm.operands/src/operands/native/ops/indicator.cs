//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static ScalarClass;

    partial class NativeTypes
    {
        [Op]
        public static char indicator(ScalarClass @class)
            => @class switch {
                B => Chars.b,
                U => Chars.u,
                I => Chars.i,
                F => Chars.f,
                C => Chars.c,
                _ => ' ',
            };
    }
}